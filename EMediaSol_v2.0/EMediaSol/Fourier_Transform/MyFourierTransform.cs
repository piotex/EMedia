using AForge.Math;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.Fourier_Transform
{
    public class MyFourierTransform
    {
        public MyFourierTransform()
        {

        }


        public double[,] Shift(int Width, int Height, double[,] original)
        {
            int half_Width = Width / 2;
            int half_Height = Height / 2;

            double[,] fft = new double[Width, Height];

            for (int i = 0; i < Width / 2; i++)
            {
                for (int j = 0; j < Height / 2; j++)
                {
                    int x = i + half_Width;
                    int y = j + half_Height;
                    int col = (int)original[x, y];
                    fft[i, j] = col;
                }
            }
            for (int i = Width / 2; i < Width; i++)
            {
                for (int j = Height / 2; j < Height; j++)
                {
                    int x = i - half_Width;
                    int y = j - half_Height;
                    int col = (int)original[x, y];
                    fft[i, j] = col;
                }
            }
            for (int i = 0; i < Width / 2; i++)
            {
                for (int j = Height / 2; j < Height; j++)
                {
                    int x = i + half_Width;
                    int y = j - half_Height;
                    int col = (int)original[x, y];
                    fft[i, j] = col;
                }
            }
            for (int i = Width / 2; i < Width; i++)
            {
                for (int j = 0; j < Height / 2; j++)
                {
                    int x = i - half_Width;
                    int y = j + half_Height;
                    int col = (int)original[x, y];
                    fft[i, j] = col;
                }
            }

            return fft;
        }
        public double[,] getFftAmplitudeMatrix(int Width, int Height, Complex[,] tmp)
        {
            int skala = 1000;
            double[,] fft = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    fft[i, j] = Math.Abs(Math.Sqrt(
                        Math.Pow(tmp[i, j].Re, 2) + Math.Pow(tmp[i, j].Im, 2)
                        ));
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
        public Complex[,] getImageColourMatrix(Bitmap bmp)
        {
            Complex[,] tmp = new Complex[bmp.Width, bmp.Height];

            for (int i = 0; i < bmp.Width; i++)
            {
                for (int j = 0; j < bmp.Height; j++)
                {
                    Color col = bmp.GetPixel(i, j);
                    int gre = (int)((col.R + col.G + col.B) / 3.0);

                    Complex c = new Complex(gre, 0);
                    tmp[i, j] = c;
                }
            }
            return tmp;
        }

        public double[,] CalcTransform(Bitmap bmp)
        {
            Complex[,] tmp = getImageColourMatrix(bmp);

            //FourierTransform.DFT2(tmp, FourierTransform.Direction.Forward);
            FourierTransform.FFT2(tmp, FourierTransform.Direction.Forward);

            double[,] fft = getFftAmplitudeMatrix(bmp.Width, bmp.Height, tmp);
            fft = Shift(bmp.Width,bmp.Height,fft);

            return fft;
        }

    }
}
