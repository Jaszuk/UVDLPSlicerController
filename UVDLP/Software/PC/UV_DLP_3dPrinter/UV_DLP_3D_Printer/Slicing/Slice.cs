
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using Engine3D;
using System.Drawing;
using System.IO;

namespace UV_DLP_3D_Printer
{
    public class Point2d : IComparable
    {
        public int x, y;

        int IComparable.CompareTo(object obj)
        {
            Point2d p = (Point2d)obj;
            if (p.x > x) 
            {
                return -1;
            }
            else if (p.x < x)
            {
                return 1;
            }
            else 
            {
                return 0;
            }
        }

    }
    public class Line2d 
    {
        public Point2d p1, p2;
        public Line2d() 
        {
            p1 = new Point2d();
            p2 = new Point2d();
        }

        public Point2d IntersectY(int ypos) 
        {
            Point2d pnt = new Point2d();
            double minx, maxx;
            double miny, maxy;
            double yp = ypos;
            minx = (double)Math.Min(p1.x, p2.x);
            maxx = (double)Math.Max(p1.x, p2.x);
            miny = (double)Math.Min(p1.y, p2.y);
            maxy = (double)Math.Max(p1.y, p2.y);
            double yrange = maxy - miny;// the range of the x coord
            double scale = (double)((yp - miny) / yrange);
            //pnt.x = (int)LERP(minx, maxx, scale);
            Point2d pmin, pmax;
            if (p1.y < p2.y) // find the point with the min y
            {
                pmin = p1;
                pmax = p2;
            }
            else
            {
                pmin = p2;
                pmax = p1;

            }
            //pnt.x = (int)LERP(p2.x, p1.x, scale); 
            pnt.x = (int)LERP(pmin.x, pmax.x, scale); 
            pnt.y = ypos;
            return pnt;
     
        }
        private static double LERP(double a, double b, double c) { return (double)(((b) - (a)) * (c) + (a)); }
    }
    public class MinMax_XY 
    {
        public int xmin, xmax, ymin, ymax; 
    }
    public class Slice
    {
        public ArrayList m_segments; // list of polyline segments
        
        public Slice()
        {
            m_segments = new ArrayList();
        }
        public bool Load(StreamReader sr) 
        {
            try
            {
                int numplys = int.Parse(sr.ReadLine());
                for (int c = 0; c < numplys; c++) 
                {
                    PolyLine3d pl = new PolyLine3d();
                    pl.Load(sr);
                    m_segments.Add(pl);
                }
                return true;
            }
            catch (Exception ) 
            {
                return false;
            }

        }
        public bool Save(StreamWriter sw) 
        {
            try
            {
                //save number of points
                sw.WriteLine(m_segments.Count);
                foreach (PolyLine3d pl in m_segments) 
                {
                    pl.Save(sw);
                }
                return true;
            }
            catch (Exception ) 
            {
                return false;
            }
        }
        /*
         This function calculates the min and max x/y coordinates of this slice
         */
        public MinMax_XY CalcMinMax_XY(ArrayList lines2d) 
        {
            Line2d l1 = (Line2d)lines2d[0];
            MinMax_XY mm = new MinMax_XY();
            //start the min / max off with some valid values
            mm.xmin = mm.xmax = l1.p1.x;
            mm.ymin = mm.ymax = l1.p1.y;

            foreach (Line2d ln in lines2d) 
            {
                if (ln.p1.x < mm.xmin) mm.xmin = ln.p1.x;
                if (ln.p2.x < mm.xmin) mm.xmin = ln.p2.x;
                if (ln.p1.x > mm.xmax) mm.xmax = ln.p1.x;
                if (ln.p2.x > mm.xmax) mm.xmax = ln.p2.x;

                if (ln.p1.y < mm.ymin) mm.ymin = ln.p1.y;
                if (ln.p2.y < mm.ymin) mm.ymin = ln.p2.y;
                if (ln.p1.y > mm.ymax) mm.ymax = ln.p1.y;
                if (ln.p2.y > mm.ymax) mm.ymax = ln.p2.y;            
            }
            return mm;
        }

        private void Render2dlines(Graphics g, ArrayList lines, SliceBuildConfig sp) 
        {
            Point pnt1 = new Point(); // create some points for drawing
            Point pnt2 = new Point();
            Pen pen = new Pen(Color.White, 1);
            foreach(Line2d ln in lines)
            {
                Point2d p1 = (Point2d)ln.p1;
                Point2d p2 = (Point2d)ln.p2;
                pnt1.X = p1.x + sp.XOffset;
                pnt1.Y = p1.y + sp.YOffset;
                pnt2.X = p2.x + sp.XOffset;
                pnt2.Y = p2.y + sp.YOffset;
                g.DrawLine(pen, pnt1, pnt2);            
            }
        }

