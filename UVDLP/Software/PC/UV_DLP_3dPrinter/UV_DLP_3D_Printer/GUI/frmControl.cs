using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmControl : Form
    {
        public frmControl()
        {
            InitializeComponent();
        }

        private void cmdUp_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdist.Text);
                String movecommand = "G1 Z" + dist.ToString() + "\r\n";
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(movecommand);
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }

        private void cmdDown_Click(object sender, EventArgs e)
        {
            try
            {
                double dist = double.Parse(txtdist.Text);
                dist = dist * -1.0;
                String movecommand = "G1 Z" + dist.ToString() + "\r\n";
                UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(movecommand);
            }
            catch (Exception ex)
            {
                DebugLogger.Instance().LogRecord(ex.Message);
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
            }
        }
    }
}
