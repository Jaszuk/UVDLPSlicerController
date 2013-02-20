namespace UV_DLP_3D_Printer.GUI
{
    partial class frmControl
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
            this.cmdDown = new System.Windows.Forms.Button();
            this.cmdUp = new System.Windows.Forms.Button();
            this.txtdist = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmdDown
            // 
            this.cmdDown.Image = global::UV_DLP_3D_Printer.Properties.Resources.Down1Blue;
            this.cmdDown.Location = new System.Drawing.Point(70, 152);
            this.cmdDown.Name = "cmdDown";
            this.cmdDown.Size = new System.Drawing.Size(72, 72);
            this.cmdDown.TabIndex = 1;
            this.cmdDown.UseVisualStyleBackColor = true;
            this.cmdDown.Click += new System.EventHandler(this.cmdDown_Click);
            // 
            // cmdUp
            // 
            this.cmdUp.Image = global::UV_DLP_3D_Printer.Properties.Resources.Up1Blue;
            this.cmdUp.Location = new System.Drawing.Point(70, 30);
            this.cmdUp.Name = "cmdUp";
            this.cmdUp.Size = new System.Drawing.Size(72, 72);
            this.cmdUp.TabIndex = 0;
            this.cmdUp.UseVisualStyleBackColor = true;
            this.cmdUp.Click += new System.EventHandler(this.cmdUp_Click);
            // 
            // txtdist
            // 
            this.txtdist.Location = new System.Drawing.Point(70, 118);
            this.txtdist.Name = "txtdist";
            this.txtdist.Size = new System.Drawing.Size(72, 22);
            this.txtdist.TabIndex = 2;
            this.txtdist.Text = ".05";
            this.txtdist.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(149, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "mm";
            // 
            // frmControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(237, 299);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtdist);
            this.Controls.Add(this.cmdDown);
            this.Controls.Add(this.cmdUp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmControl";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Printer Control";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cmdUp;
        private System.Windows.Forms.Button cmdDown;
        private System.Windows.Forms.TextBox txtdist;
        private System.Windows.Forms.Label label1;
    }
}