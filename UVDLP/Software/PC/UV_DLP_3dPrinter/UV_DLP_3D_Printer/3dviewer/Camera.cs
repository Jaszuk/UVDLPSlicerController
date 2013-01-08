using System;
using System.Collections.Generic;
using System.Text;
using Engine3D;
namespace Engine3D
{
    public enum eProjectType 
    {
        eParallel,
        ePerspective,
    }
    public class Camera
    {
        public Matrix3D viewmat;
        public eProjectType m_protyp = eProjectType.eParallel;
        public double m_scalex, m_scaley;
        public Camera() 
        {
            viewmat = new Matrix3D();
            m_scalex = 22;
            m_scaley = 22;
        }
        public void Reset()
        {
            viewmat.Identity();
            m_scalex = 22;
            m_scaley = 22;
        }
    }
}
