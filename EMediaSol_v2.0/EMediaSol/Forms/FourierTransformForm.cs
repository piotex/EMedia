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
            calc_transf();
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
                    if (original[i, j] > 255)
                    {
                        col = 255;
                    }
                    if (original[i, j] < 0)
                    {
                        col = 0;
                    }
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

        private void calc_transf()
        {
            try
            {
                int skala = 100000;// trackBar1.Value;
                int ofset = 15;
                MyFourierTransform MyFourierTransform = new MyFourierTransform();

                double[,] fft_mag = MyFourierTransform.CalcMagnitudeTransform((Bitmap)EMediaSol.Forms.MainForm._pictureBox1.Image);
                double[,] fft_phase = MyFourierTransform.CalcPhaseTransform((Bitmap)EMediaSol.Forms.MainForm._pictureBox1.Image);

                double[,] invert = MyFourierTransform.CalcInvTransform((Bitmap)EMediaSol.Forms.MainForm._pictureBox1.Image);

                //fft_mag = makeItBrighter(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft_mag, skala);
                fft_phase = makeItBrighter(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft_phase, skala);


                Bitmap bbb = MakeBitmap(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft_mag);
                pictureBox_amp.Image = bbb;
                pictureBox_amp.Width = MainForm._pictureBox1.Image.Width;
                pictureBox_amp.Height = MainForm._pictureBox1.Image.Height;


                Bitmap bbb2 = MakeBitmap(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, invert);
                pictureBox1.Image = bbb2;
                pictureBox1.Width = MainForm._pictureBox1.Image.Width;
                pictureBox1.Height = MainForm._pictureBox1.Image.Height;
                pictureBox1.Location = new Point(pictureBox_amp.Location.X + pictureBox_amp.Width + ofset,  pictureBox1.Location.Y);


                Bitmap bbb3 = MakeBitmap(MainForm._pictureBox1.Image.Width, MainForm._pictureBox1.Image.Height, fft_phase);
                pictureBox2.Image = bbb3;
                pictureBox2.Width = MainForm._pictureBox1.Image.Width;
                pictureBox2.Height = MainForm._pictureBox1.Image.Height;
                pictureBox2.Location = new Point(pictureBox1.Location.X + pictureBox1.Width + ofset,  pictureBox2.Location.Y);


                //pictureBox_phase.Location = new Point(pictureBox_amp.Location.X + pictureBox_amp.Width + ofset, pictureBox_phase.Location.Y);
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

        private void button1_Click(object sender, EventArgs e)
        {
            calc_transf();
        }
    }
}
