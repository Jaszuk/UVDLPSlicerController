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
using System.Collections;
using UV_DLP_3D_Printer.GUI;

namespace UV_DLP_3D_Printer
{
    public partial class frmMain : Form
    {
        bool loaded = false;               
        //Engine3d UVDLPApp.Instance().Engine3D = new Engine3d();              
        frmDLP m_frmdlp = new frmDLP();
        frmSliceOptions m_frmsliceopt = new frmSliceOptions();
        frmControl m_frmcontrol = new frmControl();
        frmSlice m_frmSlice = new frmSlice();
        frmGCodeRaw m_sendgcode = new frmGCodeRaw();

        private bool lmdown, rmdown;
        private int mdx, mdy;
        float orbitypos = 0;
        float orbitxpos = -80;
        float orbitdist = -200;

        public frmMain()
        {
            InitializeComponent();
            UVDLPApp.Instance().AppEvent += new AppEventDelegate(AppEventDel);
            UVDLPApp.Instance().Engine3D.AddGrid();
            UVDLPApp.Instance().Engine3D.AddPlatCube();
            UVDLPApp.Instance().Engine3D.CameraReset();
            UVDLPApp.Instance().m_slicer.Slice_Event += new Slicer.SliceEvent(SliceEv);
            UVDLPApp.Instance().m_buildmgr.PrintStatus += new delPrintStatus(PrintStatus);
            UVDLPApp.Instance().m_buildmgr.PrintLayer += new delPrinterLayer(PrintLayer);
            DebugLogger.Instance().LoggerStatusEvent += new LoggerStatusHandler(LoggerStatusEvent);
            UVDLPApp.Instance().m_deviceinterface.StatusEvent += new DeviceInterface.DeviceInterfaceStatus(DeviceStatusEvent);
            SetConnectionStatus();
        }
        /*
         This handles specific events triggered by the app
         */
        private void AppEventDel(eAppEvent ev, String Message) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { AppEventDel(ev, Message); }));
            }
            else
            {
                switch (ev) 
                {
                    case eAppEvent.eGCodeLoaded:
                        break;
                    case eAppEvent.eGCodeSaved:
                        break;
                    case eAppEvent.eModelLoaded:
                        break;
                }
            }
        }
        
        private void SetConnectionStatus() 
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected)
            {
                cmdConnect.Enabled = false;
                cmdDisconnect.Enabled = true;
                //cmdRefresh.Enabled = false;
                //cmbSerial.Enabled = false;
                cmdControl.Enabled = true;
                cmdBuild.Enabled = true;
                cmdStop.Enabled = true;
            }
            else 
            {
                cmdConnect.Enabled = true;
                cmdDisconnect.Enabled = false;
                //cmdRefresh.Enabled = true;
                //cmbSerial.Enabled = true;
                cmdControl.Enabled = false;
                cmdBuild.Enabled = false;
                cmdStop.Enabled = false;

            }
        }
        /*
         This function is called when the device status changes
         * most of this is for display purposes only,
         * the real business logic should be held in the app class
         */
        void DeviceStatusEvent(ePIStatus status, String Command) 
        {
            switch (status) 
            {
                case ePIStatus.eConnected:
                    SetConnectionStatus();
                    DebugLogger.Instance().LogRecord("Device Connected");
                    break;
                case ePIStatus.eDisconnected:
                    SetConnectionStatus();
                    DebugLogger.Instance().LogRecord("Device Disconnected");
                    break;
                case ePIStatus.eError:
                    break;
                case ePIStatus.eReady:
                    break;
                case ePIStatus.eTimedout:
                    break;
            }
        }

        void LoggerStatusEvent(Logger o, eLogStatus status, string message)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { LoggerStatusEvent(o, status, message); }));
            }
            else
            {                
                switch (status)
                {
                    case eLogStatus.eLogWroteRecord:
                        txtLog.Text = message + "\r\n" + txtLog.Text;
                        break;
                }
            }
        }

        void PrintStatus(ePrintStat printstat) 
        {
         // displays the print status
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintStatus(printstat); }));
            }
            else
            {
                String message = "";
                switch (printstat)
                {
                    case ePrintStat.ePrintCancelled:
                        message = "Print Cancelled";
                        break;
                    case ePrintStat.eLayerCompleted:
                        message = "Layer Completed";
                        break;
                    case ePrintStat.ePrintCompleted:
                        message = "Print Completed";
                        MessageBox.Show("Build Completed");
                        break;
                    case ePrintStat.ePrintStarted:
                        message = "Print Started";
                        if (!ShowDLPScreen()) 
                        {
                            MessageBox.Show("Monitor " + UVDLPApp.Instance().m_printerinfo.m_monitorid + " not found, cancelling build","Error");
                            UVDLPApp.Instance().m_buildmgr.CancelPrint();
                        }
                        break;
                }
                DebugLogger.Instance().LogRecord(message);
            }
        }

        //This delegate is called when the print manager is printing a new layer
        void PrintLayer(Bitmap bmp, int layer,int layertype) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { PrintLayer(bmp, layer,layertype); }));
            }
            else
            {
                ViewLayer(layer,bmp,layertype);
                // display info only if it's a normal layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    String txt = "Printing layer " + (layer + 1) + " of " + UVDLPApp.Instance().m_slicefile.m_slices.Count;
                    DebugLogger.Instance().LogRecord(txt);
                }

            }
        }

        private void SliceEv(Slicer.eSliceEvent ev, int layer, int totallayers)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { SliceEv(ev,layer, totallayers); }));
            }
            else
            {
                switch (ev)
                {
                    case Slicer.eSliceEvent.eSliceStarted:
                        break;
                    case Slicer.eSliceEvent.eLayerSliced:
                        break;
                    case Slicer.eSliceEvent.eSliceCompleted:
                        //show the gcode
                        txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;
                        vScrollBar1.Maximum = totallayers;
                        vScrollBar1.Value = 0;
                        break;
                }
            }
        }

        private void ShowObjectInfo() 
        {
            try
            {
                UVDLPApp.Instance().m_obj.FindMinMax();
                txtFileInfo.Text = "Name = " + UVDLPApp.Instance().m_obj.Name + "\r\n";
                txtFileInfo.Text += "# polygons = " + UVDLPApp.Instance().m_obj.NumPolys + "\r\n";
                txtFileInfo.Text += "# points = " + UVDLPApp.Instance().m_obj.NumPoints + "\r\n";
                txtFileInfo.Text += "Min points = (" + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_min.x) + "," + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_min.y) + "," + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_min.z) + ")\r\n";
                txtFileInfo.Text += "Max points = (" + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_max.x) + "," + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_max.y) + "," + String.Format("{0:0.00}",UVDLPApp.Instance().m_obj.m_max.z) + ")\r\n";
                double xs, ys, zs;
                xs = UVDLPApp.Instance().m_obj.m_max.x - UVDLPApp.Instance().m_obj.m_min.x;
                ys = UVDLPApp.Instance().m_obj.m_max.y - UVDLPApp.Instance().m_obj.m_min.y;
                zs = UVDLPApp.Instance().m_obj.m_max.z - UVDLPApp.Instance().m_obj.m_min.z;
                txtFileInfo.Text += "Size = (" + String.Format("{0:0.00}", xs) + "," + String.Format("{0:0.00}", ys) + "," + String.Format("{0:0.00}", zs) + ")\r\n";
            }
            catch (Exception) { }
        
        }
        /*
         Load Stl
         */
        private void LoadSTLModel_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK) 
            {
                UVDLPApp.Instance().m_obj = new Object3d();
                if (UVDLPApp.Instance().m_obj.LoadSTL(openFileDialog1.FileName) == false)
                {
                    MessageBox.Show("Error loading file " + openFileDialog1.FileName);
                }
                else 
                {
                    ShowObjectInfo();
                    chkWireframe.Checked = false;
                    UVDLPApp.Instance().Engine3D.RemoveAllObjects();
                    UVDLPApp.Instance().Engine3D.AddObject(UVDLPApp.Instance().m_obj);
                    UVDLPApp.Instance().m_slicefile = null;
                    glControl1.Invalidate();
                    vScrollBar1.Maximum = 1;
                    vScrollBar1.Value = 0;
                }
            }
        }

        
        private void ViewLayer(int layer, Bitmap image, int layertype) 
        {
            try
            {
                // if this is a normal slice that is specified, move to the correct 3d view of the layer, 
                // otherwise, keep showing the current 3d layer
                if (layertype == BuildManager.SLICE_NORMAL)
                {
                    Slice sl = (Slice)UVDLPApp.Instance().m_slicefile.m_slices[layer];
                    UVDLPApp.Instance().Engine3D.RemoveAllLines();
                    UVDLPApp.Instance().Engine3D.AddGrid();
                    UVDLPApp.Instance().Engine3D.AddPlatCube();

                    foreach (PolyLine3d ln in sl.m_segments)
                    {
                        ln.m_color = Color.Red;
                        UVDLPApp.Instance().Engine3D.AddLine(ln);
                    }
                    glControl1.Invalidate();
                }
                //render the 2d slice
                Bitmap bmp = null;
                if (image == null) // we're here because of the scroll bar in the gui
                {
                    bmp = UVDLPApp.Instance().m_slicefile.RenderSlice(layer);
                }
                else // the image was specified from the build manager
                {
                    bmp = image;
                }
                //this bmp could be a normal, blank, or calibration image
                picSlice.Image = bmp;//now show the 2d slice
                m_frmdlp.ShowImage(bmp);
                //lblCurSlice.Text = "Layer = " +layer;
            }
            catch (Exception) { }
        
        }
        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            int vscrollval = vScrollBar1.Value;
            ViewLayer(vscrollval,null,BuildManager.SLICE_NORMAL);
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
                //GL.Ortho(0, w, 0, h, -1, 1); // Bottom-left corner pixel has coordinate (0, 0)
                GL.Ortho(0, w, 0, h, 1, 2000); // Bottom-left corner pixel has coordinate (0, 0)
                GL.Viewport(0, 0, w, h); // Use all of the glControl painting area
                aspect = ((float)glControl1.Width) / ((float)glControl1.Height);

                //GL.Matr
                GL.Enable(EnableCap.DepthTest); // for z buffer
                OpenTK.Matrix4 projection = OpenTK.Matrix4.CreatePerspectiveFieldOfView(0.55f, aspect, 1,2000);
                //GL.DepthRange(0, 2000);
                OpenTK.Matrix4 modelView = OpenTK.Matrix4.LookAt(new OpenTK.Vector3(5, 0, -5), new OpenTK.Vector3(0, 0, 0), new OpenTK.Vector3(0, 0, 1));

                GL.MatrixMode(MatrixMode.Projection);
                GL.LoadIdentity();
                GL.LoadMatrix(ref projection);

                GL.ShadeModel(ShadingModel.Smooth);
                GL.Enable(EnableCap.Lighting);
                GL.Enable(EnableCap.Light0);
                float []mat_specular = { 1.0f, 1.0f, 1.0f, 1.0f };
                float []mat_shininess = { 50.0f };
                GL.Material(MaterialFace.Front, MaterialParameter.Specular, mat_specular);
                GL.Material(MaterialFace.Front, MaterialParameter.Shininess, mat_shininess);

               // GL.Enable(EnableCap.Blend); // alpha blending
                //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);
                
                float[] lightpos = new float[4];
                lightpos[0] = 5.0f;
                lightpos[1] = 15.0f;
                lightpos[2] = 10.0f;
                lightpos[3] = 1.0f;
                float []light_position = { 1.0f, 1.0f, 1.0f, 0.0f };
                GL.Light(LightName.Light0, LightParameter.Position, light_position);
                
                
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

          GL.Translate(0, -10, orbitdist);
          GL.Rotate(orbitypos, 0, 1, 0);
          GL.Rotate(orbitxpos, 1, 0, 0);

          UVDLPApp.Instance().Engine3D.RenderGL();
            
          GL.Flush();
           // glControl1.
          glControl1.SwapBuffers();                                    
        }

        
        private void glControl1_Load(object sender, EventArgs e)
        {
            loaded = true;

            //GL.ClearColor(Color4.SkyBlue);
            GL.ClearColor(Color.FromArgb(20, Color.LightBlue));
            GL.Enable(EnableCap.Blend);
            //GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcColor);
            GL.BlendFunc(BlendingFactorSrc.SrcAlpha, BlendingFactorDest.OneMinusSrcAlpha);

            SetupViewport();
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
                //UVDLPApp.Instance().Engine3D.m_camera.viewmat.Rotate(-dy, dx, 0);
                orbitypos += (float)dx;
                orbitxpos += (float)dy;

                glControl1.Invalidate();
            }
            if (rmdown)
            {
                dx /= 2;// UVDLPApp.Instance().Engine3D.m_camera.m_scalex;
                dy /= 2;// UVDLPApp.Instance().Engine3D.m_camera.m_scaley;
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
            if (UVDLPApp.Instance().m_obj == null) return;
            UVDLPApp.Instance().m_obj.m_wireframe = chkWireframe.Checked;
            //glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdCenter_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_obj == null) return;
            Point3d center = UVDLPApp.Instance().m_obj.CalcCenter();
            UVDLPApp.Instance().m_obj.Translate((float)-center.x, (float)-center.y,(float) -center.z);
            ShowObjectInfo();
           // glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdStartPrint_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildmgr.StartPrint(UVDLPApp.Instance().m_slicefile, UVDLPApp.Instance().m_gcode);
        }

        private void cmdPlace_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_obj == null) return;

            Point3d center = UVDLPApp.Instance().m_obj.CalcCenter();
            UVDLPApp.Instance().m_obj.FindMinMax();
            float zlev = (float)UVDLPApp.Instance().m_obj.m_min.z;

            UVDLPApp.Instance().m_obj.Translate((float)-center.x, (float)-center.y, (float)-zlev);
            ShowObjectInfo();
            //glControl1.Invalidate();
            DisplayFunc();
        }

        private void cmdScale_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_obj == null) return;
                float sf = Single.Parse(txtScale.Text);
                UVDLPApp.Instance().m_obj.Scale(sf);
                ShowObjectInfo();
                glControl1.Invalidate();

            }
            catch (Exception) 
            {
            
            }
        }

        private bool ShowDLPScreen() 
        {
            try
            {
                Screen dlpscreen = null;
                foreach (Screen s in Screen.AllScreens) 
                {
                    if (s.DeviceName.Equals(UVDLPApp.Instance().m_printerinfo.m_monitorid)) 
                    {
                        dlpscreen = s;
                        break;
                    }
                }
                if (dlpscreen == null)
                    return false;
                if (m_frmdlp.IsDisposed) 
                {
                    m_frmdlp = new frmDLP();//recreate
                }
                m_frmdlp.Show();
                m_frmdlp.SetDesktopBounds(dlpscreen.Bounds.X, dlpscreen.Bounds.Y, dlpscreen.Bounds.Width, dlpscreen.Bounds.Height);
                m_frmdlp.WindowState = FormWindowState.Maximized;
                m_frmdlp.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                return true;
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                return false;
            }                  
        }
        /* // this code shows the secondary DLP screen 
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
        }
        */
        private void cmdSliceOptions_Click(object sender, EventArgs e)
        {
            m_frmsliceopt.ShowDialog();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void loadBinarySTLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadSTLModel_Click(this, null);
        }

        private void slicingOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cmdSliceOptions_Click(this, null);
        }

        private void machinePropertiesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmMachineConfig mf = new frmMachineConfig();
            mf.ShowDialog();
        }

        private void cmdStop_Click(object sender, EventArgs e)
        {
            UVDLPApp.Instance().m_buildmgr.CancelPrint();
        }

        

        private void cmdConnect1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!UVDLPApp.Instance().m_deviceinterface.Connected) // 
                {
                    //maybe get the com port if it's different?
                    //UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.comname = com;
                    UVDLPApp.Instance().m_deviceinterface.Configure(UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection);
                    String com = UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.comname;
                    DebugLogger.Instance().LogRecord("Connecting to Printer on " + com + " using " + UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_drivertype.ToString());
                    if (!UVDLPApp.Instance().m_deviceinterface.Connect()) 
                    {
                        DebugLogger.Instance().LogRecord("Cannot connect printer driver on " + com);
                    }
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdDisconnect_Click(object sender, EventArgs e)
        {
            if (UVDLPApp.Instance().m_deviceinterface.Connected) // disconnect
            {
                DebugLogger.Instance().LogRecord("Disconnecting from Printer");
                UVDLPApp.Instance().m_deviceinterface.Disconnect();
            }
        }

        private void cmdControl_Click(object sender, EventArgs e)
        {
            if (m_frmcontrol.IsDisposed)
            {
                m_frmcontrol = new frmControl();
            }
            m_frmcontrol.Show();
        }

        private void connectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConnection frmconnect = new frmConnection();
            frmconnect.ShowDialog();
        }

        private void cmdSlice1_Click(object sender, EventArgs e)
        {
            if (m_frmSlice.IsDisposed) 
            {
                m_frmSlice = new frmSlice();
            }
            m_frmSlice.Show();
        }

        private void sendGCodeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (m_sendgcode.IsDisposed) 
            {
                m_sendgcode = new frmGCodeRaw();
            }
            m_sendgcode.Show();
        }

        private void cmdSaveGCode_Click(object sender, EventArgs e)
        {
            try
            {
                // get the gcode from the textbox, save it...
                UVDLPApp.Instance().m_gcode.RawGCode = txtGCode.Text;
                UVDLPApp.Instance().SaveGCode();
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }

        private void cmdReloadGCode_Click(object sender, EventArgs e)
        {
            try
            {
                UVDLPApp.Instance().LoadGCode();
                txtGCode.Text = UVDLPApp.Instance().m_gcode.RawGCode;                
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
    }
}
