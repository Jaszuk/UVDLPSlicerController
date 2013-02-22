using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UV_DLP_3D_Printer.Drivers;
namespace UV_DLP_3D_Printer.GUI
{
    public partial class frmGCodeRaw : Form
    {
        public frmGCodeRaw()
        {
            InitializeComponent();
            UVDLPApp.Instance().m_deviceinterface.DataEvent += new DeviceInterface.DeviceDataReceived(DataReceived);
        }
        void DataReceived(DeviceDriver driver, byte[] data, int len) 
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MethodInvoker(delegate() { DataReceived(driver, data, len); }));
            }
            else
            {
                String s = ASCIIEncoding.ASCII.GetString(data);
                txtReceived.Text += s + "\r\n";
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (UVDLPApp.Instance().m_deviceinterface.SendCommandToDevice(txtGCode.Text + "\r\n"))
                {
                    txtSent.Text += txtGCode.Text + "\r\n";
                }
                else 
                {
                    DebugLogger.Instance().LogRecord("Could Not Send Raw GCode Command");
                }
            }
            catch (Exception ex) 
            {
                DebugLogger.Instance().LogRecord(ex.Message);
            }
        }
    }
}
