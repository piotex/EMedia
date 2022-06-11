using EMediaSol.ReaderFactory;
using EMediaSol.ReaderFactory.Chunks;
using EMediaSol.RSA_algo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.Forms
{
    public partial class RsaTmpForm : Form
    {
        public RsaTmpForm()
        {
            InitializeComponent();
        }

        private void RsaTmpForm_Load(object sender, EventArgs e)
        {
            /*
            RsaNumbers.p = 2;
            RsaNumbers.q = 7;
            RsaNumbers.fi= 6;
            RsaNumbers.n = 14;
            RsaNumbers.d = 11;
            RsaNumbers.e = 5;

            textBox1.Text =  "p: " + RsaNumbers.p + "\r\n";
            textBox1.Text += "q: " + RsaNumbers.q + "\r\n";
            textBox1.Text += "fi: "+ RsaNumbers.fi +"\r\n";
            textBox1.Text += "----n: " + RsaNumbers.n + "\r\n";
            textBox1.Text += "----d: " + RsaNumbers.d + "\r\n";
            textBox1.Text += "----e: " + RsaNumbers.e + "\r\n";
            textBox1.Text += "--------------------------------------\r\n";
            */

            //Bitmap img = (Bitmap)EMediaSol.Forms.MainForm._pictureBox1.Image;

            if (ConfigClass.pathToFile == "")
            {
                MessageBox.Show("Nie podano ścierzki do pliku");
                return;
            }

            byte[] inputArray = new PngBitReader().ReadPngFile(ConfigClass.pathToFile);
            IDAT_Chunk idat = new IDAT_Chunk(inputArray);
            Chunk chunk = idat.ListOfIdatChuks[0];

            RsaClient client = new RsaClient();
            for (int i = 1; i < 10; i++)
            {
                var enc = client.Encrypt(i);
                var dec = client.Decrypt(enc);


                textBox1.Text += "i: "   + i + "\r\n";
                textBox1.Text +="enc: " + enc + "\r\n";
                textBox1.Text +="dec: " + dec + "\r\n";
                textBox1.Text +="--------------------------------------\r\n";
            }











            //var rsa = new RSA_algo.RSA_algo();
            //var prime = new PrimeNumber();
            /*
            textBox1.Text = "";
            var tmp = new PrimeNumber().ReadRandomPrimeNumber();
            textBox1.Text += tmp.ToString() + "\r\n";
            */
            /*
            //var tmp = rsa.GetPrimeNumber(2048);
            //var tmp = prime.GenerateNBitPrimeNumber(2048);
            //textBox1.Text += tmp.ToString() + "\r\n";
            */
        }
    }
}
