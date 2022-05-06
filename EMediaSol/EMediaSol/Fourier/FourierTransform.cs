using MathNet.Numerics;
using MathNet.Numerics.IntegralTransforms;
using MathNet.Numerics;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;
using MathNet.Numerics.LinearAlgebra;

namespace EMediaSol.ReaderFactory
{
    public class FourierTransform
    {
        static int numSamples = 1000;
        static int sampleRate = 2000;
        static int magSecond = 30;
        static int magThird = 50;
        static double PHSecond = 10;
        static double PHThird = 20;

        Complex32[] samples = new Complex32[numSamples];

        public FourierTransform()
        {
            int w = -1;
            int h = -1;

            string path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";
            Bitmap bmp = new Bitmap(path);
            Complex32[][] aaaa = ToComplex(bmp, ref w, ref h);

            w = 3;
            h = 3;
            Complex32[] bbb = new Complex32[w * h];
            for (int i = 0; i < w*h; i++)
            {
                bbb[i] = i;
            }


            var tmp = Matrix<Complex32>.Build.Random(w,h);

            /*
            for (int i = 0; i < w; i++)
            {
                for (int j = 0; j < h; j++)
                {
                    tmp[i, j] = aaaa[i][j];
                }
            }
            */
            //Fourier.Forward2D(tmp, FourierOptions.Matlab);
            //Fourier.ForwardMultiDim(bbb, new[] { w,h}, FourierOptions.InverseExponent);
        }


        public static Complex32[][] ToComplex(Bitmap image, ref int w, ref int h)
        {
            w = image.Width;
            h = image.Height;

            BitmapData input_data = image.LockBits(new System.Drawing.Rectangle(0, 0, w, h),ImageLockMode.ReadOnly,PixelFormat.Format32bppArgb);

            int bytes = input_data.Stride * input_data.Height;

            byte[] buffer = new byte[bytes];
            Complex32[][] result = new Complex32[w][];

            System.Runtime.InteropServices.Marshal.Copy(input_data.Scan0, buffer, 0, bytes);
            image.UnlockBits(input_data);

            int pixel_position;

            for (int x = 0; x < w; x++)
            {
                result[x] = new Complex32[h];
                for (int y = 0; y < h; y++)
                {
                    pixel_position = y * input_data.Stride + x * 4;
                    result[x][y] = new Complex32(buffer[pixel_position], 0);
                }
            }

            return result;
        }



        public void PlotWaveform(int secHarm, int thirdHarm, double secPh, double thirdPh)
        {
            /*
            Form1.chart_1.Series.Add("Waveform");
            Form1.chart_1.Series.Add("Sec Harm");
            Form1.chart_1.Series.Add("Third Harm");
            Form1.chart_1.Series["Waveform"].Points.Clear();
            Form1.chart_1.Series["Sec Harm"].Points.Clear();
            Form1.chart_1.Series["Third Harm"].Points.Clear();

            double[] fundamental = Generate.Sinusoidal(numSamples, sampleRate, 60, 15);
            double[] second = Generate.Sinusoidal(numSamples, sampleRate, 120, 10);
            //double[] second =      Generate.Sinusoidal(numSamples, sampleRate, 120, secHarm, 0, secPh);
            double[] third =       Generate.Sinusoidal(numSamples, sampleRate, 180, thirdHarm, 0, thirdPh);

            for (int i = 0; i < numSamples; i++)
            {
                samples[i] = new Complex32((float)(fundamental[i] + second[i] + third[i]), 0);
            }

            for (int i = 0; i < samples.Length/5; i++)
            {
                double time = ((i + 1) / numSamples) / 2;
                Form1.chart_1.Series["Waveform"].LegendText = "Waveform";
                Form1.chart_1.Series["Waveform"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;

                //Form1.chart_1.ChartAreas.Add("ChartArea1");
                Form1.chart_1.ChartAreas["ChartArea1"].AxisX.Title = "Seconds";


                Form1.chart_1.Series["Waveform"].Points.AddXY(time, samples[i].Real);
                //Form1.chart_1.Series["Sec Harm"].Points.AddXY(time, second[i]);
            }

            //------------FFT----------------------------------------------------------
            Form1.chart_2.Series.Add("Frequency");
            Form1.chart_2.Series["Frequency"].Points.Clear();

            Fourier.Forward(samples, FourierOptions.NoScaling);

            for (int i = 0; i < samples.Length/10; i++)
            {
                Form1.chart_2.ChartAreas["ChartArea1"].AxisX.Title = "Hz";
                Form1.chart_2.ChartAreas["ChartArea1"].AxisX.MinorTickMark.Enabled = true;

                double mag = (2.0 / numSamples) * (Math.Abs(Math.Sqrt(
                    Math.Pow(samples[i].Real, 2) + Math.Pow(samples[i].Imaginary, 2)
                    )));
                double hzPerSample = sampleRate / numSamples;
                Form1.chart_2.Series["Frequency"].Points.AddXY(hzPerSample*i, mag);
            }
            */
        }
    }
}
