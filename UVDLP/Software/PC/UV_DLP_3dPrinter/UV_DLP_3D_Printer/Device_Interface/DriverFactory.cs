using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UV_DLP_3D_Printer.Drivers
{
    public class DriverFactory
    {
        public static DeviceDriver Create(eDriverType type) 
        {
            switch (type) 
            {
                case eDriverType.eNULL_DRIVER:
                    return new NULLdriver();
                case eDriverType.eGENERIC:
                    return new GenericDriver();
                default:
                    return null;
            }
        }
    }
}