        public Bitmap RenderSlice(SliceBuildConfig sp) 
        {
            // create a new bitmap that will be used to draw into
            Bitmap bmp = new Bitmap(sp.xres, sp.yres);
            Graphics graph = Graphics.FromImage(bmp);
            Point pnt1 = new Point(); // create some points for drawing
            Point pnt2 = new Point();
            Pen pen = new Pen(Color.White,1);
            graph.Clear(Color.Black);
            //convert all to 2d lines
            ArrayList lines2d = Get2dLines(sp);
            Render2dlines(graph, lines2d,sp);
            
            // find the x/y min/max
            MinMax_XY mm = CalcMinMax_XY(lines2d);
            // iterate from the ymin to the ymax
            for (int y = mm.ymin; y < mm.ymax; y++) 
            {
                //      get a line of lines that intersect this 2d line
                ArrayList intersecting = GetIntersecting2dYLines(y, lines2d);
                //      get the list of point intersections
                ArrayList points = GetIntersectingPoints(y,intersecting);
                // sort the points in increasing x order
                //SortXIncreasing(points);
                points.Sort();
                //      draw the X-Spans (should be even number)    
                //    For a given pair of intersectin points
                //    (Xi, Y), (Xj, Y)
                //  −> Fill ceiling(Xi) to floor(Xj)
                if (points.Count % 2 == 0)  // is even
                {
                    for (int cnt = 0; cnt < points.Count; cnt += 2)  // increment by 2
                    {
                        Point2d p1 = (Point2d)points[cnt];
                        Point2d p2 = (Point2d)points[cnt+1];
                        pnt1.X = p1.x + sp.XOffset;
                        pnt1.Y = p1.y + sp.YOffset;
                        pnt2.X = p2.x + sp.XOffset;
                        pnt2.Y = p2.y + sp.YOffset;
                        graph.DrawLine(pen, pnt1, pnt2);
                    }
                }
                else  // flag error
                {
                    DebugLogger.Instance().LogRecord("Row y=" + y + " odd # of points = " + points.Count);
                }
            }
             
            return bmp;
        }
        private void SortXIncreasing(ArrayList points) 
        {
            points.Sort();            
        }
        // this function will return a list of 2d point intersections on the specified y line
        private ArrayList GetIntersectingPoints(int ypos, ArrayList lines) 
        {
            ArrayList points = new ArrayList();
            //if the ypos intersects with an endpoint, add it twice, because it must be used twice to make an even number
            foreach (Line2d ln in lines) 
            {
                int ymin = Math.Min(ln.p1.y, ln.p2.y);
                int ymax = Math.Max(ln.p1.y, ln.p2.y);

                if (ln.p1.y == ypos && ln.p2.y == ypos)  // parallel line, both y positions lay on the line, don't add
                {
                    //cn++;
                    points.Add(ln.p1);
                    points.Add(ln.p2);
                }                    
                else if (ln.p1.y == ypos) // point 1 endpoint is on the line,
                {
                    //If the intersection is the ymin of the edge’s
                    //endpoint, count it. Otherwise, don’t
                    if (ln.p1.y == ymin) // if the 
                    {
                        points.Add(ln.p1);
                    }
                    
                }
                else if (ln.p2.y == ypos) // point 2 endpoint is on the line,
                {
                    //If the intersection is the ymin of the edge’s
                    //endpoint, count it. Otherwise, don’t

                    if (ln.p2.y == ymin)
                    {
                        points.Add(ln.p2);
                    }
                }                     
                else // intersect  
                { 
                 
                    Point2d isect = ln.IntersectY(ypos); // singled point of intersection
                    points.Add(isect);
                }
            }
            return points;
        }
        // this function converts all the 3d polyines to 2d lines so we can process everything
        private ArrayList Get2dLines(SliceBuildConfig sp) 
        {
            ArrayList lst = new ArrayList();
            int hxres = sp.xres / 2;
            int hyres = sp.yres / 2;
            foreach (PolyLine3d ply in m_segments) 
            {
                Line2d ln = new Line2d();
                //get the 3d points of the line
                Point3d p3d1 = (Point3d)ply.m_points[0];
                Point3d p3d2 = (Point3d)ply.m_points[1];
                //convert them to 2d (probably should add an offset to center them)
                ln.p1.x = (int)(p3d1.x * sp.dpmmX) + hxres;
                ln.p1.y = (int)(p3d1.y * sp.dpmmY) + hyres;
                ln.p2.x = (int)(p3d2.x * sp.dpmmX) + hxres;
                ln.p2.y = (int)(p3d2.y * sp.dpmmY) + hyres;
                lst.Add(ln);
            }
            return lst; // return the list
        }

        /*
         This function will return a list of lines that intersect with the specified Y scanline
         */
        private ArrayList GetIntersecting2dYLines(int ypos, ArrayList all2dlines) 
        {
            ArrayList intersecting = new ArrayList();
            foreach (Line2d ln in all2dlines) 
            {
                if ((ln.p1.y >= ypos && ln.p2.y <= ypos) || 
                    (ln.p2.y >= ypos && ln.p1.y <= ypos) ||
                    (ln.p2.y == ypos && ln.p1.y == ypos)) 
                {
                    intersecting.Add(ln);
                }
            }
            return intersecting;
        }

        //alright, it looks like I'm going to have to code up a 2d scanline fill algorithm
        // I suppose the first step is to convert all the 3d-ish polyline points in this slice into
        // 2d polylines, then use those to implement the fill


    }
}
