using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO.Ports;

namespace UV_DLP_3D_Printer.Configs
{
    public class ConnectionConfig
    {
        public String comname;
        public int speed;
        public int databits; // 8
        public Parity parity;
        public StopBits stopbits;
        public Handshake handshake;

        public ConnectionConfig() 
        {

        }

        public void CreateDefault() 
        {
            comname = "Com1";
            speed = 115200;
            databits = 8;
            parity = Parity.None;            
            stopbits = StopBits.One;
        
        }
        public bool Load(XmlReader xr) 
        {
            try
            {
                xr.ReadStartElement("ComPortSettings");
                    comname = xr.ReadElementString("PortName");
                    speed = int.Parse(xr.ReadElementString("Speed"));
                    parity = (Parity)Enum.Parse(typeof(Parity), xr.ReadElementString("Parity"));
                    stopbits = (StopBits)Enum.Parse(typeof(StopBits), xr.ReadElementString("Stopbits"));
                    handshake = (Handshake)Enum.Parse(typeof(Handshake), xr.ReadElementString("Handshake"));
                    xr.ReadEndElement();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
            
        }

        public bool Save(XmlWriter xw)
        {
            try
            {
                xw.WriteStartElement("ComPortSettings");
                    xw.WriteElementString("PortName", comname);
                    xw.WriteElementString("Speed", speed.ToString());
                    xw.WriteElementString("DataBits", databits.ToString());
                    xw.WriteElementString("Parity", parity.ToString());
                    xw.WriteElementString("Stopbits", stopbits.ToString());
                    xw.WriteElementString("Handshake", handshake.ToString());
                xw.WriteEndElement();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
    }
}
