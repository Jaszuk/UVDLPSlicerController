using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using Engine3D;
using Machine_Controller;

namespace Engine3D
{
    public class PolyLine3d
    {
        private ArrayList m_points; // world coordinate points
        public Color m_color;
        public PolyLine3d(Point3d p1, Point3d p2, Color clr) 
        {
            m_points = new ArrayList();
            m_color = clr;
            m_points.Add(p1);
            m_points.Add(p2);
        }
        public PolyLine3d() 
        {
            m_points = new ArrayList();
            m_color = Color.Blue;
        }
        
        public void AddPoint(Point3d pnt) 
        {
            m_points.Add(pnt);
        }
        public void Render(Camera cam, PaintEventArgs ev,int wid, int hei) 
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
                        foreach (Point3d pnt in m_campnts)
                        {
                            line[idx].X = (int)((cam.m_scalex * pnt.x) + (wid / 2)); // need to add x and y offsets
                            line[idx].Y = (int)((cam.m_scaley * pnt.y) + (hei / 2)); // need to add x and y offsets
                            idx++;
                        }
                    }
                    Pen pen = new Pen(m_color, 2);
                    ev.Graphics.DrawLines(pen, line);
                }
            }
            catch (Exception) { }
        }
    }
}
