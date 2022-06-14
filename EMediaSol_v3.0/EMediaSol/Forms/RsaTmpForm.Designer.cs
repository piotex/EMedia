
namespace EMediaSol.Forms
{
    partial class RsaTmpForm
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
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button_enc = new System.Windows.Forms.Button();
            this.button_dec = new System.Windows.Forms.Button();
            this.button_enc_CTR = new System.Windows.Forms.Button();
            this.button_dec_CTR = new System.Windows.Forms.Button();
            this.button_showcase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(124, 12);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox1.Size = new System.Drawing.Size(664, 426);
            this.textBox1.TabIndex = 0;
            // 
            // button_enc
            // 
            this.button_enc.Location = new System.Drawing.Point(12, 10);
            this.button_enc.Name = "button_enc";
            this.button_enc.Size = new System.Drawing.Size(106, 57);
            this.button_enc.TabIndex = 1;
            this.button_enc.Text = "Szyfruj ECB";
            this.button_enc.UseVisualStyleBackColor = true;
            this.button_enc.Click += new System.EventHandler(this.button_enc_Click);
            // 
            // button_dec
            // 
            this.button_dec.Location = new System.Drawing.Point(12, 73);
            this.button_dec.Name = "button_dec";
            this.button_dec.Size = new System.Drawing.Size(106, 57);
            this.button_dec.TabIndex = 2;
            this.button_dec.Text = "Odszyfruj ECB";
            this.button_dec.UseVisualStyleBackColor = true;
            this.button_dec.Click += new System.EventHandler(this.button_dec_Click);
            // 
            // button_enc_CTR
            // 
            this.button_enc_CTR.Location = new System.Drawing.Point(12, 163);
            this.button_enc_CTR.Name = "button_enc_CTR";
            this.button_enc_CTR.Size = new System.Drawing.Size(106, 57);
            this.button_enc_CTR.TabIndex = 3;
            this.button_enc_CTR.Text = "Szyfruj CTR";
            this.button_enc_CTR.UseVisualStyleBackColor = true;
            this.button_enc_CTR.Click += new System.EventHandler(this.button_enc_CTR_Click);
            // 
            // button_dec_CTR
            // 
            this.button_dec_CTR.Location = new System.Drawing.Point(12, 226);
            this.button_dec_CTR.Name = "button_dec_CTR";
            this.button_dec_CTR.Size = new System.Drawing.Size(106, 57);
            this.button_dec_CTR.TabIndex = 4;
            this.button_dec_CTR.Text = "Odszyfruj  CTR";
            this.button_dec_CTR.UseVisualStyleBackColor = true;
            this.button_dec_CTR.Click += new System.EventHandler(this.button_dec_CTR_Click);
            // 
            // button_showcase
            // 
            this.button_showcase.Location = new System.Drawing.Point(12, 381);
            this.button_showcase.Name = "button_showcase";
            this.button_showcase.Size = new System.Drawing.Size(106, 57);
            this.button_showcase.TabIndex = 5;
            this.button_showcase.Text = "Showcase";
            this.button_showcase.UseVisualStyleBackColor = true;
            this.button_showcase.Click += new System.EventHandler(this.button_showcase_Click);
            // 
            // RsaTmpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button_showcase);
            this.Controls.Add(this.button_dec_CTR);
            this.Controls.Add(this.button_enc_CTR);
            this.Controls.Add(this.button_dec);
            this.Controls.Add(this.button_enc);
            this.Controls.Add(this.textBox1);
            this.Name = "RsaTmpForm";
            this.Text = "RsaTmpForm";
            this.Load += new System.EventHandler(this.RsaTmpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button_enc;
        private System.Windows.Forms.Button button_dec;
        private System.Windows.Forms.Button button_enc_CTR;
        private System.Windows.Forms.Button button_dec_CTR;
        private System.Windows.Forms.Button button_showcase;
    }
}