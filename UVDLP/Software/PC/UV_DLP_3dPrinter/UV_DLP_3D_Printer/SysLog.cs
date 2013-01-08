using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer
{
    public delegate void LogMessage(String message,int level);
    class SysLog
    {
        private static SysLog m_instance = null;
        public LogMessage LogMSG;

        private SysLog() 
        {
        
        }

        public static SysLog Instance() 
        {
            if (m_instance == null) 
            {
                m_instance = new SysLog();
            }
            return m_instance;
        }

        public void Log(String message) 
        {
            Log(message, 0);
        }

        public void Log(String message, int level) 
        {
            // prepend a date/time stamp
            //DateTime MyDateTime = new DateTime();
            String MyString;
            MyString = DateTime.Now.ToString("HH:mm:ss");
            if (LogMSG != null) 
            {
                LogMSG(MyString + " " + message,level);
            }
        }
        
    }
}
