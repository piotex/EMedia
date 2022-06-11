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
            RsaNumbers rsa = new RsaNumbers();
            rsa = rsa.GetNewObj();

            textBox1.Text = "d: " + rsa.d + "\r\n";
            textBox1.Text +="e: " + rsa.e + "\r\n";












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
