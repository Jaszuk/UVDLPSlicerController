using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Drawing;

namespace UV_DLP_3D_Printer.Slicing
{
    /*
     * This class represents an object that has been completely sliced.
     * It contains the initial build and slicing parameters used to create the file
     * This file should be all that is necessary (along with GCode) to display slices
     * or to build the object
     */
    public class SliceFile
    {
        public SliceBuildConfig m_config;
        public ArrayList m_slices; // list of Slices

        public SliceFile() 
        {
            m_config = new SliceBuildConfig(); // going to be loaded
            m_slices = new ArrayList();
        }
        // constructor that the slicer calls to create
        public SliceFile(SliceBuildConfig config) 
        {
            m_config = new SliceBuildConfig(config); // copy the source
            m_slices = new ArrayList();
        }
        /*
         This function does the rasterization of the generated slice into
         * a 2d bitmap that can be displayed and sent to the machine's DLP
         */
        public Bitmap RenderSlice(int layer) // 0 based index
        {
            try
            {
                Slice slice = (Slice)m_slices[layer];
                return slice.RenderSlice(m_config);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return null;
            }
        }
    }
}
