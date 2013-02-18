using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer
{
    public partial class frmMachineConfig : Form
    {
        public frmMachineConfig()
        {
            InitializeComponent();
            FillMonitors(); // list out the system monitors
        }

        private void SetData() 
        {
            try
            {
                txtPlatWidth.Text = "" + UVDLPApp.Instance().m_printerinfo.m_PlatXSize;
                txtPlatHeight.Text = "" + UVDLPApp.Instance().m_printerinfo.m_PlatYSize;
                projwidth.Text = "" + UVDLPApp.Instance().m_printerinfo.XRes;
                projheight.Text = "" + UVDLPApp.Instance().m_printerinfo.YRes;
                //select the current monitor
                int idx = 0;
                foreach (String s in lstMonitors.Items) 
                {
                    if (s.Equals(UVDLPApp.Instance().m_printerinfo.m_monitorid)) 
                    {
                        lstMonitors.SelectedIndex = idx;
                    }
                    idx++;
                }
            }
            catch (Exception) 
            {
            
            }
        }
        private bool GetData() 
        {
            try
            {
                UVDLPApp.Instance().m_printerinfo.m_PlatXSize = double.Parse(txtPlatWidth.Text);
                UVDLPApp.Instance().m_printerinfo.m_PlatYSize = double.Parse(txtPlatHeight.Text);
                UVDLPApp.Instance().m_printerinfo.m_XDLPRes = double.Parse(projwidth.Text);
                UVDLPApp.Instance().m_printerinfo.m_YDLPRes = double.Parse(projheight.Text);
                if (lstMonitors.SelectedIndex != -1)
                {
                    UVDLPApp.Instance().m_printerinfo.m_monitorid = Screen.AllScreens[lstMonitors.SelectedIndex].DeviceName;// lstMonitors.Items[lstMonitors.SelectedIndex].ToString();
                }
                return true;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
                return false;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData())
            {
                UVDLPApp.Instance().SaveCurrentMachineConfig();
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMachineConfig_Load(object sender, EventArgs e)
        {
            SetData();
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

        private void cmdRefreshMonitors_Click(object sender, EventArgs e)
        {
            FillMonitors();
        }

        private void lstMonitors_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get the projector width and fill in the projwidth and projheight
            if (lstMonitors.SelectedIndex == -1) return;
            try
            {
                projwidth.Text = "" + Screen.AllScreens[lstMonitors.SelectedIndex].Bounds.Width;
                projheight.Text = "" + Screen.AllScreens[lstMonitors.SelectedIndex].Bounds.Height;
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }

        }
    }
}
