using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Xml;
using UV_DLP_3D_Printer.Drivers;

namespace UV_DLP_3D_Printer.Configs
{
    public class DeviceDriverConfig
    {
        public eDriverType m_drivertype;
        public ConnectionConfig m_connection;

        public DeviceDriverConfig() 
        {
            m_drivertype = eDriverType.eNULL_DRIVER; // default to a null driver
            m_connection = new ConnectionConfig();
            m_connection.CreateDefault();
        }

        public bool Load(XmlReader xr)
        {
            try
            {
                bool retval = false;
                xr.ReadStartElement("DriverConfig");
                    m_drivertype = (eDriverType)Enum.Parse(typeof(eDriverType), xr.ReadElementString("DriverType"));
                    if (m_connection.Load(xr))
                    {
                        retval = true;
                    }
                xr.ReadEndElement();
                return retval;
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
                bool retval = false;
                xw.WriteStartElement("DriverConfig");
                    xw.WriteElementString("DriverType", m_drivertype.ToString());
                    if (m_connection.Save(xw))
                    {
                        retval = true;
                    }
                xw.WriteEndElement();
                return retval;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }        

    }
}
