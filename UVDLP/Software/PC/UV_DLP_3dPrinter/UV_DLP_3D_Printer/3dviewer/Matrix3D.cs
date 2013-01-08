using System;
using System.Collections.Generic;
using System.Text;
using Machine_Controller;
namespace Engine3D
{
    public class Matrix3D
    {
        public double [,] Matrix;

        public Matrix3D() 
        {
            Matrix = new double[4, 4];
            Identity();
        }

        public void Identity ()
        {
            Matrix[0,0] = 1;  Matrix[0,1] = 0;  Matrix[0,2] = 0;  Matrix[0,3] = 0;
            Matrix[1,0] = 0;  Matrix[1,1] = 1;  Matrix[1,2] = 0;  Matrix[1,3] = 0;
            Matrix[2,0] = 0;  Matrix[2,1] = 0;  Matrix[2,2] = 1;  Matrix[2,3] = 0;
            Matrix[3,0] = 0;  Matrix[3,1] = 0;  Matrix[3,2] = 0;  Matrix[3,3] = 1;
        }
        public static void MergeMatrices (ref Matrix3D Dest , Matrix3D Source  )
        {
           // Multiply Source by Dest; store result in Temp:
           double [,] Temp  = new double [ 4 , 4 ];
           for (int i = 0; i < 4; i++)
           {
               for (int j = 0; j < 4; j++)
               {
                   Temp[i, j] = (Source.Matrix[i, 0] * Dest.Matrix[0, j])
                                 + (Source.Matrix[i, 1] * Dest.Matrix[1, j])
                                 + (Source.Matrix[i, 2] * Dest.Matrix[2, j])
                                 + (Source.Matrix[i, 3] * Dest.Matrix[3, j]);
               }
           }
           // Copy Temp to Dest.Matrix:
            for (int i = 0; i < 4; i++)
            {
                Dest.Matrix [ i , 0 ] = Temp [ i , 0 ];
                Dest.Matrix [ i , 1 ] = Temp [ i , 1 ];
                Dest.Matrix [ i , 2 ] = Temp [ i , 2 ];
                Dest.Matrix [ i , 3 ] = Temp [ i , 3 ];
            }

        }
        void MergeMatrix (Matrix3D NewMatrix )
        {
            // Multiply NewMatirx by Matrix; store result in TempMatrix
            double [,] TempMatrix  = new double [ 4 , 4 ];
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    TempMatrix[i, j] = (Matrix[i, 0] * NewMatrix.Matrix[0, j])
                    + (Matrix[i, 1] * NewMatrix.Matrix[1, j])
                    + (Matrix[i, 2] * NewMatrix.Matrix[2, j])
                    + (Matrix[i, 3] * NewMatrix.Matrix[3, j]);
                }
            }

