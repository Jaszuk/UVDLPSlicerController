using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;
using System.Threading;
using UV_DLP_3D_Printer.Slicing;

namespace UV_DLP_3D_Printer
{
    /*
     * This class controls print jobs from start to finish. It feeds the generated sliced images
     * one at a time, along with control information and GCode over the PrinterInterface
     * 
     */
    /*
     This class raises an event when the printing starts,
     * when it stops
     * when it's cancelled 
     * and each time the layer changes
     */
    public enum ePrintStat
    {
        ePrintStarted,
        ePrintCancelled,
        eLayerCompleted,
        ePrintCompleted
    }

    public delegate void delPrintStatus(ePrintStat printstat);
    public delegate void delPrinterLayer(Bitmap bmplayer, int layernum); // this is raised to display the next layer

    public class BuildManager
    {
        private  const int STATE_START                =0;
        private  const int STATE_DO_NEXT_LAYER        = 1;
        private  const int STATE_WAITING_FOR_LAYER    = 2;
        private  const int STATE_CANCELLED            = 3;
        private  const int STATE_IDLE                 = 4;
        private  const int STATE_DONE                 = 5;

        

        public delPrintStatus PrintStatus; // the delegate to let the rest of the world know
        public delPrinterLayer PrintLayer; // the delegate to show a new layer
        private bool m_printing = false;
        private int m_curlayer = 0; // the current visible slice layer index #
        SliceFile m_sf = null; // current file we're building
        GCodeFile m_gcode = null; // a reference from the zactive gcode file
        int m_gcodeline = 0; // which line of GCode are we currently on.
        int m_state = STATE_IDLE; // the state machine variable
        private Thread m_runthread; // a thread to run all this..
        private bool m_running; // a var to control thread life

        public BuildManager() 
        {
        
        }
        public bool IsPrinting { get { return m_printing; } }

        private void RaiseStatusEvent(ePrintStat status) 
        {
            if (PrintStatus != null) 
            {
                PrintStatus(status);
            }
        }
        // This function is called to start the print job
        public void StartPrint(SliceFile sf, GCodeFile gcode) 
        {
            if (m_printing)  // already printing
                return;
            if (sf == null) 
            {
                DebugLogger.Instance().LogRecord("No slice file, build cannot start");
                RaiseStatusEvent(ePrintStat.ePrintCancelled);
                return;
            }
            if (gcode == null)
            {
                DebugLogger.Instance().LogRecord("No gcode file, build cannot start");
                RaiseStatusEvent(ePrintStat.ePrintCancelled);
                return;
            }
            // we really need to map onto the events of the PrinterInterface to determine
            // important stuff like current z position, HBP temp, etc...
            m_printing = true;
            m_sf = sf; // set the slicefile for rendering
            m_gcode = gcode; // set the file 
            m_state = STATE_START; // set the state machine as started
            m_runthread = new Thread(new ThreadStart(BuildThread));
            m_running = true;
            m_runthread.Start();
        }
        private int getvarfromline(String line) 
        {
            try
            {
                int val = 0;
                line = line.Replace(')', ' ');
                String[] lines = line.Split('>');
                val = int.Parse(lines[1].Trim());
                return val;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return 0;
            }            
        }
        /*
         This is the thread that controls the build process
         * it needs to read the lines of gcode, one by one
         * send them to the printer interface,
         * wait for the printer to respond,
         * and also wait for the layer interval timer
         */
        void BuildThread() 
        {            
            int now = Environment.TickCount;
            int nextlayertime = 0;
            while (m_running)
            {
                switch (m_state) 
                {
                    case BuildManager.STATE_START:
                        //start things off, reset some variables
                        if (PrintStatus != null)
                        {
                            PrintStatus(ePrintStat.ePrintStarted);
                        }
                        m_state = BuildManager.STATE_DO_NEXT_LAYER; // go to the first layer
                        m_gcodeline = 0; // set the start line
                        m_curlayer = 0;

                        break;
                    case BuildManager.STATE_WAITING_FOR_LAYER:
                        //check time var
                        if(Environment.TickCount >= nextlayertime)
                        {
                            m_state = BuildManager.STATE_DO_NEXT_LAYER; // move onto next layer
                        }
                        break;
                    case BuildManager.STATE_IDLE:
                        // do nothing
                        break;
                    case BuildManager.STATE_DO_NEXT_LAYER:
                        //check for done
                        if(m_gcodeline >= m_gcode.Lines.Length)
                        {
                            //we're done..
                            m_state = BuildManager.STATE_DONE;
                            continue;
                        }
                        // go through the gcode, line by line
                        string line = m_gcode.Lines[m_gcodeline++];
                        line = line.Trim();
                        if (line.Length > 0)
                        {
                            // if the line is a comment, parse it to see if we need to take action
                            if (line.Contains("(<Delay> "))// get the delay
                            {                                
                                nextlayertime = Environment.TickCount + getvarfromline(line);
                                m_state = STATE_WAITING_FOR_LAYER;
                                continue;
                            }
                            else if (line.Contains("(<Slice> "))//get the slice number
                            { 
                                m_curlayer = getvarfromline(line);
                                Bitmap bmp = m_sf.RenderSlice(m_curlayer);
                                // need to send a command and wait for the z axis to raise here...
                                //raise a delegate so the main form can catch it and display layer information.
                                if (PrintLayer != null)
                                {
                                    PrintLayer(bmp, m_curlayer);
                                }
                            }
                            else if (line.Trim().StartsWith("("))// ignore line comment
                            {
                            }
                            else
                            {
                                //send to device
                                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(line);
                            }
                        }
                        break;
                    case BuildManager.STATE_DONE:
                        m_running = false;
                        m_state = BuildManager.STATE_IDLE;
                        //raise done message
                        if (PrintStatus != null)
                        {
                            PrintStatus(ePrintStat.ePrintCompleted);
                        }             
                        break;
                }
                Thread.Sleep(0);
            }
        }


        public int GenerateTimeEstimate() 
        {
            return -1;
        }

        // This function manually cancels the print job
        public void CancelPrint() 
        {
            if (m_printing) // only if we're already printing
            {
                m_printing = false;
                m_curlayer = 0;
                m_state = BuildManager.STATE_IDLE;
                m_running = false;
                if (PrintStatus != null)
                {
                    PrintStatus(ePrintStat.ePrintCancelled);
                }
            }
        }
    }
}
