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
            RsaNumbers rSA = new RsaNumbers();
            













            //var rsa = new RSA_algo.RSA_algo();
            var prime = new PrimeNumber();
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
