using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using Machine_Controller;
using System.IO;
namespace Engine3D
{
    public class Object3d
    {
        private ArrayList m_lstpoints; // list of 3d points in object
        private ArrayList m_lstpolys;// list of polygons
        private string m_name;
        private bool m_visible;
        public Object3d() 
        {
            m_lstpolys = new ArrayList();
            m_lstpoints = new ArrayList();
            m_name = "Model";
            m_visible = true;
        }
        public string Name { get { return m_name; } }
        
        public bool Visible 
        {
            get { return m_visible; }
            set {  m_visible = value; }
        }
        public void Render(Camera cam, PaintEventArgs ev, int wid, int hei)
        {
            //transform the centers
            /*
            foreach (Polygon poly in m_lstpolys) 
            {
                poly.m_centercamera = cam.viewmat.Transform(poly.m_center);
            }
            //sort them
            IComparer cmp = new Polygon();
            m_lstpolys.Sort(cmp);
            */
            foreach (Polygon poly in m_lstpolys) 
            {
                poly.Render(cam, ev, wid, hei);
            }
        }
        private Point3d AddUniqueVert(Point3d pnt) 
        {
            foreach (Point3d p in m_lstpoints) 
            {
                if (pnt.x == p.x && pnt.y == p.y && pnt.z == p.z) return pnt;
            }
            m_lstpoints.Add(pnt);
            return pnt;
        }
        private void LoadDXFPolyPoints(out Point3d[] pnts, StreamReader sr) 
        {
            ArrayList lst = new ArrayList();
            bool done = false;
            Point3d pnt = null;
            while (!done) 
            {
                string line = sr.ReadLine();
                line = line.Trim();
                
                if (line == "10" || line == "11" || line == "12" || line == "13")
                {
                    pnt = new Point3d();
                    lst.Add(pnt);
                    pnt.x = double.Parse(sr.ReadLine());
                }
                if (line == "20" || line == "21" || line == "22" || line == "23") 
                {
                    pnt.y = double.Parse(sr.ReadLine());
                }
                if (line == "30" || line == "31" || line == "32" || line == "33") 
                {
                    pnt.z = double.Parse(sr.ReadLine());
                }
                if (line == "62") done = true;
            }
            pnts = new Point3d[lst.Count];
            int idx = 0;
            foreach (Point3d p in lst) 
            {
                pnts[idx++] = p;
            }
        
        }
        public bool GenerateFromBitmap(string file, ScaleFactor f) 
        {
            try
            {
                m_name = Path.GetFileName(file);
                Bitmap bm = new Bitmap(file);
                // add 3d points
                for (int y = 0; y < bm.Height; y++) 
                {
                    for (int x = 0; x < bm.Width; x++) 
                    {
                        Color clr = bm.GetPixel(x, y);
                        Point3d pnt = new Point3d();
                        pnt.x = f.x * ((double)x);
                        pnt.y = f.y * ((double)y);
                        pnt.z = f.z * ((double)clr.R);
                        m_lstpoints.Add(pnt);
                    }
                }
                // now generate polys
                for (int y = 0; y < bm.Height  ; y++)
                {
                    for (int x = 0; x < bm.Width ; x++)
                    {
                        if (y == (bm.Height - 1)) continue;
                        if (x == (bm.Width - 1)) continue;
                        Polygon ply = new Polygon();
                        ply.m_points = new Point3d[3];
                        int idx1 = (y * bm.Width) + x;
                        int idx2 = (y * bm.Width) + x + 1;
                        int idx3 = (y * bm.Width) + x + bm.Width ;
                        ply.m_points[0] = (Point3d)m_lstpoints[idx1];
                        ply.m_points[1] = (Point3d)m_lstpoints[idx2];
                        ply.m_points[2] = (Point3d)m_lstpoints[idx3];
                        ply.CalcCenter();
                        ply.CalcNormal();
                        m_lstpolys.Add(ply);
                        
                       
                        Polygon ply2 = new Polygon();
                        ply2.m_points = new Point3d[3];
                        idx1 = (y * bm.Width) + x + 1;
                        idx2 = (y * bm.Width) + x + bm.Width + 1;
                        idx3 = (y * bm.Width) + x + bm.Width;
                        ply2.m_points[0] = (Point3d)m_lstpoints[idx1];
                        ply2.m_points[1] = (Point3d)m_lstpoints[idx2];
                        ply2.m_points[2] = (Point3d)m_lstpoints[idx3];

                        ply2.CalcCenter();
                        ply2.CalcNormal();
                        m_lstpolys.Add(ply2);
                         
                    }
                }
                return true;
            }
            catch (Exception) 
            {
                return false;
            }
        }
        /// <summary>
        /// This function loads an ascii STL file
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public bool LoadSTL_ASCII(string filename) 
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                m_name = Path.GetFileName(filename);
                //first line should be "solid <name> " 
                string line = sr.ReadLine();
                string []toks = line.Split(' ');
                if (!toks[0].ToLower().StartsWith("solid"))
                    return false; // does not start with "solid"
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine().Trim();
                    if (line.ToLower().StartsWith("facet"))
                    {
                        line = sr.ReadLine().Trim();//outerloop
                        Polygon poly = new Polygon();//create a new polygon
                        m_lstpolys.Add(poly); // add it to the polygon list
                        poly.m_points = new Point3d[3]; // create the storage
                        
                        for (int idx = 0; idx < 3; idx++)//read the point
                        {
                            Point3d tmp = new Point3d(); // create a temp point
                            char[] delimiters = new char[] {' '};
                            line = sr.ReadLine().Trim();//outerloop
                            toks = line.Split(delimiters,StringSplitOptions.RemoveEmptyEntries);
                            tmp.x = float.Parse(toks[1]);
                            tmp.y = float.Parse(toks[2]);
                            tmp.z = float.Parse(toks[3]);
                            poly.m_points[idx] = AddUniqueVert(tmp);
                        }

                        poly.CalcNormal();
                        poly.CalcCenter();
                        line = sr.ReadLine().Trim();//endloop
                    }
                }
                sr.Close();
            }
            catch (Exception ex) 
            {
                return false;
            }
            
            return true;
        }
        public bool LoadDXF(string filename) 
        {
            try
            {
                StreamReader sr = new StreamReader(filename);
                m_name = Path.GetFileName(filename);
                while (!sr.EndOfStream) 
                {
                    string line = sr.ReadLine();
                    line = line.Trim();
                    if (line == "3DFACE") 
                    {                        
                        Polygon poly = new Polygon();//create a new polygon
                        m_lstpolys.Add(poly); // add it to the polygon list
                        Point3d []pnts;
                        LoadDXFPolyPoints(out pnts, sr);
                        poly.m_points = new Point3d[pnts.Length]; // create the storage
                        int idx = 0;
                        foreach(Point3d p in pnts)
                        {
                            poly.m_points[idx++] = AddUniqueVert(p);
                        }
                        poly.CalcNormal();
                        poly.CalcCenter();
                    }
                }
                sr.Close();
                return true;
            }catch( Exception)
            {
                return false;            
            }
        }
    }
}
