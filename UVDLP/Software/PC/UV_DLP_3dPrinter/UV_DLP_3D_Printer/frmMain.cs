using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Engine3D;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Platform.Windows;
using System.IO.Ports;
using System.IO;

namespace UV_DLP_3D_Printer
{
    public partial class frmMain : Form
    {
        bool loaded = false;
        Object3d m_obj = null;
        Slicer m_slicer = new Slicer();
        Engine3d m_engine3d = new Engine3d();
        PrintManager m_printmgr = new PrintManager();
        PrinterInterface m_printeriface = new PrinterInterface();
        PrinterInfo m_printerinfo = new PrinterInfo();
        frmDLP m_frmdlp = new frmDLP();
        String m_pathsep = "";
        
        
        private bool lmdown, rmdown;
        private int mdx, mdy;
        float orbitypos = 0;
        float orbitxpos = -40;
        float orbitdist = -200;

        public frmMain()
        {
            InitializeComponent();
            m_engine3d.AddGrid();
            m_engine3d.CameraReset();
            m_slicer.Sliced += new Slicer.LayerSliced(LayerSliced);
            cmdRefreshCom_Click(null,null);
            m_printmgr.PrintStatus += new delPrintStatus(PrintStatus);
            m_printmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            SysLog.Instance().LogMSG += new LogMessage(SysLogger);
            FillMonitors();
            //m_pathsep
            if (RunningPlatform() == Platform.Windows)
            {
                m_pathsep = "\\";
            }
            else 
            {
                m_pathsep = "/";
            }
        }

        public enum Platform
        {
            Windows,
            Linux,
            Mac
        }

