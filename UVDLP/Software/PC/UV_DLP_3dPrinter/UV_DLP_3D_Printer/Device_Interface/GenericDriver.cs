using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Drivers
{
    public class GenericDriver : DeviceDriver
    {
        public GenericDriver() 
        {
            m_drivertype = eDriverType.eGENERIC;
        }
        public override bool Connect() { return false; }
        public override bool Disconnect() { return false; }
        public override int Write(byte[] data, int len) { return -1; }
        public override int Write(String line) { return -1; }
    }
}
