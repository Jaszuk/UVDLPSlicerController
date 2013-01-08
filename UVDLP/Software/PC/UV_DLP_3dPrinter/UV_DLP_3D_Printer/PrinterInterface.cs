using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;


namespace UV_DLP_3D_Printer
{
    /*
     This class is the main interface to communicate with the printer
     * it controls the serial connection to the machine and provides 
     * data back from the machine (such as temperature readout)
     * This printer interface will support a *very limited subset of g-code commands
     * that it will use to control the printer
     * I'm not sure if choosing GCodes/MCodes is the *right choice,
     * but hey, whatever works for now...
     * 
     * GCode listing 
     * 
     * G1 - Coordinated Motion
     * G28 - Home given Axes to maximum
     * G92 - Define current position on axes
     * 
     * 
     * MCode listing
     * M0 Unconditional Halt
     * M17 enable motor(s)
     * M18 disable motor(s)     
     * M109 Snnn set build platform temperature in degrees Celsuis
     * M128 get position
     * 
     * 
     * 
     * The printer has the following features:
     * Z axis stepper motor
     * HBP 
     * fluid pump
     * z Min / z Max limit switches
     * 
     * 
     */
    public enum ePIStatus 
    {
        eTimedout, // the last command timed out
        eReady, // ready for next command
    }

    public delegate void PrinterInterfaceStatus(ePIStatus status, String Command);

    class PrinterInterface
    {
        private bool m_connected = false;        
        private int m_timeoutms = 1000; // 1 second timeout
        private SerialPort m_serialport;
        private int m_HBPtemp = -1;
        private Timer m_timeouttimer;
        public PrinterInterfaceStatus Status;

        public PrinterInterface() 
        {
            m_serialport = new SerialPort();
            m_timeouttimer = new Timer();
            m_timeouttimer.Elapsed += new ElapsedEventHandler(m_timeouttimer_Elapsed);
            m_timeouttimer.Interval = m_timeoutms;
        }        

        void m_timeouttimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // the command that was sent last has now timed out
            m_connected = false; // auto-disconnect
            if (Status != null) 
            {
                Status(ePIStatus.eTimedout, "Command Timed Out");
            }
        }

        public int GetHBPTemp { get { return m_HBPtemp; } }

        public bool Connected { get { return m_connected; } }

        /*
         This function will home to the Maximum position
         */
        public void HomeToMax() 
        {
            SendCommandToDevice("G28\r\n");
        }

        /*
         This command will instruct the machine to define the current position as 
         * the position passed in the Z variable
         */
        public void DefinePosition(double zpos) 
        {
            String command = "G92 Z" + zpos + "\r\n";
            SendCommandToDevice(command);
        }
        /*
         This function moves the Z axis to the specified position in mm 
         * at the specified feed rate
         */
        public void MoveTo(double zpos,double rate) 
        {
            String command = "G0 Z"  + zpos + " F" + rate + "\r\n";
            SendCommandToDevice(command);
        }

        /*
         This function stops all movement and motion
         */
        public void StopAll() 
        {
            SendCommandToDevice("M0\r\n");
        }
        /*
         This function will enable or disable the motors in the printer
         * based on the sent value
         */
        public void EnableMotors(bool val) 
        {
            if (val)
            {
                SendCommandToDevice("M17\r\n");
            }
            else 
            {
                SendCommandToDevice("M18\r\n");
            }            
        }
        /*
         This function sets the HBP Temperature
         */
        public void SetHBPTemp(int celsius) 
        {
            String sendstr = "M109 S";
            sendstr += celsius + "\r\n";
            SendCommandToDevice(sendstr);
            //M109 Snnn
        }

        public bool Connect(String comport) 
        {
            try
            {
                //any command can be use to "connect" the printer,
                // the big issue is that hte printer responds within the
                // allotted timeframe.
                m_serialport.BaudRate = 115200;// default baud rate
                m_serialport.Parity = Parity.None;
                m_serialport.DataBits = 8;
                m_serialport.StopBits = StopBits.One;
                m_serialport.Open();
                m_serialport.DataReceived += new SerialDataReceivedEventHandler(m_serialport_DataReceived);

                return true;
            }
            catch (Exception ) 
            {
                return false;
            }
        }

        void m_serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            // data was received by the serial port
            //stop the timeout timer 
            m_timeouttimer.Enabled = false;
        }

        public bool SendCommandToDevice(String command) 
        {
            try
            {
                m_serialport.WriteLine(command);
                //start a timer
                m_timeouttimer.Enabled = true;
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
