using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UV_DLP_3D_Printer.Slicing;
namespace UV_DLP_3D_Printer
{
    public class GCodeGenerator
    {
        private GCodeGenerator() 
        {
        }

        /*
         This is the main function to generate gcode files for the 
         * already sliced model
         */
        public static GCodeFile Generate(SliceFile sf, MachineConfig pi) 
        {
            String gcode;
            StringBuilder sb = new StringBuilder();
            double zpos = 0.0;
            double feedrate = pi.m_ZMaxFeedrate; // 1000mm/min

            // append the header
            sb.Append(sf.m_config.HeaderCode);
            // append the build parameters as reference
            sb.Append(sf.m_config.ToString());
            //home to the z axis max at the max feed rate
            /*
            sb.Append("G28 Z (Home to Z axis Maximum)\r\n");            
            //set the zposition to be the maximum axis length
            sb.Append("G92 Z" + pi.m_PlatZSize + " ( set the Z Position to be the maximum axis length) \r\n");            
            //move to the first layer position
            sb.Append("G1 Z" + sf.m_config.ZThick + " (move to the first layer position)\r\n");
            sb.Append("M109 S" + sf.m_config.plat_temp + "(Set Platform Temp for UV Resin)\r\n");
            */
            
            for (int c = 0; c < sf.m_slices.Count; c++ )
            {
                
                String layermark = "";
                String timedelay = "";
                if (c == 0)
                {
                    timedelay = "(<Delay> " + sf.m_config.firstlayertime_ms + ")\r\n";
                }
                else 
                {
                    timedelay = "(<Delay> " + sf.m_config.layertime_ms + ")\r\n";
                }
                
                sb.Append(sf.m_config.PreSliceCode);
                //move the z axis to the right layer position
                //sb.Append("G1 Z" + String.Format("{0:0.00000}",zpos) + " F" + feedrate + " (Move Z axis to position)\r\n");
                sb.Append("G1 Z" + String.Format("{0:0.00000}", sf.m_config.ZThick) + " F" + feedrate + "\r\n");
                sb.Append(sf.m_config.PostSliceCode);
                //increment the z layer absoulte position to the next layer position
                zpos += sf.m_config.ZThick;
                // this is the marker the PrintManager uses to display the correct slice
                layermark =  "(<Slice> " + c + " )\r\n";
                sb.Append(layermark);
                //sb.Append(PerSliceCode);
                // add a pause for the duration
                sb.Append(timedelay);               
            }
            //append the footer
            sb.Append(sf.m_config.FooterCode);
            gcode = sb.ToString();
            GCodeFile gc = new GCodeFile(gcode);
            return gc;
        }
    }
}
