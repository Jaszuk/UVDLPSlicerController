using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Engine3D;
using Machine_Controller;

namespace Engine3D
{
    public delegate void ModelAdded(Object3d model);
    public delegate void ModelRemoved(Object3d model);
    public class Engine3d
    {
        public Camera m_camera;
        ArrayList m_lines;
        public ArrayList m_objects;
        public event ModelAdded ModelAddedEvent;
        public event ModelRemoved ModelRemovedEvent;

        public Engine3d() 
        {
            m_camera = new Camera();
            m_lines = new ArrayList();
            m_objects = new ArrayList();
            AddGrid();
        }
        public void CameraRotate(double x,double y, double z)
        {
            m_camera.viewmat.Rotate(x, y, z);
        }
        public void CameraMove(Point3d pnt)
        {
            m_camera.viewmat.Translate(pnt.x, pnt.y, pnt.z);
        }
        public void CameraMove(double x,double y, double z)
        {
            m_camera.viewmat.Translate(x,y,z);
        }
        public void CameraReset() 
        {
            m_camera.Reset();
        }
        public void AddGrid() 
        {
            for (int x = -10; x < 11; x += 1)
            {
                AddLine(new PolyLine3d(new Point3d(x, -10, 0, 0), new Point3d(x, 10, 0, 0), Color.Blue));
            }
            for (int y = -10; y < 11; y += 1)
            {
                AddLine(new PolyLine3d(new Point3d(-10, y, 0, 0), new Point3d(10, y, 0, 0), Color.Blue));
            }
            AddLine(new PolyLine3d(new Point3d(0, 0, -10, 0), new Point3d(0, 0, 10, 0), Color.Blue));
        }
        public void AddObject(Object3d obj) 
        {
            m_objects.Add(obj); 
            if (ModelAddedEvent != null)
            {
                ModelAddedEvent(obj);
            }            
        }
        public void RemoveObject(Object3d obj) 
        {
            m_objects.Remove(obj);
            if (ModelRemovedEvent != null)
            {
                ModelRemovedEvent(obj);
            }                 
        }
        public void AddLine(PolyLine3d ply) { m_lines.Add(ply); }

        public void Render(PaintEventArgs e, int wid, int hei) 
        {
            foreach(PolyLine3d ply in m_lines)
            {
                ply.Render(m_camera, e,wid, hei);
            }
            foreach (Object3d obj in m_objects) 
            {
                obj.Render(m_camera, e, wid, hei);
            }
        }
    }
}
