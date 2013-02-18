using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using UV_DLP_3D_Printer;
using System.Collections;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;


namespace Engine3D
{
    public class Polygon : IComparer
    {
        public Vector3d m_normal;
        public Point3d m_center;
        public Point3d m_centercamera; // transformed into camera space
        public Color m_color;
        public Color m_linecolor;
        public Point3d[] m_points; // points in poly, also contained in parent objects points list 
        public bool m_solid; // draw it solid
        public bool m_wire;// draw wireframe
        

        public Polygon() 
        {
            m_normal = new Vector3d();
            m_color = Color.Gray;
            m_linecolor = Color.Blue;
            m_solid = true;
            m_wire = true;
            m_center = new Point3d();
        }
        public void CalcNormal() 
        {
            double Ax, Ay, Az;
            double Bx, By, Bz;
            Ax = m_points[1].x - m_points[0].x;
            Ay = m_points[1].y - m_points[0].y;
            Az = m_points[1].z - m_points[0].z;
            Bx = m_points[2].x - m_points[0].x;
            By = m_points[2].y - m_points[0].y;
            Bz = m_points[2].z - m_points[0].z;        
   
            double Nx = (Ay * Bz) - (Az * By);
            double Ny = (Az * Bx) - (Ax * Bz);
            double Nz = (Ax * By) - (Ay * Bx);
            m_normal.x = Nx;
            m_normal.y = Ny;
            m_normal.z = Nz;
            double length = Math.Sqrt((m_normal.x * m_normal.x) + (m_normal.y * m_normal.y) + (m_normal.z * m_normal.z));
            m_normal.x /= length;
            m_normal.y /= length;
            m_normal.z /= length;

        }
        public PolyLine3d IntersectZPlane(double zcur)
        {
            try
            {
                PolyLine3d segment = new PolyLine3d();
                //Intersect the polygon with the specified Z-Plane 
                // this will return 0,1,2 intersections.
                // using the returns, impose several rules
                

                //iterate through the poly vertices
                // to create 3d line segments
               // foreach (Point3d p3d in m_points) 
               // {
                    //use a polyline to do the intersections
                    //Since there are only 3d points, this is easier than a loop
                PolyLine3d lineseg1 = new PolyLine3d();
                PolyLine3d lineseg2 = new PolyLine3d();
                PolyLine3d lineseg3 = new PolyLine3d();
                lineseg1.AddPoint(m_points[0]); // 0-1
                lineseg1.AddPoint(m_points[1]);
                lineseg2.AddPoint(m_points[1]); // 1-2
                lineseg2.AddPoint(m_points[2]);
                lineseg3.AddPoint(m_points[2]); // 2-0
                lineseg3.AddPoint(m_points[0]);

                Point3d p1, p2, p3; // intersection points for the 3 3d line segments

                p1 = lineseg1.IntersectZ(zcur);
                p2 = lineseg2.IntersectZ(zcur);
                p3 = lineseg3.IntersectZ(zcur);

                int count = 0;
                Point3d []lst = new Point3d[3];
                if (p1 != null) lst[count++] = p1;
                if (p2 != null) lst[count++] = p2;
                if (p3 != null) lst[count++] = p3;

                if (count == 3) 
                {
                    //co-planer
                    return null;
                }

                if (count != 2) 
                    return null;

                segment.AddPoint(lst[0]);
                segment.AddPoint(lst[1]);
                segment.m_color = Color.Red;
                return segment;
            }
            catch (Exception) 
            {
                return null;
            }
        }

        public MinMax CalcMinMax() 
        {
            MinMax mm = new MinMax();
            mm.m_min = m_points[0].z;
            mm.m_max = m_points[0].z;

            foreach (Point3d pnt in m_points)
            {
                if (pnt.z > mm.m_max)
                    mm.m_max = pnt.z;

                if (pnt.z < mm.m_min)
                    mm.m_min = pnt.z;

            }
            return mm;
        }
        public void CalcCenter() 
        {
            m_center.Set(0, 0, 0,0);
            foreach (Point3d pnt in m_points)
            {
                m_center.x += pnt.x;
                m_center.y += pnt.y;
                m_center.z += pnt.z;
            }
            m_center.x /= m_points.Length; // number of points
            m_center.y /= m_points.Length; // number of points
            m_center.z /= m_points.Length; // number of points
        }

        int IComparer.Compare(Object pFirstObject, Object pObjectToCompare)
        {
            Polygon p1 = (Polygon)pFirstObject;
            Polygon p2 = (Polygon)pObjectToCompare;
            if (p1.m_centercamera.z > p2.m_centercamera.z) return 1;
            if (p1.m_centercamera.z < p2.m_centercamera.z) return -1;
            return 0;
        }

        public void RenderGL(bool wireframe) 
        {
            if (wireframe)
            {

                GL.Begin(BeginMode.LineStrip);
                GL.LineWidth(1);
            }else
            {
                GL.Begin(BeginMode.Triangles);
            }
            //GL.Color3(m_color);
            //GL.Color4((byte)m_color.R, (byte)m_color.G, (byte)m_color.B, (byte)128);
            //GL.Color4((byte)m_color.R, (byte)m_color.G, (byte)m_color.B, (byte)128);
            GL.Color4(Color.FromArgb(50, 128, 128, 128));
            GL.Normal3(m_normal.x, m_normal.y, m_normal.z);
            foreach (Point3d p in this.m_points)
            {
               
                GL.Vertex3(p.x, p.y, p.z);
            }
            GL.End();            
        }

        public void Render(Camera cam, PaintEventArgs ev, int wid, int hei)
        {
            try
            {
                ArrayList m_campnts = new ArrayList();
                //transform this from world to camera coordinates
                //project
                // then draw
                foreach (Point3d pnt in m_points)
                {
                    Point3d p = cam.viewmat.Transform(pnt);
                    m_campnts.Add(p);
                }
                if (m_campnts.Count > 1)
                {
                    Point[] line = new Point[m_campnts.Count];
                    if (cam.m_protyp == eProjectType.eParallel)
                    {
                        int idx = 0;
                        Point first = new Point();
                        foreach (Point3d pnt in m_campnts)
                        {
                            line[idx].X = (int)((cam.m_scalex * pnt.x) + (wid / 2)); // need to add x and y offsets
                            line[idx].Y = (int)((cam.m_scaley * pnt.y) + (hei / 2)); // need to add x and y offsets
                            if (idx == 0)
                            {
                                first.X = line[idx].X;
                                first.Y = line[idx].Y;
                            }
                            idx++;
                        }
                        // line[idx].X  = first.X; // add the first on as the last as well to close it up
                        // line[idx].Y = first.Y;
                    }

                    Brush solidbrush = new SolidBrush(m_color);
                    if (m_solid == true)
                    {
                        ev.Graphics.FillPolygon(solidbrush, line);

                    }

                    Pen linepen = new Pen(m_linecolor, 2);
                    if (m_wire == true)
                    {
                        ev.Graphics.DrawPolygon(linepen, line);
                        ev.Graphics.DrawLines(linepen, line);
                    }
                }
            }
            catch (Exception) { }
        }

    }
}
