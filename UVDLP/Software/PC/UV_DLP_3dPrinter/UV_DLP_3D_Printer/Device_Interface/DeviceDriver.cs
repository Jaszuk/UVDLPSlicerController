using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.IO.Ports;
using System.Timers;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.Drivers
{
    /*
     This is a base class for a generic device driver class used to communicate with the printer
     * or whatever device we're talking with.
     */
    public enum eDriverType
    {
        eNULL_DRIVER, // the driver for testing when a mavchine is not connected, it always returns OK
        eGENERIC, // whatever class of driver you call this, I've been using sailfish, and it seems to work great
    }
    public enum eDeviceStatus 
    {
        eConnect, // when the device connects, this event is raised
        eDisconnect, // when the device disconnect function is called, this is raised
        eError, //when an error occurs reading or writing, this occurs
        // timeout happens at the device interface level
    }
    
    public abstract class DeviceDriver
    {
        public delegate void DeviceStatusEvent(DeviceDriver device, eDeviceStatus status);
        public delegate void DataReceivedEvent(DeviceDriver device, byte[] data, int length);
        protected bool m_connected = false;
        protected SerialPort m_serialport;
        protected eDriverType m_drivertype;
        public DataReceivedEvent DataReceived; // a delegate to notify when data is received
        public DeviceStatusEvent DeviceStatus;
        protected ConnectionConfig m_config; // the serial port configuration
        protected byte[] m_buffer;

        protected DeviceDriver() 
        {
            m_serialport = new SerialPort();
            m_buffer = new byte[8192];

            m_serialport.DataReceived += new SerialDataReceivedEventHandler(m_serialport_DataReceived);
        }

        void m_serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            int read = m_serialport.Read(m_buffer, 0, m_serialport.BytesToRead);
            RaiseDataReceivedEvent(this, m_buffer, read);
        }

        public bool Connected { get { return m_connected; } }
        protected void RaiseDeviceStatus(DeviceDriver device,eDeviceStatus status) 
        {
            if (DeviceStatus != null) 
            {
                DeviceStatus(device,status);
            }
        }
        protected void RaiseDataReceivedEvent(DeviceDriver device, byte[] data, int length) 
        {
            if (DataReceived != null) 
            {
                DataReceived(device, data, length);
            }
        }

        public abstract bool Connect();
        public abstract bool Disconnect();
        public abstract int Write(byte[] data, int len);
        public abstract int Write(String line);
        public void Configure(ConnectionConfig cc) 
        {
            m_config = cc;
            m_serialport.BaudRate = cc.speed;
            m_serialport.DataBits = cc.databits;
            m_serialport.Parity = cc.parity;
            m_serialport.Handshake = cc.handshake;
            m_serialport.PortName = cc.comname;
        }
    }
}
