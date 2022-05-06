
namespace EMediaSol.Fourier
{
    partial class FourierTransform_Form
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
            this.FourierMag = new System.Windows.Forms.PictureBox();
            this.FourierPhase = new System.Windows.Forms.PictureBox();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.FourierMag)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierPhase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // FourierMag
            // 
            this.FourierMag.Location = new System.Drawing.Point(292, 12);
            this.FourierMag.Name = "FourierMag";
            this.FourierMag.Size = new System.Drawing.Size(262, 258);
            this.FourierMag.TabIndex = 0;
            this.FourierMag.TabStop = false;
            // 
            // FourierPhase
            // 
            this.FourierPhase.Location = new System.Drawing.Point(596, 12);
            this.FourierPhase.Name = "FourierPhase";
            this.FourierPhase.Size = new System.Drawing.Size(250, 258);
            this.FourierPhase.TabIndex = 1;
            this.FourierPhase.TabStop = false;
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(260, 238);
            this.pictureBox_Image.TabIndex = 2;
            this.pictureBox_Image.TabStop = false;
            // 
            // FourierTransform_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 570);
            this.Controls.Add(this.pictureBox_Image);
            this.Controls.Add(this.FourierPhase);
            this.Controls.Add(this.FourierMag);
            this.Name = "FourierTransform_Form";
            this.Text = "FourierTransform_Form";
            this.Load += new System.EventHandler(this.FourierTransform_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FourierMag)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.FourierPhase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox FourierMag;
        private System.Windows.Forms.PictureBox FourierPhase;
        private System.Windows.Forms.PictureBox pictureBox_Image;
    }
}