        public static Platform RunningPlatform()
        {
            switch (Environment.OSVersion.Platform)
            {
                case PlatformID.Unix:
                    // Well, there are chances MacOSX is reported as Unix instead of MacOSX.
                    // Instead of platform check, we'll do a feature checks (Mac specific root folders)
                    if (Directory.Exists("/Applications")
                        & Directory.Exists("/System")
                        & Directory.Exists("/Users")
                        & Directory.Exists("/Volumes"))
                        return Platform.Mac;
                    else
                        return Platform.Linux;

                case PlatformID.MacOSX:
                    return Platform.Mac;

                default:
                    return Platform.Windows;
            }
        }
        /*
         This handler gets called whenever something in the system 
         * logs a message
         */
        void SysLogger(String message,int level) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SysLogger(message, level); }));
            }
            else
            {
                txtLog.Text = message + "\r\n" + txtLog.Text;
            }
        }
        /*void MyMethod1b(int a, int b){
  if (this.InvokeRequired)    {        
    // Reinvoke the same method if necessary        
    BeginInvoke(new MethodInvoker(delegate(){MyMethod1b(a, b);}));
  } else {
  // Do Whatever you need to do here       ...    
  }
}*/
        void PrintStatus(ePrintStat printstat) 
        {
         // displays the print status
            String message = "";
            switch(printstat)
            {
                case ePrintStat.ePrintCancelled:
                    message = "Print Cancelled";
                    break;
                case ePrintStat.eLayerCompleted:
                    message = "Layer Completed";
                    break;
                case ePrintStat.ePrintCompleted:
                    message = "Print Completed";
                    break;
                case ePrintStat.ePrintStarted:
                    message = "Print Started";
                    break;
            }
            SysLog.Instance().Log(message);
        }

        //This delegate is called when the print manager is printing a new layer
        void PrintLayer(Bitmap bmp, int layer) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintLayer(bmp, layer); }));
            }
            else
            {
                ViewLayer(layer);
                //m_frmdlp.ShowImage(bmp); // display the new layer
                //picSlice.Image = bmp;
                String txt = "Printing layer " + layer + " of " + m_slicer.m_slices.Count;
                lblLayerInd.Text = txt;
                SysLog.Instance().Log(txt);

            }
        }

        public void LayerSliced(int layer, int totallayers)
        {
            if (layer == 0) 
            {
                prgSlice.Maximum = totallayers - 1;
            }
            prgSlice.Value = layer;
            if (layer == totallayers -1) 
            {
                prgSlice.Value = 0;
            }
            if (chkExportSlices.Checked == true)
            {
                String fn = "";
                String path = lblDirExport.Text;
                Slice sl = (Slice)m_slicer.m_slices[layer];
                Bitmap bmp = m_slicer.RenderSlice(GetSliceParms(), sl);
                fn = path + m_pathsep + "slice" + layer + ".png";
                bmp.Save(fn);
            }
        }


        private void ShowObjectInfo() 
        {
            try
            {
                m_obj.FindMinMax();
                txtFileInfo.Text = "Name = " + m_obj.Name + "\r\n";
                txtFileInfo.Text += "# polygons = " + m_obj.NumPolys + "\r\n";
                txtFileInfo.Text += "# points = " + m_obj.NumPoints + "\r\n";
                txtFileInfo.Text += "Min points = (" + String.Format("{0:0.00}",m_obj.m_min.x) + "," + String.Format("{0:0.00}",m_obj.m_min.y) + "," + String.Format("{0:0.00}",m_obj.m_min.z) + ")\r\n";
                txtFileInfo.Text += "Max points = (" + String.Format("{0:0.00}",m_obj.m_max.x) + "," + String.Format("{0:0.00}",m_obj.m_max.y) + "," + String.Format("{0:0.00}",m_obj.m_max.z) + ")\r\n";
            }
            catch (Exception) { }
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                m_obj = new Object3d();
                if (m_obj.LoadSTL(openFileDialog1.FileName) == false)
                {
                    MessageBox.Show("Error loading file " + openFileDialog1.FileName);
                }
                else 
                {
                    ShowObjectInfo();
                    chkWireframe.Checked = false;
                    m_engine3d.RemoveAllObjects();
                    m_engine3d.AddObject(m_obj);
                    glControl1.Invalidate();

                }
            }
        }

        private void cmdSlice_Click(object sender, EventArgs e)
        {
            try
            {
                SliceParms sp = GetSliceParms();
                int numslices = m_slicer.GetNumberOfSlices(sp, m_obj);
                lblNumSlices.Text = "Number of Slices: " + numslices;
                m_slicer.Slice(sp, m_obj, ".");
                vScrollBar1.Maximum = numslices;
                vScrollBar1.Value = 0;

            }
            catch (Exception ex) 
            {
                SysLog.Instance().Log(ex.Message);
            }
            
        }

        private SliceParms GetSliceParms() 
        {
            SliceParms sp = new SliceParms();
            sp.ZThick = Single.Parse(txtZThick.Text);
            sp.dpmmX = m_printerinfo.PixPerMMX; //10 dots per mm
            sp.dpmmY = m_printerinfo.PixPerMMY;// 10;
            sp.xres = m_printerinfo.XRes;
            sp.yres = m_printerinfo.YRes;
            return sp;
        }

        private void ViewLayer(int layer) 
        {
            try
            {
                Slice sl = (Slice)m_slicer.m_slices[layer];
                m_engine3d.RemoveAllLines();
                m_engine3d.AddGrid();
                
                foreach (PolyLine3d ln in sl.m_segments)
                {
                    ln.m_color = Color.Red;
                    m_engine3d.AddLine(ln);
                }
                glControl1.Invalidate();
                //render the 2d slice
                Bitmap bmp = m_slicer.RenderSlice(GetSliceParms(), sl);
                //now show the 2d slice
                picSlice.Image = bmp;
                m_frmdlp.ShowImage(bmp);
            }
            catch (Exception) { }
        
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int vscrollval = vScrollBar1.Value;
            ViewLayer(vscrollval);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void glControl1_Resize(object sender, EventArgs e)
        {
            if (!loaded)
                return;
            SetupViewport();
        }
        private void SetupViewport()
        {
            if (!loaded)
                return;
            float aspect = 1.0f;
            try
            {
                int w = glControl1.Width;
                int h = glControl1.Height;
                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                // Glu
                GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
                GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                //gluPerspective(20, width / (float)height, 5, 15);
                aspect = ((float)glControl1.Width) / ((float)glControl1.Height);

                //GL.Matr
                OpenTK.Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(0.55f, aspect, 0.1f, 4000);
                OpenTK.Matrix4 modelView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(5, 0, -5), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 0, 1));

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.LoadMatrix(ref projection);

                GL.ShadeModel(ShadingModel.Smooth);
                
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                float []mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float []mat_shininess = { 50.0f };
                //glMaterialfv(GL_FRONT, GL_SPECULAR, mat_specular);
                //glMaterialfv(GL_FRONT, GL_SHININESS, mat_shininess);
                GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
                GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);


                float[] lightpos = new float[4];
                lightpos[0] = 5.0f;
                lightpos[1] = 15.0f;
                lightpos[2] = 10.0f;
                lightpos[3] = 1.0f;
                float []light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
                GL.Light(LightName.Light0, LightParameter.Position, light_position);
                
                GL.Enable(EnableCap.DepthTest);
                GL.Enable(EnableCap.LineSmooth);
