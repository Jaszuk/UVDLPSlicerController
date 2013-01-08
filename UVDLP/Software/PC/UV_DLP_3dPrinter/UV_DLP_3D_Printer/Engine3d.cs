using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using Engine3D;
using UV_DLP_3D_Printer;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
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
            for (int x = -50; x < 51; x += 10)
            {
                AddLine(new PolyLine3d(new Point3d(x, -50, 0, 0), new Point3d(x, 50, 0, 0), Color.Blue));
            }
            for (int y = -50; y < 51; y += 10)
            {
                AddLine(new PolyLine3d(new Point3d(-50, y, 0, 0), new Point3d(50, y, 0, 0), Color.Blue));
            }
            AddLine(new PolyLine3d(new Point3d(0, 0, -10, 0), new Point3d(0, 0, 10, 0), Color.Blue));
        }
        public void RemoveAllObjects() 
        {
            m_objects = new ArrayList();

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
        public void RemoveAllLines() 
        {
            m_lines = new ArrayList();
        }

        public void RenderGL() 
        {
            try
            {
                foreach (Object3d obj in m_objects)
                {
                    GL.Enable(EnableCap.Lighting);
                    GL.Enable(EnableCap.Light0);
                    GL.Disable(EnableCap.LineSmooth);
                    obj.RenderGL();
                }
                foreach (PolyLine3d ply in m_lines)
                {
                    GL.Disable(EnableCap.Lighting);
                    GL.Disable(EnableCap.Light0);
                    GL.Enable(EnableCap.LineSmooth);
                    ply.RenderGL();
                }
            }
            catch (Exception) { }
        }
        public void Render(PaintEventArgs e, int wid, int hei) 
        {

            foreach (Object3d obj in m_objects) 
            {
                obj.Render(m_camera, e, wid, hei);
            }
            foreach (PolyLine3d ply in m_lines)
            {
                ply.Render(m_camera, e, wid, hei);
            }
        }
    }
}
