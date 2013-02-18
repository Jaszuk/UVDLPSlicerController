using System;
using System.Collections.Generic;
using System.Text;
using Engine3D;

using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;

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
        //This functions sets the camera view to the opengl framework
        public void SetViewGL() 
        {
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadIdentity();
            float[] viewmatrix = new float[16];
            viewmatrix[0] = (float)viewmat.Matrix[0, 0];
            viewmatrix[1] = (float)viewmat.Matrix[1, 0];
            viewmatrix[2] = (float)-viewmat.Matrix[2, 0];
            viewmatrix[3] = (float)0;

            viewmatrix[4] = (float)viewmat.Matrix[0, 1];
            viewmatrix[5] = (float)viewmat.Matrix[1, 1];
            viewmatrix[6] = (float)-viewmat.Matrix[2, 1];
            viewmatrix[7] = (float)0;

            viewmatrix[8] = (float)viewmat.Matrix[0, 2];
            viewmatrix[9] = (float)viewmat.Matrix[1, 2];
            viewmatrix[10] = (float)-viewmat.Matrix[2, 2];
            viewmatrix[11] = (float)0;

            viewmatrix[12] = (float)-(viewmat.Matrix[0, 0] * viewmat.Matrix[3, 0] +
                                      viewmat.Matrix[0,1] * viewmat.Matrix[3,1] +
                                      viewmat.Matrix[0,2] * viewmat.Matrix[3,2]);

            viewmatrix[13] = (float)-(viewmat.Matrix[1, 0] * viewmat.Matrix[3, 0] +
                                      viewmat.Matrix[1, 1] * viewmat.Matrix[3, 1] +
                                      viewmat.Matrix[1, 2] * viewmat.Matrix[3, 2]);


            viewmatrix[14] = (float)-(viewmat.Matrix[2, 0] * viewmat.Matrix[3, 0] +
                                      viewmat.Matrix[2, 1] * viewmat.Matrix[3, 1] +
                                      viewmat.Matrix[2, 2] * viewmat.Matrix[3, 2]);
            
            viewmatrix[15] = (float)1;


            GL.LoadMatrix(viewmatrix);


        }


        /*
void Camera::setView() {
	glMatrixMode(GL_MODELVIEW);
	glLoadIdentity();
	float viewmatrix[16]={//Remove the three - for non-inverted z-axis
						  Transform[0], Transform[4], -Transform[8], 0,  // 0,0 - 1,0  - 2,0   (0,1,2,3)
						  Transform[1], Transform[5], -Transform[9], 0,  // 0,1 - 1,1  - 2,1   (4,5,6,7)
						  Transform[2], Transform[6], -Transform[10], 0, // 0,2 - 1,2  - 2,2   (8,9,10,11)
                                                                                               (12,13,14,16)
						  -(Transform[0]*Transform[12] +    
						  Transform[1]*Transform[13] +
						  Transform[2]*Transform[14]),

						  -(Transform[4]*Transform[12] +
						  Transform[5]*Transform[13] +
						  Transform[6]*Transform[14]),

						  //add a - like above for non-inverted z-axis
						  (Transform[8]*Transform[12] +
						  Transform[9]*Transform[13] +
						  Transform[10]*Transform[14]), 1};
	glLoadMatrixf(viewmatrix);
}         
         */

    }
}
