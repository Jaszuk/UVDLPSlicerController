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
         GCode Process for building 3d DVP UV objects
         
         * <Build Start>
         * <Slicing Comments> comments containing the slicing and building parameters
         * <Header Code> start.gcode - commands from this 
         * file are inserted, they contain whatever intiailization sequences are need to initialize the machine
         * at this point, the build tray is in position to start printing a layer
         * <Layer Start>
         * Display the correct image slice for the current layer
         * Delay for <Layertime> to expose the UV resin
         * <Layer End>
         
         
         Example:
         * G1 Z0.05 F10 (move to the layer position .05 mm distance)
         * (<Layer 0 >) (show the slice image layer)
         * (<Delay 1000 >) (pause to expose the layer, first layer time is longer)
         * (<Layer Blank >) (show the blank image layer now)
         * (pre- lift gcode goes here)
         * G1 Z5 F10    (Move up (or down) for the lift sequence)
         * G1 X20 F20   (Move the wiper)
         * G1 X-20 F20  (Move the wiper back)
         * G1 Z5 F10    (Move down (or up) for the lift sequence)
         * (post - lift gcode goes here)
         * (<Delay blanktime >) (the previous commands will all be run, this command will cause the build manager to delay before moving to the next layer)
         
         */

        /*
         This is the main function to generate gcode files for the 
         * already sliced model
         */
        public static GCodeFile Generate(SliceFile sf, MachineConfig pi) 
        {
            String gcode;
            StringBuilder sb = new StringBuilder();
            double zdist = 0.0;
            double feedrate = pi.m_ZMaxFeedrate; // 10mm/min
            double zdir = 1.0; // assume a bottom up machine
            if (sf.m_config.direction == SliceBuildConfig.eBuildDirection.Top_Down) 
            {
                zdir = -1.0;// top down machine, reverse the z direction
            }

            // append the build parameters as reference
            sb.Append(sf.m_config.ToString());
            
            // append the header
            sb.Append(sf.m_config.HeaderCode);

            String firstlayerdelay = "(<Delay> " + sf.m_config.firstlayertime_ms + " )\r\n";
            String layerdelay = "(<Delay> " + sf.m_config.layertime_ms + " )\r\n";
            String blankdelay = "(<Delay> " + sf.m_config.blanktime_ms + " )\r\n";

            zdist = sf.m_config.ZThick;

            for (int c = 0; c < sf.m_slices.Count; c++ )
            {               
                //move the z axis to the right layer position
                sb.Append("G1 Z" + String.Format("{0:0.00000}", (zdist * zdir)) + " F" + feedrate + "\r\n");
                // this is the marker the BuildManager uses to display the correct slice
                sb.Append( "(<Slice> " + c + " )\r\n");
                // add a pause for the UV resin to be set using this image
                if (c == 0)// check for the first layer
                {
                    sb.Append(firstlayerdelay);               
                }
                else 
                {
                    sb.Append(layerdelay);         
                }
                sb.Append("(<Slice> Blank )\r\n"); // show the blank layer
                sb.Append(sf.m_config.PreLiftCode); // append the pre-lift codes
                //do the lift
                sb.Append("G1 Z" + String.Format("{0:0.00000}", (sf.m_config.liftdistance * zdir)) + " F" + feedrate + " (Lift) \r\n");
                sb.Append(sf.m_config.PostLiftCode); // append the post-lift codes
                // move back from the lift
                sb.Append("G1 Z" + String.Format("{0:0.00000}", (sf.m_config.liftdistance * zdir * -1)) + " F" + feedrate + " (End Lift) \r\n");
                // add a delay for the lift sequence and the pre/post lift codes to execute
                sb.Append(blankdelay);
            }
            //append the footer
            sb.Append(sf.m_config.FooterCode);
            gcode = sb.ToString();
            GCodeFile gc = new GCodeFile(gcode);
            return gc;
        }
    }
}
