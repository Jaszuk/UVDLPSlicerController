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

        private void cmdSelectDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK) 
            {
                lblWorkingDir.Text = folderBrowserDialog1.SelectedPath;
                Config.Instance().WorkingDirectory = folderBrowserDialog1.SelectedPath;
            }
        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            //save some stuff
            GetValues();
            Close();
        }

        private void SetValues() 
        {
            chkgengcode.Checked = Config.Instance().GenerateGCode;
            chkExportSlices.Checked = Config.Instance().GenerateSlices;
            lblWorkingDir.Text = Config.Instance().WorkingDirectory;
        
        }
        private void GetValues() 
        {
            Config.Instance().GenerateGCode = chkgengcode.Checked;
            Config.Instance().GenerateSlices = chkExportSlices.Checked;
            Config.Instance().WorkingDirectory = lblWorkingDir.Text;
        }

        private void frmSliceOptions_Load(object sender, EventArgs e)
        {
            SetValues();
        }
    }
}
