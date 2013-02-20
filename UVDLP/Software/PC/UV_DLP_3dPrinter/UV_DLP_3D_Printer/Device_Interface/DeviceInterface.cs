using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Timers;
using System.IO;
using UV_DLP_3D_Printer.Drivers;
using UV_DLP_3D_Printer.Configs;


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
     * I'm including a few manual commands in here because i intend on implementing a printer control panel
     * that can manually jog and set temperatures
     * 
     * the DeviceInterface can only handle one command at a time (by design)
     * the previous command must either time out or respond
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
        eError, // something went wrong
        eConnected, // device is now connected
        eDisconnected // device disconnected
    }

    public class DeviceInterface
    {
        //declare a delegate for the outside world to listen in
        public delegate void DeviceInterfaceStatus(ePIStatus status, String Command);
        public delegate void DeviceDataReceived(DeviceDriver device, byte[] data, int length);

        private int m_HBPtemp = -1;
        public DeviceInterfaceStatus StatusEvent;
        public DeviceDataReceived DataEvent;
        private DeviceDriver m_driver;
        protected Timer m_timeouttimer;
        private const int DEF_TIMEOUT = 500;// 1 second default timeout
        protected int m_timeoutms; 

        public DeviceInterface() 
        {
            m_timeoutms = DEF_TIMEOUT;
            m_timeouttimer = new Timer();
            m_timeouttimer.Elapsed += new ElapsedEventHandler(m_timeouttimer_Elapsed);
            m_timeouttimer.Interval = m_timeoutms;
            m_driver = null;
            
        }

        void m_timeouttimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // the command that was sent last has now timed out
            if (StatusEvent != null)
            {
                StatusEvent(ePIStatus.eTimedout, "Command Timed Out");
                DebugLogger.Instance().LogRecord("Command Timed out");
                m_timeouttimer.Enabled = false;
            }
        }

        // get and set the printdriver
        public DeviceDriver Driver
        {
            get { return m_driver; }
            set 
            {
                if (m_driver != null)
                {
                    DeviceDriver olddriver = m_driver;
                    olddriver.Disconnect(); // disconnect the old driver
                    //remove the old device driver delegates
                    olddriver.DataReceived -= new DeviceDriver.DataReceivedEvent(DriverDataReceivedEvent);
                    olddriver.DeviceStatus -= new DeviceDriver.DeviceStatusEvent(DriverDeviceStatusEvent);
                }
                //set the new driver
                m_driver = value; 
                //and bind the delegates to listen to events
                m_driver.DataReceived += new DeviceDriver.DataReceivedEvent(DriverDataReceivedEvent);
                m_driver.DeviceStatus += new DeviceDriver.DeviceStatusEvent(DriverDeviceStatusEvent);
            }
        }
        public void Configure(ConnectionConfig cc) 
        {
            Driver.Configure(cc);
        }
        public void DriverDeviceStatusEvent(DeviceDriver device, eDeviceStatus status) 
        {
            switch (status) 
            {
                case eDeviceStatus.eError:
                    if (StatusEvent != null)
                    {
                        StatusEvent(ePIStatus.eError, "I/O Error");
                    }                    
                    break;
                case eDeviceStatus.eConnect:                    
                    if (StatusEvent != null) 
                    {
                        StatusEvent(ePIStatus.eConnected, "Connected");
                    }
                    break;
                case eDeviceStatus.eDisconnect:
                    if (StatusEvent != null)
                    {
                        StatusEvent(ePIStatus.eDisconnected, "Disconnected");
                    }
                    break;

            }
        }
        // this is called when we receive data from the device driver
        void DriverDataReceivedEvent(DeviceDriver device, byte[] data, int length) 
        {
            // stop the watchdog timer
            m_timeouttimer.Enabled = false;
            // raise the data event
            if (DataEvent != null) 
            {
                DataEvent(device, data, length);
            }
            //raise a data event notifying that we're ready for the next command
            if (StatusEvent != null)
            {
                StatusEvent(ePIStatus.eReady, "Ready");
            }
        }

        public int TimeoutMS
        {
            get { return m_timeoutms; }
            set { m_timeoutms = value; }
        }

        public int GetHBPTemp { get { return m_HBPtemp; } }

        public bool Connected { get { return m_driver.Connected; } }

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
        public bool Disconnect() 
        {
            return m_driver.Disconnect();
        }
        public bool Connect()
        {
            try
            {
                return m_driver.Connect();
            }
            catch (Exception ) 
            {
                return false;
            }
        }


        public bool SendCommandToDevice(String command) 
        {
            try
            {
                if (m_driver.Write(command) > 0) 
                {
                    //start a timer                    
                    m_timeouttimer.Enabled = true;
                    return true;
                }                                
                return false;
            }
            catch (Exception) 
            {
                return false;
            }
        }
    }
}
