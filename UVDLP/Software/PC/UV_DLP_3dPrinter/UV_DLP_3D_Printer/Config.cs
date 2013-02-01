using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer
{
    /*
     * The current application configuration
     */
    class Config
    {
        private String m_currentworkingdir;
        private bool m_generateGCode;
        private bool m_generateSlices;
        private static Config m_instance = null;
        public static Config Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new Config();
            }
            return m_instance;
        }
        public bool Load() { return false; }
        public bool Save() { return false; }

        public String WorkingDirectory 
        {
            get { return m_currentworkingdir; }
            set { m_currentworkingdir = value; }
        }
        public bool GenerateSlices
        {
            get { return m_generateSlices; }
            set { m_generateSlices = value; }
        }
        public bool GenerateGCode
        {
            get { return m_generateGCode; }
            set { m_generateGCode = value; }
        }
        private Config() 
        {
            WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory;
        }
    }
}
