using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace UV_DLP_3D_Printer
{
    public class GCodeFile
    {
        String m_gcode; // the entire file
        String[] m_lines; // the file, one string per line

        public GCodeFile(String gc) 
        {
            m_gcode = gc;
            m_lines = null;
        }
        private void GenerateLines()         
        {
            m_lines = m_gcode.Split('\n'); // split on the newline
        }
        public bool Load(String filename) 
        {
            try
            {
                TextReader tw = File.OpenText(filename);
                m_lines = null;
                m_gcode = tw.ReadToEnd();
                tw.Close();
                m_lines = null;
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
                TextWriter tw = File.CreateText(filename);
                tw.Write(m_gcode);
                tw.Close();
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }            
        }

        public String[] Lines 
        {
            get 
            {
                if (m_lines == null)
                    GenerateLines();
                return m_lines; 
            }
        }
        public String RawGCode 
        {
            get 
            {
                return m_gcode; 
            }
            set 
            {
                m_gcode = value;
                m_lines = null; // clear it so it will be re-generated when needed
            }
        }
    }
}
