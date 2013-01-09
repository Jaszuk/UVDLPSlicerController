using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using System.Drawing;

namespace UV_DLP_3D_Printer
{
    /*
     * This class controls print jobs from start to finish. It feeds the generated sliced images
     * one at a time, along with control information over the PrinterInterface
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

    class PrintManager
    {
        public delPrintStatus PrintStatus; // the delegate to let the rest of the world know
        public delPrinterLayer PrintLayer; // the delegate to show a new layer
        Timer m_layertimer = new Timer();
        private bool m_printing = false;
        private int m_curlayer = 0;
        Slicer m_sl = null;
        SliceParms m_sp; // has the layer height

        public PrintManager() 
        {
        
        }
        public bool IsPrinting { get { return m_printing; } }
        // This function is called to start the print job
        public void StartPrint(Slicer sl, int ms,SliceParms sp) 
        {
            // we really need to map onto the events of the PrinterInterface to determine
            // important stuff like current z position, HBP temp, etc...
            m_printing = true;
            m_sl = sl;
            m_sp = sp;
            m_curlayer = 0;
            m_layertimer.Elapsed += new ElapsedEventHandler(m_layertimer_Elapsed);
            m_layertimer.Interval = ms;
            m_layertimer.Enabled = true;
            m_layertimer.AutoReset = true;

            if (PrintStatus != null) 
            {
                PrintStatus(ePrintStat.ePrintStarted);
            }
            NextLayer();
        }

        void NextLayer() 
        {
            if (m_curlayer >= m_sl.m_slices.Count) 
            {
                m_layertimer.Enabled = false;
                m_layertimer.AutoReset = false;
                if (PrintStatus != null)
                {
                    PrintStatus(ePrintStat.ePrintCompleted);
                    return;
                }             
            }
            //get the current slice
            Slice slice =(Slice) m_sl.m_slices[m_curlayer];
            //render it right quick...
            Bitmap bmp = m_sl.RenderSlice(m_sp, slice);
            // need to send a command and wait for the z axis to raise here...
            //raise a delegate so the main form can catch it and display layer information.
            if (PrintLayer != null) 
            {
                PrintLayer(bmp,m_curlayer);
            }
            m_curlayer++;
        }

        void m_layertimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // move on to the next layer
            NextLayer();
        }

        public int GenerateTimeEstimate() 
        {
            return -1;
        }

        // This function manually cancels the print job
        public void CancelPrint() 
        {
            m_printing = false;
            m_curlayer = 0;
            m_layertimer.Enabled = false;
            m_layertimer.AutoReset = false;
            if (PrintStatus != null)
            {
                PrintStatus(ePrintStat.ePrintCancelled);
            }        
        }
    }
}
