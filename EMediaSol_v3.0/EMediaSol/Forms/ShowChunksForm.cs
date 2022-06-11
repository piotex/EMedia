using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.Forms
{
    public partial class ShowChunksForm : Form
    {
        public static TextBox chunkTxtBox;
        public ShowChunksForm()
        {
            InitializeComponent();
            chunkTxtBox = textBox_Chunks;

            EMediaSol.ReaderFactory.ChunkFactory chunkFactory = new ReaderFactory.ChunkFactory();
            string data = chunkFactory.GetChunksData(MainForm.FilePath);
            textBox_Chunks.Text = data;
        }

        private void button_saveToFile_Click(object sender, EventArgs e)
        {

        }

        private void ShowChunksForm_Load(object sender, EventArgs e)
        {

        }
    }
}
