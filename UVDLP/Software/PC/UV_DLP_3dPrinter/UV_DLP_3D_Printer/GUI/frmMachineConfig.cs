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
        }

        private void SetData() 
        {
            try
            {
                txtPlatWidth.Text = "" + UVDLPApp.Instance().m_printerinfo.m_PlatXSize;
                txtPlatHeight.Text = "" + UVDLPApp.Instance().m_printerinfo.m_PlatYSize;
                projwidth.Text = "" + UVDLPApp.Instance().m_printerinfo.XRes;
                projheight.Text = "" + UVDLPApp.Instance().m_printerinfo.YRes;
            }
            catch (Exception) 
            {
            
            }
        }
        private void GetData() 
        {
            UVDLPApp.Instance().m_printerinfo.m_PlatXSize = double.Parse(txtPlatWidth.Text);
            UVDLPApp.Instance().m_printerinfo.m_PlatYSize = double.Parse(txtPlatHeight.Text);
            UVDLPApp.Instance().m_printerinfo.m_XDLPRes = double.Parse(projwidth.Text);
            UVDLPApp.Instance().m_printerinfo.m_YDLPRes = double.Parse(projheight.Text);             
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            GetData();
            Close();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmMachineConfig_Load(object sender, EventArgs e)
        {
            SetData();
        }
    }
}