            // Copy TempMatrix to Matrix:
            for (int i = 0; i < 4; i++)
            {
                Matrix[i,0] = TempMatrix[i,0];
                Matrix[i,1] = TempMatrix[i,1];
                Matrix[i,2] = TempMatrix[i,2];
                Matrix[i,3] = TempMatrix[i,3];
            }   
        }
        public void  Rotate ( double Xa, double Ya, double Za )
        {
            Matrix3D Rmat = new Matrix3D();
            Matrix3D RMatrix = new Matrix3D();
            double sinxa = Math.Sin(Xa);
            double cosxa = Math.Cos(Xa);
            double sinza = Math.Sin(Za);
            double cosza = Math.Cos(Za);
            double sinya = Math.Sin(Ya);
            double cosya = Math.Cos(Ya);
            Rmat.Identity();
            RMatrix.Identity();

            // Initialize Z rotation matrix - Note: we perform Z
            // rotation first to align the 3D Z axis with the 2D Z axis.
            Rmat.Matrix[0,0]=cosza;    Rmat.Matrix[0,1]=sinza;    Rmat.Matrix[0,2]=0;    Rmat.Matrix[0,3]=0;
            Rmat.Matrix[1,0]=-sinza;   Rmat.Matrix[1,1]=cosza;    Rmat.Matrix[1,2]=0;    Rmat.Matrix[1,3]=0;
            Rmat.Matrix[2,0]=0;        Rmat.Matrix[2,1]=0;        Rmat.Matrix[2,2]=1;    Rmat.Matrix[2,3]=0;
            Rmat.Matrix[3,0]=0;        Rmat.Matrix[3,1]=0;        Rmat.Matrix[3,2]=0;    Rmat.Matrix[3,3]=1;

            // Merge matrix with master matrix:
            MergeMatrices (ref RMatrix, Rmat );

            // Initialize X rotation matrix:
            Rmat.Matrix[0,0]=1;  Rmat.Matrix[0,1]=0;        Rmat.Matrix[0,2]=0;       Rmat.Matrix[0,3]=0;
            Rmat.Matrix[1,0]=0;  Rmat.Matrix[1,1]=cosxa;    Rmat.Matrix[1,2]=sinxa;   Rmat.Matrix[1,3]=0;
            Rmat.Matrix[2,0]=0;  Rmat.Matrix[2,1]=-sinxa;   Rmat.Matrix[2,2]=cosxa;   Rmat.Matrix[2,3]=0;
            Rmat.Matrix[3,0]=0;  Rmat.Matrix[3,1]=0;        Rmat.Matrix[3,2]=0;       Rmat.Matrix[3,3]=1;

            // Merge matrix with master matrix:
            MergeMatrices(ref RMatrix, Rmat);

            // Initialize Y rotation matrix:
            Rmat.Matrix[0,0]=cosya;   Rmat.Matrix[0,1]=0;   Rmat.Matrix[0,2]=-sinya;   Rmat.Matrix[0,3]=0;
            Rmat.Matrix[1,0]=0;       Rmat.Matrix[1,1]=1;   Rmat.Matrix[1,2]=0;        Rmat.Matrix[1,3]=0;
            Rmat.Matrix[2,0]=sinya;   Rmat.Matrix[2,1]=0;   Rmat.Matrix[2,2]=cosya;    Rmat.Matrix[2,3]=0;
            Rmat.Matrix[3,0]=0;       Rmat.Matrix[3,1]=0;   Rmat.Matrix[3,2]=0;        Rmat.Matrix[3,3]=1;

            // Merge matrix with master matrix:
            MergeMatrices (ref RMatrix, Rmat );

            MergeMatrix ( RMatrix ); // now merge with this one.

        }
        public void Translate ( double Xt, double Yt, double Zt )
        {
            // Create 3D translation matrix:

            // Declare translation matrix:
            Matrix3D  Tmat  = new Matrix3D ();

            // Initialize translation matrix:
            Tmat.Matrix[0,0]=1;  Tmat.Matrix[0,1]=0;  Tmat.Matrix[0,2]=0;  Tmat.Matrix[0,3]=0;
            Tmat.Matrix[1,0]=0;  Tmat.Matrix[1,1]=1;  Tmat.Matrix[1,2]=0;  Tmat.Matrix[1,3]=0;
            Tmat.Matrix[2,0]=0;  Tmat.Matrix[2,1]=0;  Tmat.Matrix[2,2]=1;  Tmat.Matrix[2,3]=0;
            Tmat.Matrix[3,0]=Xt; Tmat.Matrix[3,1]=Yt; Tmat.Matrix[3,2]=Zt; Tmat.Matrix[3,3]=1;

            // Merge matrix with master matrix:
            MergeMatrix ( Tmat );
        }
        public Point3d Transform(Point3d V)
        {
            Point3d pnt = new Point3d();
	        pnt.x = ( ( V.x * Matrix [ 0 , 0 ]) )
                  + ( ( V.y * Matrix [ 1 , 0 ]) )
                  + ( ( V.z * Matrix [ 2 , 0 ]) )
                  + Matrix [ 3 , 0 ];
            
            pnt.y = ( ( V.x * Matrix [ 0 , 1 ]) )
                  + ( ( V.y * Matrix [ 1 , 1 ]) )
                  + ( ( V.z * Matrix [ 2 , 1 ]) )
                  + Matrix [ 3 , 1 ];
            pnt.z = ( ( V.x * Matrix [ 0 , 2] ) )
                  + ( ( V.y * Matrix [ 1 , 2 ]) )
                  + ( ( V.z * Matrix [ 2 , 2 ]) )
                  + Matrix [ 3 , 2 ];

            return pnt;
        }
    }
}
