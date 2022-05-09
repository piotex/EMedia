
namespace EMediaSol.Forms
{
    partial class FourierTransformForm
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
            this.pictureBox_amp = new System.Windows.Forms.PictureBox();
            this.pictureBox_phase = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_amp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_phase)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_amp
            // 
            this.pictureBox_amp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_amp.Location = new System.Drawing.Point(12, 63);
            this.pictureBox_amp.Name = "pictureBox_amp";
            this.pictureBox_amp.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_amp.TabIndex = 0;
            this.pictureBox_amp.TabStop = false;
            // 
            // pictureBox_phase
            // 
            this.pictureBox_phase.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox_phase.Location = new System.Drawing.Point(118, 63);
            this.pictureBox_phase.Name = "pictureBox_phase";
            this.pictureBox_phase.Size = new System.Drawing.Size(100, 50);
            this.pictureBox_phase.TabIndex = 1;
            this.pictureBox_phase.TabStop = false;
            // 
            // trackBar1
            // 
            this.trackBar1.LargeChange = 1;
            this.trackBar1.Location = new System.Drawing.Point(12, 12);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(649, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.Value = 1;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(708, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Pokaż Transformate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(667, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "label1";
            // 
            // FourierTransformForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.pictureBox_phase);
            this.Controls.Add(this.pictureBox_amp);
            this.Name = "FourierTransformForm";
            this.Text = "FourierTransformForm";
            this.Load += new System.EventHandler(this.FourierTransformForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_amp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_phase)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_amp;
        private System.Windows.Forms.PictureBox pictureBox_phase;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}