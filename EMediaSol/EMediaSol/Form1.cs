using EMediaSol.Fourier;
using EMediaSol.ReaderFactory;
using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;

namespace EMediaSol
{
    public partial class Form1 : Form
    {
        public static Chart chart_1;
        public static Chart chart_2;
        public Form1()
        {
            InitializeComponent();

            chart_1 = chart1;
            chart_2 = chart2;
            //doSth();

            //test_3();
            //test_2();         //tak sobie dzialajace FFT

            //new FourierTransform().PlotWaveform(0,0,0,0);
        }

        private void test_3()
        {

            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";          //papuga

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);

            var aaa1 = IHDR_Chunk.NameToByte();
            var aaa2 = IHDR_Chunk.SizeToByte();

        }
        private void test_2()
        {
            var aaaaa = new FourierTransform_Form();
            aaaaa.Show();

            //Bitmap bmp = new Bitmap(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ball.png");
            Bitmap bmp = new Bitmap(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gull.png");
            //Bitmap bmp = new Bitmap(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images7_ITXt.png");
            FFT ImgFFT = new FFT(bmp);

            int ofset = 10;

            ImgFFT.ForwardFFT();// Finding 2D FFT of Image
            ImgFFT.FFTShift();
            ImgFFT.FFTPlot(ImgFFT.FFTShifted);
            FourierTransform_Form.PitureBox_ImageM.Image = bmp;
            FourierTransform_Form.PitureBox_ImageM.Location = new Point(0,0);
            FourierTransform_Form.PitureBox_ImageM.Size = new Size(bmp.Width, bmp.Height);
            
            FourierTransform_Form.FourierMagM.Image = (Image)ImgFFT.FourierPlot;
            FourierTransform_Form.FourierMagM.Location = new Point(bmp.Width+ofset, 0);
            FourierTransform_Form.FourierMagM.Size = new Size(bmp.Width, bmp.Height);

            FourierTransform_Form.FourierPhaseM.Image = (Image)ImgFFT.PhasePlot;
            FourierTransform_Form.FourierPhaseM.Location = new Point(bmp.Width+FourierTransform_Form.FourierMagM.Width+(ofset*2), 0);
            FourierTransform_Form.FourierPhaseM.Size = new Size(bmp.Width, bmp.Height);

            aaaaa.Size = new Size(
                FourierTransform_Form.PitureBox_ImageM.Width+FourierTransform_Form.FourierMagM.Width+ FourierTransform_Form.FourierPhaseM.Width+(ofset*5),
                FourierTransform_Form.PitureBox_ImageM.Height+(ofset*5)
                );
        }

        private void doSth()
        {
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ptaszek.png";
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\png_file.png";   //IHDR
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images2.png";      //bKGD
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images5.png";      //bKGD
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gora.png";      //IDAT



            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            //IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);
            bKGD_Chunk bKGD_Chunk = new bKGD_Chunk(inputArray);
            //cHRM_Chunk cHRM_Chunk = new cHRM_Chunk(inputArray);
            //gAMA_Chunk gAMA_Chunk = new gAMA_Chunk(inputArray);
            //IDAT_Chunk IDAT_Chunk = new IDAT_Chunk(inputArray);
            //IEND_Chunk IEND_Chunk = new IEND_Chunk(inputArray);



            //not done - peter to do!!
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            //chart1.Series
        }
    }
}
