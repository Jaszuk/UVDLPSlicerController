using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using UV_DLP_3D_Printer.Configs;

namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmConnection : Form
    {
        public frmConnection()
        {
            InitializeComponent();
            SetData();
        }

        private bool GetData() 
        {
            try
            {
                UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.comname = cmbPorts.SelectedItem.ToString();
                UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.speed = int.Parse(cmbSpeed.SelectedItem.ToString());
                UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection.databits = int.Parse(txtDataBits.Text);


                return true;
            }
            catch (Exception ex) 
            {
                MessageBox.Show("Please check input parameters\r\n" + ex.Message, "Input Error");
                return false;
            }
        }

        private void SetData() 
        {
            ConnectionConfig cc = UVDLPApp.Instance().m_printerinfo.m_driverconfig.m_connection;
            cmbPorts.Items.Clear();
            //set all available port names
            foreach (String s in SerialPort.GetPortNames()) 
            {
                cmbPorts.Items.Add(s);
            }
            cmbPorts.SelectedItem = cc.comname;
            cmbSpeed.SelectedItem = cc.speed.ToString();
            txtDataBits.Text = cc.databits.ToString();

            /*        foreach (string s in Enum.GetNames(typeof(StopBits)))
        {
            Console.WriteLine("   {0}", s);
        }*/
            //

        }

        private void cmdOK_Click(object sender, EventArgs e)
        {
            if (GetData()) 
            {
                UVDLPApp.Instance().SaveCurrentMachineConfig();//save machine config                
                Close();
            }
        }

        private void cmdCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmdrefresh_Click(object sender, EventArgs e)
        {
            SetData();
        }

    }
}
