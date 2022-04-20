
namespace FaceRecognitionCSharp
{
    partial class Form1
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.imgDetectFace = new System.Windows.Forms.PictureBox();
            this.imgCamera = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblFaceName = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDetectFace)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(79)))), ((int)(((byte)(130)))));
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 464);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 44);
            this.panel2.TabIndex = 101;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(43, 10);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 28);
            this.label1.TabIndex = 98;
            this.label1.Text = "CAPTURED FACE";
            // 
            // imgDetectFace
            // 
            this.imgDetectFace.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgDetectFace.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.imgDetectFace.Location = new System.Drawing.Point(0, 508);
            this.imgDetectFace.Margin = new System.Windows.Forms.Padding(4);
            this.imgDetectFace.Name = "imgDetectFace";
            this.imgDetectFace.Size = new System.Drawing.Size(251, 176);
            this.imgDetectFace.TabIndex = 100;
            this.imgDetectFace.TabStop = false;
            // 
            // imgCamera
            // 
            this.imgCamera.Dock = System.Windows.Forms.DockStyle.Fill;
            this.imgCamera.Location = new System.Drawing.Point(0, 0);
            this.imgCamera.Margin = new System.Windows.Forms.Padding(4);
            this.imgCamera.Name = "imgCamera";
            this.imgCamera.Size = new System.Drawing.Size(903, 590);
            this.imgCamera.TabIndex = 99;
            this.imgCamera.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.lblFaceName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 590);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(903, 115);
            this.panel1.TabIndex = 98;
            // 
            // lblFaceName
            // 
            this.lblFaceName.AutoSize = true;
            this.lblFaceName.Location = new System.Drawing.Point(323, 20);
            this.lblFaceName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFaceName.Name = "lblFaceName";
            this.lblFaceName.Size = new System.Drawing.Size(46, 17);
            this.lblFaceName.TabIndex = 13;
            this.lblFaceName.Text = "label1";
            this.lblFaceName.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(105)))), ((int)(((byte)(48)))));
            this.button1.Dock = System.Windows.Forms.DockStyle.Right;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(665, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 113);
            this.button1.TabIndex = 14;
            this.button1.Text = "ADD FACE RECORD";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 705);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.imgDetectFace);
            this.Controls.Add(this.imgCamera);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgDetectFace)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCamera)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox imgDetectFace;
        private System.Windows.Forms.PictureBox imgCamera;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblFaceName;
    }
}

