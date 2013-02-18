using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;

namespace UV_DLP_3D_Printer
{
    /*
     * The current application configuration
     */
    public class AppConfig
    {
        private String m_LastModelFilename; // the last model loaded
        public string m_cursliceprofilename; // slicing / building profile
        public string m_curmachineeprofilename; // machine profile
        bool m_autoconnect; // autoconnect to the machine
        bool m_loadlastmodel; // load and display the last model

        public void CreateDefault() 
        {
            m_cursliceprofilename = UVDLPApp.Instance().m_PathProfiles + UVDLPApp.m_pathsep + "default.slicing";
            m_curmachineeprofilename = UVDLPApp.Instance().m_PathMachines + UVDLPApp.m_pathsep + "default.machine";
            m_LastModelFilename = "";
            m_loadlastmodel = true;
           // m_drivertype = eDriverType.eNULL_DRIVER;
        }

        public bool Load(String filename) 
        {
            try
            {
                XmlReader xr = XmlReader.Create(filename);
                xr.ReadStartElement("ApplicationConfig");
                
                m_LastModelFilename = xr.ReadElementString("LastModelName");
                m_cursliceprofilename = xr.ReadElementString("SliceProfileName");
                m_curmachineeprofilename = xr.ReadElementString("MachineProfileName");
                m_autoconnect = bool.Parse(xr.ReadElementString("AutoConnect"));
                m_loadlastmodel = bool.Parse(xr.ReadElementString("LoadLastModel"));
                xr.ReadEndElement();
                xr.Close();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }
        }
        public bool Save(String filename) 
        {
            try
            {
                XmlWriter xw = XmlWriter.Create(filename);
                xw.WriteStartElement("ApplicationConfig");
                xw.WriteElementString("LastModelName", m_LastModelFilename);
                xw.WriteElementString("SliceProfileName", m_cursliceprofilename);
                xw.WriteElementString("MachineProfileName", m_curmachineeprofilename);
                xw.WriteElementString("AutoConnect", m_autoconnect?"True":"False");
                xw.WriteElementString("LoadLastModel", m_loadlastmodel ? "True" : "False");
                xw.WriteEndElement();
                xw.Close(); // close the file
                return true;
            }catch(Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false; 
            }
            
        }
        public String LastModelFilename 
        {
            get { return m_LastModelFilename; }
            set { m_LastModelFilename = value; }
        }

        public AppConfig() 
        {
           
        }
    }
}
