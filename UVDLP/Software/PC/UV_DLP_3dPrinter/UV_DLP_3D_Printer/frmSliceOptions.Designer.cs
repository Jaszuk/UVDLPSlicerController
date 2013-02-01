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
            this.cmdSelectDir = new System.Windows.Forms.Button();
            this.chkExportSlices = new System.Windows.Forms.CheckBox();
            this.lblWorkingDir = new System.Windows.Forms.Label();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.cmdOK = new System.Windows.Forms.Button();
            this.chkgengcode = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cmdSelectDir
            // 
            this.cmdSelectDir.Location = new System.Drawing.Point(12, 97);
            this.cmdSelectDir.Name = "cmdSelectDir";
            this.cmdSelectDir.Size = new System.Drawing.Size(109, 23);
            this.cmdSelectDir.TabIndex = 22;
            this.cmdSelectDir.Text = "Choose Dir";
            this.cmdSelectDir.UseVisualStyleBackColor = true;
            this.cmdSelectDir.Click += new System.EventHandler(this.cmdSelectDir_Click);
            // 
            // chkExportSlices
            // 
            this.chkExportSlices.AutoSize = true;
            this.chkExportSlices.Location = new System.Drawing.Point(12, 12);
            this.chkExportSlices.Name = "chkExportSlices";
            this.chkExportSlices.Size = new System.Drawing.Size(111, 21);
            this.chkExportSlices.TabIndex = 21;
            this.chkExportSlices.Text = "Export Slices";
            this.chkExportSlices.UseVisualStyleBackColor = true;
            // 
            // lblWorkingDir
            // 
            this.lblWorkingDir.AutoSize = true;
            this.lblWorkingDir.Location = new System.Drawing.Point(12, 77);
            this.lblWorkingDir.Name = "lblWorkingDir";
            this.lblWorkingDir.Size = new System.Drawing.Size(25, 17);
            this.lblWorkingDir.TabIndex = 23;
            this.lblWorkingDir.Text = "C:\\";
            // 
            // cmdOK
            // 
            this.cmdOK.Location = new System.Drawing.Point(223, 162);
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
            this.chkgengcode.Location = new System.Drawing.Point(12, 39);
            this.chkgengcode.Name = "chkgengcode";
            this.chkgengcode.Size = new System.Drawing.Size(138, 21);
            this.chkgengcode.TabIndex = 25;
            this.chkgengcode.Text = "Generate GCode";
            this.chkgengcode.UseVisualStyleBackColor = true;
            // 
            // frmSliceOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 236);
            this.Controls.Add(this.chkgengcode);
            this.Controls.Add(this.cmdOK);
            this.Controls.Add(this.lblWorkingDir);
            this.Controls.Add(this.cmdSelectDir);
            this.Controls.Add(this.chkExportSlices);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmSliceOptions";
            this.Text = "Slicing Options";
            this.Load += new System.EventHandler(this.frmSliceOptions_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSelectDir;
        private System.Windows.Forms.CheckBox chkExportSlices;
        private System.Windows.Forms.Label lblWorkingDir;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button cmdOK;
        private System.Windows.Forms.CheckBox chkgengcode;
    }
}