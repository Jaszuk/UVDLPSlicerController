using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Engine3D;
using System.Collections;
using System.Drawing;
namespace UV_DLP_3D_Printer
{
    public class Slicer
    {
        public delegate void LayerSliced(int layer, int totallayers);

        public ArrayList m_slices; // list of Slices
        public LayerSliced Sliced;
        public Slicer() 
        {
            m_slices = new ArrayList();

        }
        public int GetNumberOfSlices(SliceParms sp, Object3d obj) 
        {
            try
            {
                obj.FindMinMax();
                int numslices = (int)((obj.m_max.z - obj.m_min.z) / sp.ZThick);
                return numslices;
            }
            catch (Exception) 
            {
                return 0;
            }
        }
      //  public bool DoSlicing(SliceParms sp, Object3d obj, String outdir) 
      //  {
        //    return false;
      //  }
        // this function takes the object, the slicing parameters,
        // and the output directory. it generates the object slices
        // and saves them in the directory
        public bool Slice(SliceParms sp, Object3d obj, String outdir) 
        {
            try
            {
                m_slices = new ArrayList();
                //iterate 
                //determine the number of slices
                obj.FindMinMax();
                int numslices = (int)((obj.m_max.z - obj.m_min.z) / sp.ZThick);

                double curz = (double)obj.m_min.z;

                for (int c = 0; c < numslices; c++) 
                {
                    //get a list of polygons at this slice z height that intersect
                    ArrayList lstply = GetZPolys(obj, curz);
                    //iterate through all the polygons and generat 2d line segments at this z level
                    ArrayList lstintersections = GetZIntersections(lstply, curz);
                    curz += sp.ZThick;
                    Slice sl = new Slice();
                    sl.m_segments = lstintersections;
                    m_slices.Add(sl);
                    if (Sliced != null) 
                    {
                        Sliced(c, numslices);
                    }
                    //render segments to the bitmap
                   // sl.CalcMinMax_XY();
                }
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
        /*
         This function does the rasterization of the generated slice into
         * a 2d bitmap that can be displayed and sent to the machine's DLP
         */
        public Bitmap RenderSlice(SliceParms sp, Slice slice) 
        {
            return slice.RenderSlice(sp);
        }
        /*
         This function takes in a list of polygons along with a z height.
         * What is returns is an ArrayList of 3d line segments. These line segments correspond
         * to the intersection of a plane through the polygons. Each polygon may return 0 or 1 line intersections 
         * on the 2d XY plane
         */
        public ArrayList GetZIntersections(ArrayList polys,double zcur) 
        {
            try
            {
                ArrayList lstlines = new ArrayList();
                foreach (Polygon poly in polys) 
                {
                    PolyLine3d s3d = poly.IntersectZPlane(zcur);
                    if (s3d != null) 
                    {
                        lstlines.Add(s3d);
                    }
                }
                return lstlines;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        /*
         Return a list of polygons that intersect at this zlevel
         */
        public ArrayList GetZPolys(Object3d obj, double zlev) 
        {
            ArrayList lst = new ArrayList();
            foreach(Polygon p in obj.m_lstpolys)
            {
                //check and see if current z level is between any of the polygons z coords
                MinMax mm = p.CalcMinMax();
                if (mm.InRange(zlev)) 
                {
                    lst.Add(p);
                }
            }
            return lst;
        }
    }
}
