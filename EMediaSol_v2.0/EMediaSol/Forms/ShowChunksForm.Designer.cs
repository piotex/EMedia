
namespace EMediaSol.Forms
{
    partial class ShowChunksForm
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
            this.textBox_Chunks = new System.Windows.Forms.TextBox();
            this.button_saveToFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Chunks
            // 
            this.textBox_Chunks.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.textBox_Chunks.Location = new System.Drawing.Point(181, 12);
            this.textBox_Chunks.Multiline = true;
            this.textBox_Chunks.Name = "textBox_Chunks";
            this.textBox_Chunks.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_Chunks.Size = new System.Drawing.Size(607, 594);
            this.textBox_Chunks.TabIndex = 0;
            // 
            // button_saveToFile
            // 
            this.button_saveToFile.Location = new System.Drawing.Point(12, 12);
            this.button_saveToFile.Name = "button_saveToFile";
            this.button_saveToFile.Size = new System.Drawing.Size(163, 48);
            this.button_saveToFile.TabIndex = 1;
            this.button_saveToFile.Text = "Save To File";
            this.button_saveToFile.UseVisualStyleBackColor = true;
            this.button_saveToFile.Click += new System.EventHandler(this.button_saveToFile_Click);
            // 
            // ShowChunksForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 618);
            this.Controls.Add(this.button_saveToFile);
            this.Controls.Add(this.textBox_Chunks);
            this.Name = "ShowChunksForm";
            this.Text = "ShowChunksForm";
            this.Load += new System.EventHandler(this.ShowChunksForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Chunks;
        private System.Windows.Forms.Button button_saveToFile;
    }
}