using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer
{
    /*
     This class holds some basic information about the printer
     * such as:
     * DLP resolution
     * Build Platform Width/Height/Length(Z)
     * calculated x/y dpi (or dpmm)
     */
    class PrinterInfo
    {
        private double m_XDLPRes; // the X resolution of the DLP projector in pixels
        private double m_YDLPRes; // the Y resolution of the DLP projector in pixels
        private double m_PlatXSize; // the X size of the build platform in mm
        private double m_PlatYSize; // the Y size of the build platform in mm
        private double m_Xpixpermm; // the calculated pixels per mm
        private double m_Ypixpermm; // the calculated pixels per mm

        public PrinterInfo() 
        {
            m_XDLPRes = 1024;
            m_YDLPRes = 768;
            m_PlatXSize = 102.0;
            m_PlatYSize = 77.0;
            CalcPixPerMM();
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
