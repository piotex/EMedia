using EMediaSol.ReaderFactory;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();


            doSth();
        }

        private void doSth()
        {
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\png_file.png";
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ptaszek.png";

            //new PngBitReader().doSth();
            int pos = new Chunk(inputFilename).GetChunkIndex("IHDR");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
