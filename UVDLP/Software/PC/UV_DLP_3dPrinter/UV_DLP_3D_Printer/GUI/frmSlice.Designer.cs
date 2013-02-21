namespace UV_DLP_3D_Printer.GUI
{
    partial class frmSlice
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
            this.cmdSliceOptions = new System.Windows.Forms.Button();
            this.lblMessage = new System.Windows.Forms.Label();
            this.prgSlice = new System.Windows.Forms.ProgressBar();
            this.cmdSlice = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmdSliceOptions
            // 
            this.cmdSliceOptions.Location = new System.Drawing.Point(166, 12);
            this.cmdSliceOptions.Name = "cmdSliceOptions";
            this.cmdSliceOptions.Size = new System.Drawing.Size(122, 36);
            this.cmdSliceOptions.TabIndex = 27;
            this.cmdSliceOptions.Text = "Options";
            this.cmdSliceOptions.UseVisualStyleBackColor = true;
            this.cmdSliceOptions.Click += new System.EventHandler(this.cmdSliceOptions_Click);
            // 
            // lblMessage
            // 
            this.lblMessage.AutoSize = true;
            this.lblMessage.Location = new System.Drawing.Point(150, 65);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(0, 17);
            this.lblMessage.TabIndex = 26;
            // 
            // prgSlice
            // 
            this.prgSlice.Location = new System.Drawing.Point(12, 107);
            this.prgSlice.Name = "prgSlice";
            this.prgSlice.Size = new System.Drawing.Size(453, 23);
            this.prgSlice.TabIndex = 25;
            // 
            // cmdSlice
            // 
            this.cmdSlice.Location = new System.Drawing.Point(166, 147);
            this.cmdSlice.Name = "cmdSlice";
            this.cmdSlice.Size = new System.Drawing.Size(122, 36);
            this.cmdSlice.TabIndex = 24;
            this.cmdSlice.Text = "Slice";
            this.cmdSlice.UseVisualStyleBackColor = true;
            this.cmdSlice.Click += new System.EventHandler(this.cmdSlice_Click);
            // 
            // frmSlice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(477, 195);
            this.Controls.Add(this.cmdSliceOptions);
            this.Controls.Add(this.lblMessage);
            this.Controls.Add(this.prgSlice);
            this.Controls.Add(this.cmdSlice);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmSlice";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Slice!";
            this.TopMost = true;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmSlice_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdSliceOptions;
        private System.Windows.Forms.Label lblMessage;
        private System.Windows.Forms.ProgressBar prgSlice;
        private System.Windows.Forms.Button cmdSlice;
    }
}