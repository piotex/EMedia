using EMediaSol.RSA_algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.Forms
{
    public partial class MainForm : Form
    {
        public static PictureBox _pictureBox1;
        public static string FilePath = "";

        public MainForm()
        {
            InitializeComponent();

            _pictureBox1 = pictureBox1;
            RsaNumbers rsa = RsaNumbers.GetInstance();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
        }

        private void button_ReadIMG_Click(object sender, EventArgs e)
        {
            int ofset = 15;
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "Pobrane";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = openFileDialog.FileName;
                    ConfigClass.pathToFile = FilePath;
                    Bitmap bmp = new Bitmap(FilePath);
                    pictureBox1.Image = bmp;
                    pictureBox1.Size = bmp.Size;
                    this.Size = new Size(ofset*3+button_ReadIMG.Size.Width+bmp.Size.Width, Size.Height);
                }
            }
        }

        private void button_ShowChunks_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                ShowChunksForm ShowChunksForm = new ShowChunksForm();
                ShowChunksForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz plik do przetworzenia.");
            }
        }

        private void button_ShowFFT_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                FourierTransformForm FourierTransformForm = new FourierTransformForm();
                FourierTransformForm.Show();
            }
            else
            {
                MessageBox.Show("Wybierz plik do przetworzenia.");
            }
        }

        private void button_MakeAnonim_Click(object sender, EventArgs e)
        {
            if (FilePath != "")
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    openFileDialog.InitialDirectory = "Pobrane";

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        string path = openFileDialog.FileName;
                        Anonimization.Anonimizer anonimizer = new Anonimization.Anonimizer();
                        anonimizer.MakeAnonimFile(path);
                    }
                }
            }
            else
            {
                MessageBox.Show("Wybierz plik do przetworzenia.");
            }
        }

        private void button_Encrypt_Click(object sender, EventArgs e)
        {
            var tmp = new RsaTmpForm();
            tmp.Show();
        }
    }
}
