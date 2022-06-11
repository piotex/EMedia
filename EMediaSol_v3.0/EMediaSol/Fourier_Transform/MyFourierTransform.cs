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
        public double[,] getFftNormalizedMagnitudeMatrix(int Width, int Height, Complex[,] tmp)
        {
            double[,] fft = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    fft[i, j] = tmp[i, j].Magnitude;
                    fft[i, j] = 20 * Math.Log10(Math.Abs(fft[i, j]));       //do skali decybelowej

                    fft[i, j] = Math.Abs(fft[i, j]);

                }
            }
            return fft;
        }
        public double[,] getFftMagnitudeMatrix_NoLog(int Width, int Height, Complex[,] tmp)
        {
            double[,] fft = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    fft[i, j] = tmp[i, j].Magnitude;
                    fft[i, j] = Math.Abs(fft[i, j]);
                }
            }
            return fft;
        }
        public double[,] getFftPhaseMatrix(int Width, int Height, Complex[,] tmp)
        {
            double[,] fft = new double[Width, Height];
            for (int i = 0; i < Width; i++)
            {
                for (int j = 0; j < Height; j++)
                {
                    fft[i, j] = tmp[i, j].Phase;
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
                    double gre = (int)((col.R + col.G + col.B) / 3.0);

                    Complex c = new Complex(gre, 0);
                    tmp[i, j] = c;
                }
            }
            return tmp;
        }

        public double[,] CalcMagnitudeTransform(Bitmap bmp)
        {
            Complex[,] tmp = getImageColourMatrix(bmp);

            FourierTransform.FFT2(tmp, FourierTransform.Direction.Forward);

            double[,] fft = getFftNormalizedMagnitudeMatrix(bmp.Width, bmp.Height, tmp);
            fft = Shift(bmp.Width, bmp.Height, fft);

            return fft;
        }
        public double[,] CalcPhaseTransform(Bitmap bmp)
        {
            Complex[,] tmp = getImageColourMatrix(bmp);

            FourierTransform.FFT2(tmp, FourierTransform.Direction.Forward);

            double[,] fft = getFftPhaseMatrix(bmp.Width, bmp.Height, tmp);
            fft = Shift(bmp.Width, bmp.Height, fft);

            return fft;
        }

        public Complex[,] doubleToCOmplex(int x, int y, double[,] tmp)
        {
            Complex[,] ccc = new Complex[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Complex c = new Complex(tmp[i, j], 0);
                    ccc[i, j] = c;
                }
            }
            return ccc;
        }

        public double[,] CalcInvTransform(Bitmap bmp)
        {
            Complex[,] tmp = getImageColourMatrix(bmp);

            FourierTransform.FFT2(tmp, FourierTransform.Direction.Forward);
            FourierTransform.FFT2(tmp, FourierTransform.Direction.Backward);

            double[,] fft = getFftMagnitudeMatrix_NoLog(bmp.Width, bmp.Height, tmp);

            return fft;


        }

    }
}
