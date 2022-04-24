using EMediaSol.ReaderFactory;
using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleGui
{
    class Program
    {
        static void Main(string[] args)
        {
            string fileToAppend = @"\ChunksInFiles.txt";
            string mainPath = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia";
            DirectoryInfo d = new DirectoryInfo(mainPath); //Assuming Test is your Folder

            FileInfo[] Files = d.GetFiles("*.png"); //Getting Text files

            Console.WriteLine("\r\n\r\n");
            foreach (FileInfo file in Files)
            {
                saveImpDataInDirectory(file.FullName, mainPath+fileToAppend);
                //printImpDataInDirectory(file.FullName);
            }
            Console.WriteLine("\r\n\r\n");



        }

        static void printChunkInDirectory(string inputFilename)
        {
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\ptaszek.png";
            //string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\png_file.png";
            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            //IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);
            //PLTE_Chunk PLTE_Palette = new PLTE_Chunk(inputArray);
            List<BasicChunkModel> listOfChunks = new Chunk_Finder(inputArray).getData();
            foreach (var item in listOfChunks)
            {
                Console.WriteLine("Name: " + item.Name);
                Console.WriteLine("Size: " + item.Size);
                Console.WriteLine("Crc:  " + item.crc);
                Console.WriteLine("------------------");
            }
        }
        static void saveImpDataInDirectory(string inputFilename, string fileToAppend)
        {
            if (!File.Exists(fileToAppend))
            {
                using (StreamWriter sw = File.CreateText(fileToAppend)) ;
            }
            using (StreamWriter sw = File.AppendText(fileToAppend))
            {
                byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

                List<BasicChunkModel> listOfChunks = new Chunk_Finder(inputArray).getData();
                sw.WriteLine("Count: " + listOfChunks.Count + " File name: " + inputFilename);
                foreach (var item in listOfChunks)
                {
                    sw.WriteLine("   Name: " + item.Name);
                }
            }
        }
        static void printImpDataInDirectory(string inputFilename)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            List<BasicChunkModel> listOfChunks = new Chunk_Finder(inputArray).getData();
            Console.WriteLine("Count: " + listOfChunks.Count + " File name: " + inputFilename);
            foreach (var item in listOfChunks)
            {
                Console.WriteLine("   Name: " + item.Name);
            }
        }
        static void printOnlyImpDataInDirectory(string inputFilename)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            List<BasicChunkModel> listOfChunks = new Chunk_Finder(inputArray).getData();
            Console.WriteLine("Count: " + listOfChunks.Count + " File name: " + inputFilename);
        }
    }
}
