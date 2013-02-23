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
            if (GetValues())
            {
                //save
                UVDLPApp.Instance().SaveCurrentSliceBuildConfig();
                Close();
            }
        }

        private void SetValues() 
        {
            txtZThick.Text = "" + String.Format("{0:0.00000}",UVDLPApp.Instance().m_buildparms.ZThick);
            chkgengcode.Checked = UVDLPApp.Instance().m_buildparms.exportgcode;
            chkExportSlices.Checked = UVDLPApp.Instance().m_buildparms.exportimages;
            chkexportsvg.Checked = UVDLPApp.Instance().m_buildparms.exportsvg;
            txtLayerTime.Text = "" + UVDLPApp.Instance().m_buildparms.layertime_ms;
            txtFirstLayerTime.Text = UVDLPApp.Instance().m_buildparms.firstlayertime_ms.ToString();
            txtBlankTime.Text = UVDLPApp.Instance().m_buildparms.blanktime_ms.ToString();
            txtXOffset.Text = UVDLPApp.Instance().m_buildparms.XOffset.ToString();
            txtYOffset.Text = UVDLPApp.Instance().m_buildparms.YOffset.ToString();
            txtLiftDistance.Text = UVDLPApp.Instance().m_buildparms.liftdistance.ToString();

            foreach(String name in Enum.GetNames(typeof(SliceBuildConfig.eBuildDirection)))
            {
                cmbBuildDirection.Items.Add(name);
            }
            cmbBuildDirection.SelectedItem = UVDLPApp.Instance().m_buildparms.direction.ToString();
            //cmbBuildDirection.
        }
        private bool GetValues() 
        {
            try
            {              
                UVDLPApp.Instance().m_buildparms.ZThick = Single.Parse(txtZThick.Text);
                UVDLPApp.Instance().m_buildparms.exportgcode = chkgengcode.Checked;
                UVDLPApp.Instance().m_buildparms.exportimages = chkExportSlices.Checked;
                UVDLPApp.Instance().m_buildparms.exportsvg = chkexportsvg.Checked;
                UVDLPApp.Instance().m_buildparms.layertime_ms = int.Parse(txtLayerTime.Text);
                UVDLPApp.Instance().m_buildparms.firstlayertime_ms = int.Parse(txtFirstLayerTime.Text);
                UVDLPApp.Instance().m_buildparms.blanktime_ms = int.Parse(txtBlankTime.Text);
                UVDLPApp.Instance().m_buildparms.XOffset = int.Parse(txtXOffset.Text);
                UVDLPApp.Instance().m_buildparms.YOffset = int.Parse(txtYOffset.Text);
                UVDLPApp.Instance().m_buildparms.liftdistance = double.Parse(txtLiftDistance.Text);
                UVDLPApp.Instance().m_buildparms.direction = (SliceBuildConfig.eBuildDirection)Enum.Parse(typeof(SliceBuildConfig.eBuildDirection), cmbBuildDirection.SelectedItem.ToString());
                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message,"Input Error");
                return false;
            }
        }

        private void frmSliceOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
