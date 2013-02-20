using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer
{
    /*
     This class holds some basic information about the printer's machine configuration
     * such as:
     * DLP resolution
     * Build Platform Width/Height/Length(Z)
     * calculated x/y dpi (or dpmm)
     * 
     */
    public class MachineConfig
    {
        public  double m_XDLPRes; // the X resolution of the DLP projector in pixels
        public  double m_YDLPRes; // the Y resolution of the DLP projector in pixels
        public double m_PlatXSize; // the X size of the build platform in mm
        public double m_PlatYSize; // the Y size of the build platform in mm
        public double m_PlatZSize; // the Z size of the Z axis length in mm
        private double m_Xpixpermm; // the calculated pixels per mm
        private double m_Ypixpermm; // the calculated pixels per mm
        public double m_ZMaxFeedrate;// in mm/min 
        public string m_monitorid; // which monitor we're using

        public DeviceDriverConfig m_driverconfig;

        public bool Load(string filename) 
        {
            try
            {
                bool retval = false;
                XmlReader xr = XmlReader.Create(filename);
                xr.ReadStartElement("MachineConfig");
                m_XDLPRes = double.Parse(xr.ReadElementString("DLP_X_Res"));
                m_YDLPRes = double.Parse(xr.ReadElementString("DLP_Y_Res"));
                m_PlatXSize = double.Parse(xr.ReadElementString("PlatformXSize"));
                m_PlatYSize = double.Parse(xr.ReadElementString("PlatformYSize"));
                m_PlatZSize = double.Parse(xr.ReadElementString("PlatformZSize"));
                m_Xpixpermm = double.Parse(xr.ReadElementString("PixPermmX"));
                m_Ypixpermm = double.Parse(xr.ReadElementString("PixPermmY"));
                m_ZMaxFeedrate = double.Parse(xr.ReadElementString("MaxZFeedRate"));
                m_monitorid = xr.ReadElementString("MonitorID");

                if (m_driverconfig.Load(xr))
                {
                    retval = true;
                }
                xr.ReadEndElement();
                xr.Close();
                return retval;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        public bool Save(string filename)
        {
            try
            {
                bool retval = false;
                XmlWriter xw = XmlWriter.Create(filename);
                xw.WriteStartDocument();
                    xw.WriteStartElement("MachineConfig");
                        xw.WriteElementString("DLP_X_Res", m_XDLPRes.ToString());
                        xw.WriteElementString("DLP_Y_Res", m_YDLPRes.ToString());
                        xw.WriteElementString("PlatformXSize", m_PlatXSize.ToString());
                        xw.WriteElementString("PlatformYSize", m_PlatYSize.ToString());
                        xw.WriteElementString("PlatformZSize", m_PlatZSize.ToString());
                        xw.WriteElementString("PixPermmX", m_Xpixpermm.ToString());
                        xw.WriteElementString("PixPermmY", m_Ypixpermm.ToString());
                        xw.WriteElementString("MaxZFeedRate", m_ZMaxFeedrate.ToString());
                        xw.WriteElementString("MonitorID", m_monitorid.ToString());
                        if (m_driverconfig.Save(xw))
                        {
                            retval = true;
                        }
                    xw.WriteEndElement();
                xw.WriteEndDocument();
                xw.Close();
                return retval;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        public MachineConfig() 
        {
            m_XDLPRes = 1024;
            m_YDLPRes = 768;            
            m_PlatXSize = 102.0;
            m_PlatYSize = 77.0;
            m_PlatZSize = 100; // 100 mm default, we have to load this
            m_ZMaxFeedrate = 100;
            m_monitorid = "";
            CalcPixPerMM();
            m_driverconfig = new DeviceDriverConfig();
            
        }

        private void CalcPixPerMM() 
        {
            m_Xpixpermm = m_XDLPRes / m_PlatXSize;
            m_Ypixpermm = m_YDLPRes / m_PlatYSize;

        }
        public void SetDLPRes(double xres, double yres)
        {
            m_XDLPRes = xres;
            m_YDLPRes = yres;
            CalcPixPerMM();
        }

        public void SetPlatSize(double xsz, double ysz)
        {
            m_PlatXSize = xsz;
            m_PlatYSize = ysz;
            CalcPixPerMM();
        }

        public double PixPerMMX { get { return m_Xpixpermm; } }
        public double PixPerMMY { get { return m_Ypixpermm; } }
        public int XRes { get { return (int)m_XDLPRes; } }
        public int YRes { get { return (int)m_YDLPRes; } }
    }
}
