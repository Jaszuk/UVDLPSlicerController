namespace UV_DLP_3D_Printer
{
    partial class frmSliceOptions
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
            this.chkExportSlices = new System.Windows.Forms.CheckBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkgengcode = new System.Windows.Forms.CheckBox();
            this.lblLayerTime = new System.Windows.Forms.Label();
            this.txtLayerTime = new System.Windows.Forms.TextBox();
            this.txtZThick = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkexportsvg = new System.Windows.Forms.CheckBox();
            this.cmdCancel = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFirstLayerTime = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtXOffset = new System.Windows.Forms.TextBox();
            this.txtYOffset = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBlankTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtLiftDistance = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbBuildDirection = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // chkExportSlices
            // 
            this.chkExportSlices.AutoSize = true;
            this.chkExportSlices.Location = new System.Drawing.Point(21, 245);
            this.chkExportSlices.Name = "chkExportSlices";
            this.chkExportSlices.Size = new System.Drawing.Size(153, 21);
            this.chkExportSlices.TabIndex = 21;
            this.chkExportSlices.Text = "Export Image Slices";
            this.chkExportSlices.UseVisualStyleBackColor = true;
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(36, 306);
            this.cmdOK.Name = "cmdOK";
            this.cmdOK.Size = new System.Drawing.Size(129, 41);
            this.cmdOK.TabIndex = 24;
            this.cmdOK.Text = "OK";
            this.cmdOK.UseVisualStyleBackColor = true;
            this.cmdOK.Click += new System.EventHandler(this.cmdOK_Click);
            // 
            // chkgengcode
            // 
            this.chkgengcode.AutoSize = true;
            this.chkgengcode.Location = new System.Drawing.Point(21, 218);
            this.chkgengcode.Name = "chkgengcode";
            this.chkgengcode.Size = new System.Drawing.Size(138, 21);
            this.chkgengcode.TabIndex = 25;
            this.chkgengcode.Text = "Generate GCode";
            this.chkgengcode.UseVisualStyleBackColor = true;
            // 
            // lblLayerTime
            // 
            this.lblLayerTime.AutoSize = true;
            this.lblLayerTime.Location = new System.Drawing.Point(18, 54);
            this.lblLayerTime.Name = "lblLayerTime";
            this.lblLayerTime.Size = new System.Drawing.Size(200, 17);
            this.lblLayerTime.TabIndex = 27;
            this.lblLayerTime.Text = "Exposure Time Per Layer (ms)";
            // 
            // txtLayerTime
            // 
            this.txtLayerTime.Location = new System.Drawing.Point(21, 74);
            this.txtLayerTime.Name = "txtLayerTime";
            this.txtLayerTime.Size = new System.Drawing.Size(100, 22);
            this.txtLayerTime.TabIndex = 26;
            this.txtLayerTime.Text = "5000";
            // 
            // txtZThick
            // 
            this.txtZThick.Location = new System.Drawing.Point(21, 29);
            this.txtZThick.Name = "txtZThick";
            this.txtZThick.Size = new System.Drawing.Size(100, 22);
            this.txtZThick.TabIndex = 29;
            this.txtZThick.Text = ".025";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 17);
            this.label1.TabIndex = 28;
            this.label1.Text = "Slice Thickness (mm)";
            // 
            // chkexportsvg
            // 
            this.chkexportsvg.AutoSize = true;
            this.chkexportsvg.Enabled = false;
            this.chkexportsvg.Location = new System.Drawing.Point(21, 272);
            this.chkexportsvg.Name = "chkexportsvg";
            this.chkexportsvg.Size = new System.Drawing.Size(144, 21);
            this.chkexportsvg.TabIndex = 30;
            this.chkexportsvg.Text = "Export SVG Slices";
            this.chkexportsvg.UseVisualStyleBackColor = true;
            // 
            // cmdCancel
            // 
            this.cmdCancel.Location = new System.Drawing.Point(171, 306);
            this.cmdCancel.Name = "cmdCancel";
            this.cmdCancel.Size = new System.Drawing.Size(129, 41);
            this.cmdCancel.TabIndex = 31;
            this.cmdCancel.Text = "Cancel";
            this.cmdCancel.UseVisualStyleBackColor = true;
            this.cmdCancel.Click += new System.EventHandler(this.cmdCancel_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 101);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(205, 17);
            this.label2.TabIndex = 33;
            this.label2.Text = "First Layer Exposure Time (ms)";
            // 
            // txtFirstLayerTime
            // 
            this.txtFirstLayerTime.Location = new System.Drawing.Point(21, 121);
            this.txtFirstLayerTime.Name = "txtFirstLayerTime";
            this.txtFirstLayerTime.Size = new System.Drawing.Size(100, 22);
            this.txtFirstLayerTime.TabIndex = 32;
            this.txtFirstLayerTime.Text = "5000";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtYOffset);
            this.groupBox1.Controls.Add(this.txtXOffset);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(299, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(229, 109);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generated Image Pixel Offsets";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "X Offset";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 65);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "Y Offset";
            // 
            // txtXOffset
            // 
            this.txtXOffset.Location = new System.Drawing.Point(72, 24);
            this.txtXOffset.Name = "txtXOffset";
            this.txtXOffset.Size = new System.Drawing.Size(68, 22);
            this.txtXOffset.TabIndex = 2;
            this.txtXOffset.Text = "0";
            // 
            // txtYOffset
            // 
            this.txtYOffset.Location = new System.Drawing.Point(72, 65);
            this.txtYOffset.Name = "txtYOffset";
            this.txtYOffset.Size = new System.Drawing.Size(68, 22);
            this.txtYOffset.TabIndex = 3;
            this.txtYOffset.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(234, 17);
            this.label5.TabIndex = 36;
            this.label5.Text = "Blanking Time Between Layers (ms)";
            // 
            // txtBlankTime
            // 
            this.txtBlankTime.Location = new System.Drawing.Point(21, 166);
            this.txtBlankTime.Name = "txtBlankTime";
            this.txtBlankTime.Size = new System.Drawing.Size(100, 22);
            this.txtBlankTime.TabIndex = 35;
            this.txtBlankTime.Text = "5000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(296, 146);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 17);
            this.label6.TabIndex = 38;
            this.label6.Text = "Lift Distance (mm)";
            // 
            // txtLiftDistance
            // 
            this.txtLiftDistance.Location = new System.Drawing.Point(297, 166);
            this.txtLiftDistance.Name = "txtLiftDistance";
            this.txtLiftDistance.Size = new System.Drawing.Size(100, 22);
            this.txtLiftDistance.TabIndex = 37;
            this.txtLiftDistance.Text = "5";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(429, 146);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(99, 17);
            this.label7.TabIndex = 39;
            this.label7.Text = "Build Direction";
            // 
            // cmbBuildDirection
            // 
            this.cmbBuildDirection.FormattingEnabled = true;
            this.cmbBuildDirection.Location = new System.Drawing.Point(432, 166);
            this.cmbBuildDirection.Name = "cmbBuildDirection";
            this.cmbBuildDirection.Size = new System.Drawing.Size(121, 24);
            this.cmbBuildDirection.TabIndex = 40;
            // 
            // frmSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(614, 361);
            this.Controls.Add(this.cmbBuildDirection);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtLiftDistance);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBlankTime);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtFirstLayerTime);
            this.Controls.Add(this.cmdCancel);
            this.Controls.Add(this.chkexportsvg);
            this.Controls.Add(this.txtZThick);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblLayerTime);
            this.Controls.Add(this.txtLayerTime);
            this.Controls.Add(this.chkgengcode);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.chkExportSlices);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSliceOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Slicing and Building Options";
            this.Load += new System.EventHandler(this.frmSliceOptions_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chkExportSlices;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkgengcode;
        private System.Windows.Forms.Label lblLayerTime;
        private System.Windows.Forms.TextBox txtLayerTime;
        private System.Windows.Forms.TextBox txtZThick;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkexportsvg;
        private System.Windows.Forms.Button cmdCancel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFirstLayerTime;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtYOffset;
        private System.Windows.Forms.TextBox txtXOffset;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtBlankTime;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtLiftDistance;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbBuildDirection;
    }
}