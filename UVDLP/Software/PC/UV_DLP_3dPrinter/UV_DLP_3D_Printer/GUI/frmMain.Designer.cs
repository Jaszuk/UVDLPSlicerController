namespace UV_DLP_3D_Printer
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.txtFileInfo = new System.Windows.Forms.TextBox();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.glControl1 = new OpenTK.GLControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabMain = new System.Windows.Forms.TabControl();
            this.tabModel1 = new System.Windows.Forms.TabPage();
            this.tabGCode = new System.Windows.Forms.TabPage();
            this.txtGCode = new System.Windows.Forms.TextBox();
            this.tabSliceView = new System.Windows.Forms.TabPage();
            this.picSlice = new System.Windows.Forms.PictureBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmdBuild = new System.Windows.Forms.ToolStripButton();
            this.cmdStop = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.cmbSerial = new System.Windows.Forms.ToolStripComboBox();
            this.cmdRefresh = new System.Windows.Forms.ToolStripButton();
            this.cmdConnect = new System.Windows.Forms.ToolStripButton();
            this.cmdDisconnect = new System.Windows.Forms.ToolStripButton();
            this.cmdControl = new System.Windows.Forms.ToolStripButton();
            this.cmdSlice1 = new System.Windows.Forms.ToolStripButton();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadBinarySTLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.slicingOptionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.machinePropertiesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.connectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabModel = new System.Windows.Forms.TabPage();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.cmdScale = new System.Windows.Forms.Button();
            this.cmdPlace = new System.Windows.Forms.Button();
            this.cmdCenter = new System.Windows.Forms.Button();
            this.chkWireframe = new System.Windows.Forms.CheckBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabMain.SuspendLayout();
            this.tabModel1.SuspendLayout();
            this.tabGCode.SuspendLayout();
            this.tabSliceView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabModel.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 122);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(126, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "Load STL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtFileInfo
            // 
            this.txtFileInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtFileInfo.Location = new System.Drawing.Point(3, 3);
            this.txtFileInfo.Multiline = true;
            this.txtFileInfo.Name = "txtFileInfo";
            this.txtFileInfo.ReadOnly = true;
            this.txtFileInfo.Size = new System.Drawing.Size(285, 113);
            this.txtFileInfo.TabIndex = 1;
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Right;
            this.vScrollBar1.Location = new System.Drawing.Point(1114, 28);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(30, 598);
            this.vScrollBar1.TabIndex = 11;
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(3, 3);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1109, 508);
            this.glControl1.TabIndex = 15;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseLeave += new System.EventHandler(this.glControl1_MouseLeave);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.Resize += new System.EventHandler(this.glControl1_Resize);
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabMain);
            this.splitContainer1.Panel1.Controls.Add(this.toolStrip1);
            this.splitContainer1.Panel1.Controls.Add(this.vScrollBar1);
            this.splitContainer1.Panel1.Controls.Add(this.menuStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1457, 630);
            this.splitContainer1.SplitterDistance = 1148;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 20;
            // 
            // tabMain
            // 
            this.tabMain.Controls.Add(this.tabModel1);
            this.tabMain.Controls.Add(this.tabGCode);
            this.tabMain.Controls.Add(this.tabSliceView);
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 83);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedIndex = 0;
            this.tabMain.Size = new System.Drawing.Size(1114, 543);
            this.tabMain.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabMain.TabIndex = 18;
            // 
            // tabModel1
            // 
            this.tabModel1.Controls.Add(this.glControl1);
            this.tabModel1.Location = new System.Drawing.Point(4, 25);
            this.tabModel1.Name = "tabModel1";
            this.tabModel1.Padding = new System.Windows.Forms.Padding(3);
            this.tabModel1.Size = new System.Drawing.Size(1115, 514);
            this.tabModel1.TabIndex = 0;
            this.tabModel1.Text = "Model View";
            this.tabModel1.UseVisualStyleBackColor = true;
            // 
            // tabGCode
            // 
            this.tabGCode.Controls.Add(this.txtGCode);
            this.tabGCode.Location = new System.Drawing.Point(4, 25);
            this.tabGCode.Name = "tabGCode";
            this.tabGCode.Padding = new System.Windows.Forms.Padding(3);
            this.tabGCode.Size = new System.Drawing.Size(1115, 514);
            this.tabGCode.TabIndex = 1;
            this.tabGCode.Text = "GCode";
            this.tabGCode.UseVisualStyleBackColor = true;
            // 
            // txtGCode
            // 
            this.txtGCode.BackColor = System.Drawing.Color.White;
            this.txtGCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtGCode.Location = new System.Drawing.Point(3, 3);
            this.txtGCode.Multiline = true;
            this.txtGCode.Name = "txtGCode";
            this.txtGCode.ReadOnly = true;
            this.txtGCode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGCode.Size = new System.Drawing.Size(1109, 508);
            this.txtGCode.TabIndex = 0;
            // 
            // tabSliceView
            // 
            this.tabSliceView.Controls.Add(this.picSlice);
            this.tabSliceView.Location = new System.Drawing.Point(4, 25);
            this.tabSliceView.Name = "tabSliceView";
            this.tabSliceView.Size = new System.Drawing.Size(1106, 514);
            this.tabSliceView.TabIndex = 2;
            this.tabSliceView.Text = "Slice Viewer";
            this.tabSliceView.UseVisualStyleBackColor = true;
            // 
            // picSlice
            // 
            this.picSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlice.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSlice.Location = new System.Drawing.Point(0, 0);
            this.picSlice.Name = "picSlice";
            this.picSlice.Size = new System.Drawing.Size(1106, 514);
            this.picSlice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSlice.TabIndex = 17;
            this.picSlice.TabStop = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmdBuild,
            this.cmdStop,
            this.toolStripSeparator1,
            this.cmbSerial,
            this.cmdRefresh,
            this.cmdConnect,
            this.cmdDisconnect,
            this.cmdControl,
            this.cmdSlice1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 28);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1114, 55);
            this.toolStrip1.Stretch = true;
            this.toolStrip1.TabIndex = 17;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmdBuild
            // 
            this.cmdBuild.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdBuild.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_004;
            this.cmdBuild.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdBuild.Name = "cmdBuild";
            this.cmdBuild.Size = new System.Drawing.Size(52, 52);
            this.cmdBuild.Text = "Start Build";
            this.cmdBuild.Click += new System.EventHandler(this.cmdStartPrint_Click);
            // 
            // cmdStop
            // 
            this.cmdStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdStop.Image = global::UV_DLP_3D_Printer.Properties.Resources.bfzn_006;
            this.cmdStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdStop.Name = "cmdStop";
            this.cmdStop.Size = new System.Drawing.Size(52, 52);
            this.cmdStop.Text = "Stop Build";
            this.cmdStop.Click += new System.EventHandler(this.cmdStop_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 55);
            // 
            // cmbSerial
            // 
            this.cmbSerial.Name = "cmbSerial";
            this.cmbSerial.Size = new System.Drawing.Size(121, 55);
            // 
            // cmdRefresh
            // 
            this.cmdRefresh.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdRefresh.Image = global::UV_DLP_3D_Printer.Properties.Resources.Refresh_icon;
            this.cmdRefresh.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdRefresh.Name = "cmdRefresh";
            this.cmdRefresh.Size = new System.Drawing.Size(52, 52);
            this.cmdRefresh.Text = "Refresh Port List";
            this.cmdRefresh.Click += new System.EventHandler(this.cmdRefresh_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdConnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Connect;
            this.cmdConnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(52, 52);
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect1_Click);
            // 
            // cmdDisconnect
            // 
            this.cmdDisconnect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdDisconnect.Image = global::UV_DLP_3D_Printer.Properties.Resources.Disconnect;
            this.cmdDisconnect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdDisconnect.Name = "cmdDisconnect";
            this.cmdDisconnect.Size = new System.Drawing.Size(52, 52);
            this.cmdDisconnect.Text = "Disconnect";
            this.cmdDisconnect.Click += new System.EventHandler(this.cmdDisconnect_Click);
            // 
            // cmdControl
            // 
            this.cmdControl.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdControl.Image = global::UV_DLP_3D_Printer.Properties.Resources.move;
            this.cmdControl.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdControl.Name = "cmdControl";
            this.cmdControl.Size = new System.Drawing.Size(52, 52);
            this.cmdControl.Text = "View Printer Controls";
            this.cmdControl.Click += new System.EventHandler(this.cmdControl_Click);
            // 
            // cmdSlice1
            // 
            this.cmdSlice1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.cmdSlice1.Image = global::UV_DLP_3D_Printer.Properties.Resources.slice;
            this.cmdSlice1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cmdSlice1.Name = "cmdSlice1";
            this.cmdSlice1.Size = new System.Drawing.Size(52, 52);
            this.cmdSlice1.Text = "Slice!";
            this.cmdSlice1.Click += new System.EventHandler(this.cmdSlice1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1144, 28);
            this.menuStrip1.TabIndex = 16;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadBinarySTLToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // loadBinarySTLToolStripMenuItem
            // 
            this.loadBinarySTLToolStripMenuItem.Name = "loadBinarySTLToolStripMenuItem";
            this.loadBinarySTLToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.loadBinarySTLToolStripMenuItem.Text = "Load Binary STL";
            this.loadBinarySTLToolStripMenuItem.Click += new System.EventHandler(this.loadBinarySTLToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 24);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.slicingOptionsToolStripMenuItem,
            this.machinePropertiesToolStripMenuItem,
            this.connectionToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // slicingOptionsToolStripMenuItem
            // 
            this.slicingOptionsToolStripMenuItem.Name = "slicingOptionsToolStripMenuItem";
            this.slicingOptionsToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.slicingOptionsToolStripMenuItem.Text = "Slicing Options";
            this.slicingOptionsToolStripMenuItem.Click += new System.EventHandler(this.slicingOptionsToolStripMenuItem_Click);
            // 
            // machinePropertiesToolStripMenuItem
            // 
            this.machinePropertiesToolStripMenuItem.Name = "machinePropertiesToolStripMenuItem";
            this.machinePropertiesToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.machinePropertiesToolStripMenuItem.Text = "Machine Properties";
            this.machinePropertiesToolStripMenuItem.Click += new System.EventHandler(this.machinePropertiesToolStripMenuItem_Click);
            // 
            // connectionToolStripMenuItem
            // 
            this.connectionToolStripMenuItem.Name = "connectionToolStripMenuItem";
            this.connectionToolStripMenuItem.Size = new System.Drawing.Size(205, 24);
            this.connectionToolStripMenuItem.Text = "Connection";
            this.connectionToolStripMenuItem.Click += new System.EventHandler(this.connectionToolStripMenuItem_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModel);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 21);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(299, 626);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabControl1.TabIndex = 16;
            // 
            // tabModel
            // 
            this.tabModel.Controls.Add(this.txtScale);
            this.tabModel.Controls.Add(this.cmdScale);
            this.tabModel.Controls.Add(this.cmdPlace);
            this.tabModel.Controls.Add(this.cmdCenter);
            this.tabModel.Controls.Add(this.chkWireframe);
            this.tabModel.Controls.Add(this.txtFileInfo);
            this.tabModel.Controls.Add(this.button1);
            this.tabModel.Location = new System.Drawing.Point(4, 25);
            this.tabModel.Name = "tabModel";
            this.tabModel.Padding = new System.Windows.Forms.Padding(3);
            this.tabModel.Size = new System.Drawing.Size(291, 597);
            this.tabModel.TabIndex = 0;
            this.tabModel.Text = "Model";
            this.tabModel.UseVisualStyleBackColor = true;
            // 
            // txtScale
            // 
            this.txtScale.Location = new System.Drawing.Point(136, 278);
            this.txtScale.Name = "txtScale";
            this.txtScale.Size = new System.Drawing.Size(68, 22);
            this.txtScale.TabIndex = 5;
            this.txtScale.Text = "1.0";
            // 
            // cmdScale
            // 
            this.cmdScale.Location = new System.Drawing.Point(6, 267);
            this.cmdScale.Name = "cmdScale";
            this.cmdScale.Size = new System.Drawing.Size(123, 45);
            this.cmdScale.TabIndex = 4;
            this.cmdScale.Text = "Scale";
            this.cmdScale.UseVisualStyleBackColor = true;
            this.cmdScale.Click += new System.EventHandler(this.cmdScale_Click);
            // 
            // cmdPlace
            // 
            this.cmdPlace.Location = new System.Drawing.Point(135, 202);
            this.cmdPlace.Name = "cmdPlace";
            this.cmdPlace.Size = new System.Drawing.Size(123, 45);
            this.cmdPlace.TabIndex = 3;
            this.cmdPlace.Text = "Place on Platform";
            this.cmdPlace.UseVisualStyleBackColor = true;
            this.cmdPlace.Click += new System.EventHandler(this.cmdPlace_Click);
            // 
            // cmdCenter
            // 
            this.cmdCenter.Location = new System.Drawing.Point(4, 202);
            this.cmdCenter.Name = "cmdCenter";
            this.cmdCenter.Size = new System.Drawing.Size(125, 45);
            this.cmdCenter.TabIndex = 2;
            this.cmdCenter.Text = "Center";
            this.cmdCenter.UseVisualStyleBackColor = true;
            this.cmdCenter.Click += new System.EventHandler(this.cmdCenter_Click);
            // 
            // chkWireframe
            // 
            this.chkWireframe.AutoSize = true;
            this.chkWireframe.Location = new System.Drawing.Point(6, 164);
            this.chkWireframe.Name = "chkWireframe";
            this.chkWireframe.Size = new System.Drawing.Size(95, 21);
            this.chkWireframe.TabIndex = 0;
            this.chkWireframe.Text = "Wireframe";
            this.chkWireframe.UseVisualStyleBackColor = true;
            this.chkWireframe.CheckedChanged += new System.EventHandler(this.chkWireframe_CheckedChanged);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.splitContainer1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.txtLog);
            this.splitContainer2.Size = new System.Drawing.Size(1457, 792);
            this.splitContainer2.SplitterDistance = 630;
            this.splitContainer2.TabIndex = 21;
            // 
            // txtLog
            // 
            this.txtLog.BackColor = System.Drawing.Color.White;
            this.txtLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLog.Font = new System.Drawing.Font("Courier New", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLog.Location = new System.Drawing.Point(0, 0);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(1457, 158);
            this.txtLog.TabIndex = 0;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 792);
            this.Controls.Add(this.splitContainer2);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMain";
            this.Text = "Creation Workshop - UV DLP 3D Printer Control and Slicing";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabMain.ResumeLayout(false);
            this.tabModel1.ResumeLayout(false);
            this.tabGCode.ResumeLayout(false);
            this.tabGCode.PerformLayout();
            this.tabSliceView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabModel.ResumeLayout(false);
            this.tabModel.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtFileInfo;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkWireframe;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModel;
        private System.Windows.Forms.Button cmdPlace;
        private System.Windows.Forms.Button cmdCenter;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Button cmdScale;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.PictureBox picSlice;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox txtGCode;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadBinarySTLToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem slicingOptionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem machinePropertiesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem connectionToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton cmdBuild;
        private System.Windows.Forms.ToolStripButton cmdStop;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripComboBox cmbSerial;
        private System.Windows.Forms.ToolStripButton cmdRefresh;
        private System.Windows.Forms.ToolStripButton cmdConnect;
        private System.Windows.Forms.ToolStripButton cmdDisconnect;
        private System.Windows.Forms.ToolStripButton cmdControl;
        private System.Windows.Forms.ToolStripButton cmdSlice1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tabModel1;
        private System.Windows.Forms.TabPage tabGCode;
        private System.Windows.Forms.TabPage tabSliceView;
    }
}

