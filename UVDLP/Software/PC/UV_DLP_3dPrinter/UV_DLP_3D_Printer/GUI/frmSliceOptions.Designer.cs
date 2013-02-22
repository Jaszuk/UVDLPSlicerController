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
            this.txtFirstLayerTime.Location = new System.Drawing.Point(23, 121);
            this.txtFirstLayerTime.Name = "txtFirstLayerTime";
            this.txtFirstLayerTime.Size = new System.Drawing.Size(100, 22);
            this.txtFirstLayerTime.TabIndex = 32;
            this.txtFirstLayerTime.Text = "5000";
            // 
            // frmSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(351, 365);
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
            this.Text = "Slicing Options";
            this.Load += new System.EventHandler(this.frmSliceOptions_Load);
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
    }
}