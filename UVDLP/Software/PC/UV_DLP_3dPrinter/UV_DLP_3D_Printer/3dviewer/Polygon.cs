using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using Machine_Controller;
using System.Collections;
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
        public void Render(Camera cam, PaintEventArgs ev, int wid, int hei)
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
                Point[] line = new Point[m_campnts.Count ];
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

    }
}
