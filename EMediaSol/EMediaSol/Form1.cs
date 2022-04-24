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
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\png_file.png";



            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            //IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);
            //PLTE_Chunk PLTE_Palette = new PLTE_Chunk(inputArray);
            List<BasicChunkModel> listOfChunks = new Chunk_Finder(inputArray).getData();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