//glEnable(GL_LINE_SMOOTH);


                GL.MatrixMode(MatrixMode.Modelview);
                GL.LoadIdentity();
                GL.LoadMatrix(ref modelView);
            }
            catch (Exception ex) 
            {
                String s = ex.Message;
                // the create perspective function blows up on certain ratios
            }
        }

        private void glControl1_Paint(object sender, PaintEventArgs e)
        {
            if (!loaded)
                return;
            DisplayFunc();
        }


        private void DisplayFunc() 
        {
      
          /* Clear the buffer, clear the matrix */
          GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
          GL.LoadIdentity();

          GL.Translate(0, 0, orbitdist);
          GL.Rotate(orbitypos, 0, 1, 0);
          GL.Rotate(orbitxpos, 1, 0, 0);

          m_engine3d.RenderGL();
            
          GL.Flush();
          glControl1.SwapBuffers();                                    
        }

        private void FillMonitors() 
        {
            try
            {
                lstMonitors.Items.Clear();
                foreach (Screen s in Screen.AllScreens)
                {
                    lstMonitors.Items.Add(s.DeviceName);
                }
                if (lstMonitors.Items.Count > 0)
                    lstMonitors.SelectedIndex = 0;
            }
            catch (Exception) 
            {
            
            }
            
        }
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;
            GL.ClearColor(Color.SkyBlue);
            SetupViewport();
            Application.Idle += Application_Idle; // press TAB twice after +=
        }

        void Application_Idle(object sender, EventArgs e)
        {
           // glControl1.Invalidate();
        }
        private void glControl1_MouseDown(object sender, MouseEventArgs e)
        {
            mdx = e.X;
            mdy = e.Y;
            if (e.Button == MouseButtons.Left)
            {
                lmdown = true;

            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = true;
            }


        }

        private void glControl1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lmdown = false;
            }
            if (e.Button == MouseButtons.Right)
            {
                rmdown = false;
            }

        }

        private void glControl1_MouseMove(object sender, MouseEventArgs e)
        {
            double dx = 0, dy = 0;
            if (lmdown || rmdown)
            {
                dx = e.X - mdx;
                dy = e.Y - mdy;
                mdx = e.X;
                mdy = e.Y;
            }

            if (lmdown)
            {
                dx /= 2;
                dy /= 2;
                //m_engine3d.m_camera.viewmat.Rotate(-dy, dx, 0);
                orbitypos += (float)dx;
                orbitxpos += (float)dy;

                glControl1.Invalidate();
            }
            if (rmdown)
            {
                dx /= 2;// m_engine3d.m_camera.m_scalex;
                dy /= 2;// m_engine3d.m_camera.m_scaley;
                orbitdist += (float)dy;
                glControl1.Invalidate();

            }
        }

        private void glControl1_MouseLeave(object sender, EventArgs e)
        {
            //should cancel any move commands
        }

        private void chkWireframe_CheckedChanged(object sender, EventArgs e)
        {
            if (m_obj == null) return;
            m_obj.m_wireframe = chkWireframe.Checked;
            //glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdCenter_Click(object sender, EventArgs e)
        {
            if (m_obj == null) return;
            Point3d center = m_obj.CalcCenter();
            m_obj.Translate((float)-center.x, (float)-center.y,(float) -center.z);
            ShowObjectInfo();
           // glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdRefreshCom_Click(object sender, EventArgs e)
        {
            cmbSerialPort.Items.Clear();
            foreach (String s in SerialPort.GetPortNames()) 
            {
                cmbSerialPort.Items.Add(s);
            }
            if (cmbSerialPort.Items.Count > 0)
                cmbSerialPort.SelectedIndex = 0;
        }

        private void cmdRefreshMonitors_Click(object sender, EventArgs e)
        {
            FillMonitors();
        }

        private void cmdStartPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmdStartPrint.Text == "Start Print")
                {
                    //check stuff, make sure device is connected,
                    // display a messagebox to tell the user to configure screen
                    // check to make sure model is sliced and everything is set up
                    // then begin the print
                    int msec = int.Parse(txtLayerTime.Text);
                    m_printmgr.StartPrint(m_slicer, msec, GetSliceParms());
                    cmdStartPrint.Text = "Cancel Print";
                }
                else
                {
                    m_printmgr.CancelPrint();
                    cmdStartPrint.Text = "Start Print";
                }
            }
            catch (Exception ex) 
            {
                SysLog.Instance().Log(ex.Message);
            }
        }

        private void cmdPlace_Click(object sender, EventArgs e)
        {
            if (m_obj == null) return;

            Point3d center = m_obj.CalcCenter();
            m_obj.FindMinMax();
            float zlev = (float)m_obj.m_min.z;

            m_obj.Translate((float)-center.x, (float)-center.y, (float)-zlev);
            ShowObjectInfo();
            //glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (m_obj == null) return;
                float sf = Single.Parse(txtScale.Text);
                m_obj.Scale(sf);
                ShowObjectInfo();
                glControl1.Invalidate();

            }
            catch (Exception) 
            {
            
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void cmdConnect_Click(object sender, EventArgs e)
        {
            String com = cmbSerialPort.Text;
            if (com.Length > 0)
            {
                m_printeriface.Connect(com);
                SysLog.Instance().Log("Connecting to Printer on " + com);
            }
            else 
            {
                //bring up a message that we're not connected
            }
            
        }

        private void lstMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMonitors.SelectedIndex == -1)
            {
                lblMonInfo.Text = "";
                return;
            }

            //get the selected monitor
            //display some info (resolution) about it in lblMonInfo
            Screen s = Screen.AllScreens[lstMonitors.SelectedIndex];
            lblMonInfo.Text = "Info " + s.Bounds.Width + " x " + s.Bounds.Height;
            m_printerinfo.SetDLPRes(s.Bounds.Width, s.Bounds.Height);
            ShowPixPerMM();
        }

        private void cmdSetPlatSize_Click(object sender, EventArgs e)
        {
            try
            {
                double xsz = Double.Parse(txtPlatWidth.Text);
                double ysz = Double.Parse(txtPlatHeight.Text);
                m_printerinfo.SetPlatSize(xsz, ysz);
                ShowPixPerMM();
            }
            catch (Exception) 
            {
            }
        }

        private void ShowPixPerMM()
        {
            lblPixperMM.Text = "Pixels per MM  X=" + String.Format("{0:0.00}",m_printerinfo.PixPerMMX) + " Y=" + String.Format("{0:0.00}",m_printerinfo.PixPerMMY);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Screen s = Screen.AllScreens[1];
                m_frmdlp.Show();
                m_frmdlp.SetDesktopBounds(s.Bounds.X, s.Bounds.Y, s.Bounds.Width, s.Bounds.Height);
                m_frmdlp.WindowState = FormWindowState.Maximized;
                m_frmdlp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            }
            catch (Exception) 
            {
            
            }
            //
           
        }

        private void cmdSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                lblDirExport.Text = folderBrowserDialog1.SelectedPath;
            }
        }

    }
}
