using System;
using System.Drawing;
using System.Windows.Forms;
using EMediaSol.Fourier_Transform;

namespace EMediaSol.Forms
{
    public partial class FourierTransformForm : Form
    {
        public FourierTransformForm()
        {
            InitializeComponent();

            label1.Text = trackBar1.Value.ToString();
        }

        private void FourierTransformForm_Load(object sender, EventArgs e)
        {
            
        }
        public Bitmap MakeBitmap(int Width, int Height, double[,] original)
        {
            Bitmap bbb = new Bitmap(Width, Height);
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    int col = (int)original[i, j];
                    bbb.SetPixel(i, j, Color.FromArgb(255, col, col, col));
                }
            }
            return bbb;
        }
        public double[,] makeItBrighter(int Width, int Height, double[,] fft, int skala)
        {
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    if (fft[i, j] * skala > 255)
                    {
                        fft[i, j] = 255;
                    }
                    else
                    {
                        fft[i, j] *= skala;
                    }
                }
            }
            return fft;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int skala = trackBar1.Value;
                MyFourierTransform MyFourierTransform = new MyFourierTransform();
                double[,] fft = MyFourierTransform.CalcTransform((Bitmap)EMediaSol.Forms.MainForm._pictureBox1.Image);
                fft = makeItBrighter(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft, skala);

                Bitmap bbb = MakeBitmap(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft);
                pictureBox_amp.Image = bbb;
                pictureBox_amp.Width = MainForm._pictureBox1.Image.Width;
                pictureBox_amp.Height = MainForm._pictureBox1.Image.Height;

                int ofset = 15;
                Width = pictureBox_amp.Width * 2 + 2 * ofset;
                Height = pictureBox_amp.Height + 2 * ofset + 100;

                pictureBox_phase.Location = new Point(pictureBox_amp.Location.X + pictureBox_amp.Width + ofset, pictureBox_phase.Location.Y);
            }
            catch (Exception eeeee)
            {
                MessageBox.Show("Error: " + eeeee.Message);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            label1.Text = trackBar1.Value.ToString();
        }
    }
}
