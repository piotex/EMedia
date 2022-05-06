using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Accord.Math;

namespace EMediaSol
{
    public partial class Accord : Form
    {
        public Accord()
        {
            InitializeComponent();

            test_1();
        }

        void test_1()
        {

            Bitmap bmp = new Bitmap(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ball.png");
            //Bitmap bmp = new Bitmap(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gull.png");

            Complex[,] tmp = new System.Numerics.Complex[bmp.Width, bmp.Height];

            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    Color col = bmp.GetPixel(i, j);
                    int gre= (int)((col.R + col.G + col.B) / 3.0);

                    Complex c = new Complex(gre, 0);
                    tmp[i, j] = c;
                }
            }

            FourierTransform.FFT2(tmp, FourierTransform.Direction.Forward);
            int skala = 10000;
            double max = -1;

            double[,] fft = new double[bmp.Width, bmp.Height];
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    fft[i, j] = Math.Abs(Math.Sqrt(
                        Math.Pow(tmp[i,j].Real, 2) + Math.Pow(tmp[i, j].Imaginary, 2)
                        ));
                    if (fft[i, j] > max)
                    {
                        max = fft[i, j];
                    }
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

            int half_Width = bmp.Width/2;
            int half_Height = bmp.Height/2;
            Bitmap bbb = new Bitmap(bmp.Width, bmp.Height);
            for (int i = 0; i < bmp.Height/2; i++)
            {
                for (int j = 0; j < bmp.Width/2; j++)
                {
                    int x = i+ half_Width;
                    int y = j+ half_Height;
                    int col = (int)fft[x, y];
                    bbb.SetPixel(i, j, Color.FromArgb(255, col, col, col));
                }
            }
            for (int i = bmp.Height / 2; i < bmp.Height; i++)
            {
                for (int j = bmp.Width / 2; j < bmp.Width; j++)
                {
                    int x = i - half_Width;
                    int y = j - half_Height;
                    int col = (int)fft[x, y];
                    bbb.SetPixel(i, j, Color.FromArgb(255, col, col, col));
                }
            }
            for (int i = 0; i < bmp.Height/2; i++)
            {
                for (int j = bmp.Width / 2; j < bmp.Width; j++)
                {
                    int x = i+ half_Width;
                    int y = j - half_Height;
                    int col = (int)fft[x, y];
                    bbb.SetPixel(i, j, Color.FromArgb(255, col, col, col));
                }
            }
            for (int i = bmp.Height / 2; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width/2; j++)
                {
                    int x = i - half_Width;
                    int y = j+ half_Height;
                    int col = (int)fft[x, y];
                    bbb.SetPixel(i, j, Color.FromArgb(255, col, col, col));
                }
            }

            /*
            for (int i = 0; i < bmp.Height; i++)
            {
                for (int j = 0; j < bmp.Width; j++)
                {
                    bbb.SetPixel(i, j, bmp.GetPixel(i, j));
                }
            }
            */
            pictureBox1.Image = bbb;
            //pictureBox1.Image = bmp;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
