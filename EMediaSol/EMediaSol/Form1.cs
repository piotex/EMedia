﻿using EMediaSol.ReaderFactory;
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
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ptaszek.png";
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\png_file.png";   //IHDR
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images2.png";      //bKGD
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gora.png";      //IDAT



            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            //IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);
            //bKGD_Chunk bKGD_Chunk = new bKGD_Chunk(inputArray);
            //cHRM_Chunk cHRM_Chunk = new cHRM_Chunk(inputArray);
            //gAMA_Chunk gAMA_Chunk = new gAMA_Chunk(inputArray);
            //IDAT_Chunk IDAT_Chunk = new IDAT_Chunk(inputArray);
            IEND_Chunk IEND_Chunk = new IEND_Chunk(inputArray);



            //not done - peter to do!!
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
