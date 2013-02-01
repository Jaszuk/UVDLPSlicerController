using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace UV_DLP_3D_Printer
{
    public static class Utility
    {
        public static bool CreateDirectory(String path) 
        {
            try
            {
                Directory.CreateDirectory(path);
                return true;
            }
            catch (Exception ex) 
            {
                return false;
            }
        }
    }
}
