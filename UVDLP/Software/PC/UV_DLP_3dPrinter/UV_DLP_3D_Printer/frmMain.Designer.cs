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
            this.cmdSlice = new System.Windows.Forms.Button();
            this.vScrollBar1 = new System.Windows.Forms.VScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.txtZThick = new System.Windows.Forms.TextBox();
            this.glControl1 = new OpenTK.GLControl();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabModel = new System.Windows.Forms.TabPage();
            this.txtScale = new System.Windows.Forms.TextBox();
            this.cmdScale = new System.Windows.Forms.Button();
            this.cmdPlace = new System.Windows.Forms.Button();
            this.cmdCenter = new System.Windows.Forms.Button();
            this.chkWireframe = new System.Windows.Forms.CheckBox();
            this.tabSlice = new System.Windows.Forms.TabPage();
            this.lblDirExport = new System.Windows.Forms.Label();
            this.cmdSelectDir = new System.Windows.Forms.Button();
            this.chkExportSlices = new System.Windows.Forms.CheckBox();
            this.cmdShowDLPfrm = new System.Windows.Forms.Button();
            this.picSlice = new System.Windows.Forms.PictureBox();
            this.lblNumSlices = new System.Windows.Forms.Label();
            this.prgSlice = new System.Windows.Forms.ProgressBar();
            this.tabPrint = new System.Windows.Forms.TabPage();
            this.cmdStartPrint = new System.Windows.Forms.Button();
            this.lblETC = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblLayerInd = new System.Windows.Forms.Label();
            this.lblLayerTime = new System.Windows.Forms.Label();
            this.txtLayerTime = new System.Windows.Forms.TextBox();
            this.chkPumpControl = new System.Windows.Forms.CheckBox();
            this.tabMachine = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblPixperMM = new System.Windows.Forms.Label();
            this.cmdSetPlatSize = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPlatHeight = new System.Windows.Forms.TextBox();
            this.txtPlatWidth = new System.Windows.Forms.TextBox();
            this.Monitors = new System.Windows.Forms.GroupBox();
            this.lblMonInfo = new System.Windows.Forms.Label();
            this.cmdRefreshMonitors = new System.Windows.Forms.Button();
            this.lstMonitors = new System.Windows.Forms.ListBox();
            this.cmdRefreshCom = new System.Windows.Forms.Button();
            this.cmdConnect = new System.Windows.Forms.Button();
            this.cmbSerialPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lblCurSlice = new System.Windows.Forms.Label();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabModel.SuspendLayout();
            this.tabSlice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).BeginInit();
            this.tabPrint.SuspendLayout();
            this.tabMachine.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.Monitors.SuspendLayout();
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
            this.txtFileInfo.Size = new System.Drawing.Size(509, 113);
            this.txtFileInfo.TabIndex = 1;
            // 
            // cmdSlice
            // 
            this.cmdSlice.Location = new System.Drawing.Point(34, 62);
            this.cmdSlice.Name = "cmdSlice";
            this.cmdSlice.Size = new System.Drawing.Size(122, 36);
            this.cmdSlice.TabIndex = 3;
            this.cmdSlice.Text = "Slice";
            this.cmdSlice.UseVisualStyleBackColor = true;
            this.cmdSlice.Click += new System.EventHandler(this.cmdSlice_Click);
            // 
            // vScrollBar1
            // 
            this.vScrollBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScrollBar1.Location = new System.Drawing.Point(3, 3);
            this.vScrollBar1.Maximum = 1000;
            this.vScrollBar1.Name = "vScrollBar1";
            this.vScrollBar1.Size = new System.Drawing.Size(21, 591);
            this.vScrollBar1.TabIndex = 11;
            this.vScrollBar1.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScrollBar1_Scroll);
            this.vScrollBar1.ValueChanged += new System.EventHandler(this.vScrollBar1_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Slice Thickness";
            // 
            // txtZThick
            // 
            this.txtZThick.Location = new System.Drawing.Point(43, 31);
            this.txtZThick.Name = "txtZThick";
            this.txtZThick.Size = new System.Drawing.Size(100, 22);
            this.txtZThick.TabIndex = 14;
            this.txtZThick.Text = ".025";
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.glControl1.Location = new System.Drawing.Point(0, 0);
            this.glControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(920, 626);
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
            this.splitContainer1.Panel1.Controls.Add(this.glControl1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Size = new System.Drawing.Size(1457, 630);
            this.splitContainer1.SplitterDistance = 924;
            this.splitContainer1.SplitterWidth = 6;
            this.splitContainer1.TabIndex = 20;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabModel);
            this.tabControl1.Controls.Add(this.tabSlice);
            this.tabControl1.Controls.Add(this.tabPrint);
            this.tabControl1.Controls.Add(this.tabMachine);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ItemSize = new System.Drawing.Size(110, 21);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(523, 626);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
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
            this.tabModel.Size = new System.Drawing.Size(515, 597);
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
            // tabSlice
            // 
            this.tabSlice.Controls.Add(this.lblCurSlice);
            this.tabSlice.Controls.Add(this.lblDirExport);
            this.tabSlice.Controls.Add(this.cmdSelectDir);
            this.tabSlice.Controls.Add(this.chkExportSlices);
            this.tabSlice.Controls.Add(this.cmdShowDLPfrm);
            this.tabSlice.Controls.Add(this.picSlice);
            this.tabSlice.Controls.Add(this.lblNumSlices);
            this.tabSlice.Controls.Add(this.prgSlice);
            this.tabSlice.Controls.Add(this.cmdSlice);
            this.tabSlice.Controls.Add(this.vScrollBar1);
            this.tabSlice.Controls.Add(this.txtZThick);
            this.tabSlice.Controls.Add(this.label1);
            this.tabSlice.Location = new System.Drawing.Point(4, 25);
            this.tabSlice.Name = "tabSlice";
            this.tabSlice.Padding = new System.Windows.Forms.Padding(3);
            this.tabSlice.Size = new System.Drawing.Size(515, 597);
            this.tabSlice.TabIndex = 1;
            this.tabSlice.Text = "Slice";
            this.tabSlice.UseVisualStyleBackColor = true;
            // 
            // lblDirExport
            // 
            this.lblDirExport.AutoSize = true;
            this.lblDirExport.Location = new System.Drawing.Point(34, 167);
            this.lblDirExport.Name = "lblDirExport";
            this.lblDirExport.Size = new System.Drawing.Size(16, 17);
            this.lblDirExport.TabIndex = 21;
            this.lblDirExport.Text = "./";
            // 
            // cmdSelectDir
            // 
            this.cmdSelectDir.Location = new System.Drawing.Point(151, 134);
            this.cmdSelectDir.Name = "cmdSelectDir";
            this.cmdSelectDir.Size = new System.Drawing.Size(109, 23);
            this.cmdSelectDir.TabIndex = 20;
            this.cmdSelectDir.Text = "Choose Dir";
            this.cmdSelectDir.UseVisualStyleBackColor = true;
            this.cmdSelectDir.Click += new System.EventHandler(this.cmdSelectDir_Click);
            // 
            // chkExportSlices
            // 
            this.chkExportSlices.AutoSize = true;
            this.chkExportSlices.Location = new System.Drawing.Point(34, 134);
            this.chkExportSlices.Name = "chkExportSlices";
            this.chkExportSlices.Size = new System.Drawing.Size(111, 21);
            this.chkExportSlices.TabIndex = 19;
            this.chkExportSlices.Text = "Export Slices";
            this.chkExportSlices.UseVisualStyleBackColor = true;
            // 
            // cmdShowDLPfrm
            // 
            this.cmdShowDLPfrm.Location = new System.Drawing.Point(40, 518);
            this.cmdShowDLPfrm.Name = "cmdShowDLPfrm";
            this.cmdShowDLPfrm.Size = new System.Drawing.Size(159, 23);
            this.cmdShowDLPfrm.TabIndex = 18;
            this.cmdShowDLPfrm.Text = "Show DLP screen";
            this.cmdShowDLPfrm.UseVisualStyleBackColor = true;
            this.cmdShowDLPfrm.Click += new System.EventHandler(this.button2_Click);
            // 
            // picSlice
            // 
            this.picSlice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSlice.Location = new System.Drawing.Point(34, 190);
            this.picSlice.Name = "picSlice";
            this.picSlice.Size = new System.Drawing.Size(464, 300);
            this.picSlice.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSlice.TabIndex = 17;
            this.picSlice.TabStop = false;
            // 
            // lblNumSlices
            // 
            this.lblNumSlices.AutoSize = true;
            this.lblNumSlices.Location = new System.Drawing.Point(199, 31);
            this.lblNumSlices.Name = "lblNumSlices";
            this.lblNumSlices.Size = new System.Drawing.Size(0, 17);
            this.lblNumSlices.TabIndex = 16;
            // 
            // prgSlice
            // 
            this.prgSlice.Location = new System.Drawing.Point(34, 104);
            this.prgSlice.Name = "prgSlice";
            this.prgSlice.Size = new System.Drawing.Size(359, 23);
            this.prgSlice.TabIndex = 15;
            // 
            // tabPrint
            // 
            this.tabPrint.Controls.Add(this.cmdStartPrint);
            this.tabPrint.Controls.Add(this.lblETC);
            this.tabPrint.Controls.Add(this.label3);
            this.tabPrint.Controls.Add(this.lblLayerInd);
            this.tabPrint.Controls.Add(this.lblLayerTime);
            this.tabPrint.Controls.Add(this.txtLayerTime);
            this.tabPrint.Controls.Add(this.chkPumpControl);
            this.tabPrint.Location = new System.Drawing.Point(4, 25);
            this.tabPrint.Name = "tabPrint";
            this.tabPrint.Size = new System.Drawing.Size(515, 597);
            this.tabPrint.TabIndex = 2;
            this.tabPrint.Text = "Print";
            this.tabPrint.UseVisualStyleBackColor = true;
            // 
            // cmdStartPrint
            // 
            this.cmdStartPrint.Location = new System.Drawing.Point(14, 234);
            this.cmdStartPrint.Name = "cmdStartPrint";
            this.cmdStartPrint.Size = new System.Drawing.Size(135, 34);
            this.cmdStartPrint.TabIndex = 6;
            this.cmdStartPrint.Text = "Start Print";
            this.cmdStartPrint.UseVisualStyleBackColor = true;
            this.cmdStartPrint.Click += new System.EventHandler(this.cmdStartPrint_Click);
            // 
            // lblETC
            // 
            this.lblETC.AutoSize = true;
            this.lblETC.Location = new System.Drawing.Point(154, 151);
            this.lblETC.Name = "lblETC";
            this.lblETC.Size = new System.Drawing.Size(70, 17);
            this.lblETC.TabIndex = 5;
            this.lblETC.Text = "0H:0M:0S";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Time to Completion";
            // 
            // lblLayerInd
            // 
            this.lblLayerInd.AutoSize = true;
            this.lblLayerInd.Location = new System.Drawing.Point(14, 119);
            this.lblLayerInd.Name = "lblLayerInd";
            this.lblLayerInd.Size = new System.Drawing.Size(138, 17);
            this.lblLayerInd.TabIndex = 3;
            this.lblLayerInd.Text = "Printing Layer X of Y";
            // 
            // lblLayerTime
            // 
            this.lblLayerTime.AutoSize = true;
            this.lblLayerTime.Location = new System.Drawing.Point(14, 62);
            this.lblLayerTime.Name = "lblLayerTime";
            this.lblLayerTime.Size = new System.Drawing.Size(258, 17);
            this.lblLayerTime.TabIndex = 2;
            this.lblLayerTime.Text = "Exposure Time Per Layer (milliseconds)";
            // 
            // txtLayerTime
            // 
            this.txtLayerTime.Location = new System.Drawing.Point(14, 82);
            this.txtLayerTime.Name = "txtLayerTime";
            this.txtLayerTime.Size = new System.Drawing.Size(100, 22);
            this.txtLayerTime.TabIndex = 1;
            this.txtLayerTime.Text = "5000";
            // 
            // chkPumpControl
            // 
            this.chkPumpControl.AutoSize = true;
            this.chkPumpControl.Location = new System.Drawing.Point(14, 21);
            this.chkPumpControl.Name = "chkPumpControl";
            this.chkPumpControl.Size = new System.Drawing.Size(155, 21);
            this.chkPumpControl.TabIndex = 0;
            this.chkPumpControl.Text = "Control Resin Pump";
            this.chkPumpControl.UseVisualStyleBackColor = true;
            // 
            // tabMachine
            // 
            this.tabMachine.Controls.Add(this.groupBox1);
            this.tabMachine.Controls.Add(this.Monitors);
            this.tabMachine.Controls.Add(this.cmdRefreshCom);
            this.tabMachine.Controls.Add(this.cmdConnect);
            this.tabMachine.Controls.Add(this.cmbSerialPort);
            this.tabMachine.Controls.Add(this.label4);
            this.tabMachine.Location = new System.Drawing.Point(4, 25);
            this.tabMachine.Name = "tabMachine";
            this.tabMachine.Size = new System.Drawing.Size(515, 597);
            this.tabMachine.TabIndex = 3;
            this.tabMachine.Text = "Machine";
            this.tabMachine.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblPixperMM);
            this.groupBox1.Controls.Add(this.cmdSetPlatSize);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txtPlatHeight);
            this.groupBox1.Controls.Add(this.txtPlatWidth);
            this.groupBox1.Location = new System.Drawing.Point(18, 315);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 147);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Build Platform Area (mm)";
            // 
            // lblPixperMM
            // 
            this.lblPixperMM.AutoSize = true;
            this.lblPixperMM.Location = new System.Drawing.Point(10, 109);
            this.lblPixperMM.Name = "lblPixperMM";
            this.lblPixperMM.Size = new System.Drawing.Size(96, 17);
            this.lblPixperMM.TabIndex = 5;
            this.lblPixperMM.Text = "Pixels Per MM";
            // 
            // cmdSetPlatSize
            // 
            this.cmdSetPlatSize.Location = new System.Drawing.Point(10, 61);
            this.cmdSetPlatSize.Name = "cmdSetPlatSize";
            this.cmdSetPlatSize.Size = new System.Drawing.Size(317, 23);
            this.cmdSetPlatSize.TabIndex = 4;
            this.cmdSetPlatSize.Text = "Set Size";
            this.cmdSetPlatSize.UseVisualStyleBackColor = true;
            this.cmdSetPlatSize.Click += new System.EventHandler(this.cmdSetPlatSize_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 17);
            this.label6.TabIndex = 3;
            this.label6.Text = "Height";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Width";
            // 
            // txtPlatHeight
            // 
            this.txtPlatHeight.Location = new System.Drawing.Point(227, 33);
            this.txtPlatHeight.Name = "txtPlatHeight";
            this.txtPlatHeight.Size = new System.Drawing.Size(100, 22);
            this.txtPlatHeight.TabIndex = 1;
            this.txtPlatHeight.Text = "77";
            // 
            // txtPlatWidth
            // 
            this.txtPlatWidth.Location = new System.Drawing.Point(57, 33);
            this.txtPlatWidth.Name = "txtPlatWidth";
            this.txtPlatWidth.Size = new System.Drawing.Size(100, 22);
            this.txtPlatWidth.TabIndex = 0;
            this.txtPlatWidth.Text = "102";
            // 
            // Monitors
            // 
            this.Monitors.Controls.Add(this.lblMonInfo);
            this.Monitors.Controls.Add(this.cmdRefreshMonitors);
            this.Monitors.Controls.Add(this.lstMonitors);
            this.Monitors.Location = new System.Drawing.Point(18, 126);
            this.Monitors.Name = "Monitors";
            this.Monitors.Size = new System.Drawing.Size(357, 183);
            this.Monitors.TabIndex = 8;
            this.Monitors.TabStop = false;
            this.Monitors.Text = "Select Print Display Device";
            // 
            // lblMonInfo
            // 
            this.lblMonInfo.AutoSize = true;
            this.lblMonInfo.Location = new System.Drawing.Point(7, 117);
            this.lblMonInfo.Name = "lblMonInfo";
            this.lblMonInfo.Size = new System.Drawing.Size(0, 17);
            this.lblMonInfo.TabIndex = 2;
            // 
            // cmdRefreshMonitors
            // 
            this.cmdRefreshMonitors.Location = new System.Drawing.Point(6, 154);
            this.cmdRefreshMonitors.Name = "cmdRefreshMonitors";
            this.cmdRefreshMonitors.Size = new System.Drawing.Size(176, 23);
            this.cmdRefreshMonitors.TabIndex = 1;
            this.cmdRefreshMonitors.Text = "Refresh";
            this.cmdRefreshMonitors.UseVisualStyleBackColor = true;
            this.cmdRefreshMonitors.Click += new System.EventHandler(this.cmdRefreshMonitors_Click);
            // 
            // lstMonitors
            // 
            this.lstMonitors.FormattingEnabled = true;
            this.lstMonitors.ItemHeight = 16;
            this.lstMonitors.Location = new System.Drawing.Point(7, 26);
            this.lstMonitors.Name = "lstMonitors";
            this.lstMonitors.Size = new System.Drawing.Size(301, 84);
            this.lstMonitors.TabIndex = 0;
            this.lstMonitors.SelectedIndexChanged += new System.EventHandler(this.lstMonitors_SelectedIndexChanged);
            // 
            // cmdRefreshCom
            // 
            this.cmdRefreshCom.Location = new System.Drawing.Point(258, 57);
            this.cmdRefreshCom.Name = "cmdRefreshCom";
            this.cmdRefreshCom.Size = new System.Drawing.Size(96, 24);
            this.cmdRefreshCom.TabIndex = 3;
            this.cmdRefreshCom.Text = "Refresh";
            this.cmdRefreshCom.UseVisualStyleBackColor = true;
            this.cmdRefreshCom.Click += new System.EventHandler(this.cmdRefreshCom_Click);
            // 
            // cmdConnect
            // 
            this.cmdConnect.Location = new System.Drawing.Point(18, 87);
            this.cmdConnect.Name = "cmdConnect";
            this.cmdConnect.Size = new System.Drawing.Size(234, 33);
            this.cmdConnect.TabIndex = 2;
            this.cmdConnect.Text = "Connect";
            this.cmdConnect.UseVisualStyleBackColor = true;
            this.cmdConnect.Click += new System.EventHandler(this.cmdConnect_Click);
            // 
            // cmbSerialPort
            // 
            this.cmbSerialPort.FormattingEnabled = true;
            this.cmbSerialPort.Location = new System.Drawing.Point(18, 57);
            this.cmbSerialPort.Name = "cmbSerialPort";
            this.cmbSerialPort.Size = new System.Drawing.Size(234, 24);
            this.cmbSerialPort.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(134, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Communication Port";
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
            // lblCurSlice
            // 
            this.lblCurSlice.AutoSize = true;
            this.lblCurSlice.Location = new System.Drawing.Point(181, 62);
            this.lblCurSlice.Name = "lblCurSlice";
            this.lblCurSlice.Size = new System.Drawing.Size(0, 17);
            this.lblCurSlice.TabIndex = 22;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1457, 792);
            this.Controls.Add(this.splitContainer2);
            this.Name = "frmMain";
            this.Text = "UV DLP 3D Printer control and slicing app";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabModel.ResumeLayout(false);
            this.tabModel.PerformLayout();
            this.tabSlice.ResumeLayout(false);
            this.tabSlice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSlice)).EndInit();
            this.tabPrint.ResumeLayout(false);
            this.tabPrint.PerformLayout();
            this.tabMachine.ResumeLayout(false);
            this.tabMachine.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.Monitors.ResumeLayout(false);
            this.Monitors.PerformLayout();
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
        private System.Windows.Forms.Button cmdSlice;
        private System.Windows.Forms.VScrollBar vScrollBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtZThick;
        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.CheckBox chkWireframe;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabModel;
        private System.Windows.Forms.Button cmdPlace;
        private System.Windows.Forms.Button cmdCenter;
        private System.Windows.Forms.TabPage tabSlice;
        private System.Windows.Forms.TabPage tabPrint;
        private System.Windows.Forms.TabPage tabMachine;
        private System.Windows.Forms.ProgressBar prgSlice;
        private System.Windows.Forms.Button cmdStartPrint;
        private System.Windows.Forms.Label lblETC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblLayerInd;
        private System.Windows.Forms.Label lblLayerTime;
        private System.Windows.Forms.TextBox txtLayerTime;
        private System.Windows.Forms.CheckBox chkPumpControl;
        private System.Windows.Forms.Button cmdRefreshCom;
        private System.Windows.Forms.Button cmdConnect;
        private System.Windows.Forms.ComboBox cmbSerialPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtScale;
        private System.Windows.Forms.Button cmdScale;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox txtLog;
        private System.Windows.Forms.GroupBox Monitors;
        private System.Windows.Forms.Label lblMonInfo;
        private System.Windows.Forms.Button cmdRefreshMonitors;
        private System.Windows.Forms.ListBox lstMonitors;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPlatHeight;
        private System.Windows.Forms.TextBox txtPlatWidth;
        private System.Windows.Forms.Button cmdSetPlatSize;
        private System.Windows.Forms.Label lblPixperMM;
        private System.Windows.Forms.Label lblNumSlices;
        private System.Windows.Forms.PictureBox picSlice;
        private System.Windows.Forms.Button cmdShowDLPfrm;
        private System.Windows.Forms.Label lblDirExport;
        private System.Windows.Forms.Button cmdSelectDir;
        private System.Windows.Forms.CheckBox chkExportSlices;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label lblCurSlice;
    }
}

