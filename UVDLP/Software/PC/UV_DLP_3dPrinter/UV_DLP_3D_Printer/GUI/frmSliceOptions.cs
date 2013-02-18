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
    public partial class frmSliceOptions : Form
    {
        public frmSliceOptions()
        {
            InitializeComponent();
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //save some stuff
            GetValues();
            Close();
        }

        private void SetValues() 
        {
            txtZThick.Text = "" + String.Format("{0:0.00000}",UVDLPApp.Instance().m_buildparms.ZThick);
            chkgengcode.Checked = UVDLPApp.Instance().m_buildparms.exportgcode;
            chkExportSlices.Checked = UVDLPApp.Instance().m_buildparms.exportimages;
            chkexportsvg.Checked = UVDLPApp.Instance().m_buildparms.exportsvg;
            txtLayerTime.Text = "" + UVDLPApp.Instance().m_buildparms.layertime_ms;
        
        }
        private void GetValues() 
        {
            try
            {              
                UVDLPApp.Instance().m_buildparms.ZThick = Single.Parse(txtZThick.Text);
                UVDLPApp.Instance().m_buildparms.exportgcode = chkgengcode.Checked;
                UVDLPApp.Instance().m_buildparms.exportimages = chkExportSlices.Checked;
                UVDLPApp.Instance().m_buildparms.exportsvg = chkexportsvg.Checked;
                UVDLPApp.Instance().m_buildparms.layertime_ms = int.Parse(txtLayerTime.Text);
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Input Error", "Please check input paramters\r\n" + ex.Message);
            }
        }

        private void frmSliceOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }
    }
}
