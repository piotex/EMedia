
namespace EMediaSol.Forms
{
    partial class MainForm
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
            this.button_ReadIMG = new System.Windows.Forms.Button();
            this.button_ShowChunks = new System.Windows.Forms.Button();
            this.button_ShowFFT = new System.Windows.Forms.Button();
            this.button_MakeAnonim = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ReadIMG
            // 
            this.button_ReadIMG.Location = new System.Drawing.Point(12, 12);
            this.button_ReadIMG.Name = "button_ReadIMG";
            this.button_ReadIMG.Size = new System.Drawing.Size(145, 47);
            this.button_ReadIMG.TabIndex = 0;
            this.button_ReadIMG.Text = "Wczytaj Obraz Png";
            this.button_ReadIMG.UseVisualStyleBackColor = true;
            this.button_ReadIMG.Click += new System.EventHandler(this.button_ReadIMG_Click);
            // 
            // button_ShowChunks
            // 
            this.button_ShowChunks.Location = new System.Drawing.Point(12, 65);
            this.button_ShowChunks.Name = "button_ShowChunks";
            this.button_ShowChunks.Size = new System.Drawing.Size(145, 47);
            this.button_ShowChunks.TabIndex = 1;
            this.button_ShowChunks.Text = "Pokaż Chunki";
            this.button_ShowChunks.UseVisualStyleBackColor = true;
            this.button_ShowChunks.Click += new System.EventHandler(this.button_ShowChunks_Click);
            // 
            // button_ShowFFT
            // 
            this.button_ShowFFT.Location = new System.Drawing.Point(12, 118);
            this.button_ShowFFT.Name = "button_ShowFFT";
            this.button_ShowFFT.Size = new System.Drawing.Size(145, 47);
            this.button_ShowFFT.TabIndex = 2;
            this.button_ShowFFT.Text = "Pokaż Transformatę Fouriera";
            this.button_ShowFFT.UseVisualStyleBackColor = true;
            this.button_ShowFFT.Click += new System.EventHandler(this.button_ShowFFT_Click);
            // 
            // button_MakeAnonim
            // 
            this.button_MakeAnonim.Location = new System.Drawing.Point(12, 171);
            this.button_MakeAnonim.Name = "button_MakeAnonim";
            this.button_MakeAnonim.Size = new System.Drawing.Size(145, 47);
            this.button_MakeAnonim.TabIndex = 3;
            this.button_MakeAnonim.Text = "Anonimizuj Obraz";
            this.button_MakeAnonim.UseVisualStyleBackColor = true;
            this.button_MakeAnonim.Click += new System.EventHandler(this.button_MakeAnonim_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pictureBox1.Location = new System.Drawing.Point(163, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 50);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button_MakeAnonim);
            this.Controls.Add(this.button_ShowFFT);
            this.Controls.Add(this.button_ShowChunks);
            this.Controls.Add(this.button_ReadIMG);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ReadIMG;
        private System.Windows.Forms.Button button_ShowChunks;
        private System.Windows.Forms.Button button_ShowFFT;
        private System.Windows.Forms.Button button_MakeAnonim;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}