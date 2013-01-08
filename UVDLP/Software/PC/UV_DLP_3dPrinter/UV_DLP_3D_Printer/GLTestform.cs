using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace UV_DLP_3D_Printer
{
    public partial class GLTestform : Form
    {
        bool loaded = false;

        public GLTestform()
        {
            InitializeComponent();
        }

        private void GLTestform_Load(object sender, EventArgs e)
        {
            loaded = true;
        }
    }
}
