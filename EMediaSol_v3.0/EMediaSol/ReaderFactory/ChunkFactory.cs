using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMediaSol.ReaderFactory.Chunks;

namespace EMediaSol.ReaderFactory
{
    public class ChunkFactory
    {
        public void PrintChunksInPngImg(string png_file_path, string destination_file_path)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(png_file_path);
            List<ChunkABS> list_of_chunks = new List<ChunkABS>()
            {
                //Critical  Chunks
                new IHDR_Chunk(inputArray),
                new PLTE_Chunk(inputArray),
                new IDAT_Chunk(inputArray),
                new IEND_Chunk(inputArray),
                //Ancillary  Chunks
                new cHRM_Chunk(inputArray),
                new gAMA_Chunk(inputArray),
                new sBIT_Chunk(inputArray),
                new sRGB_Chunk(inputArray),
                new bKGD_Chunk(inputArray),
                new pHYs_Chunk(inputArray),

                new iTXt_Chunk(inputArray),
                new tEXt_Chunk(inputArray),
                new zTXt_Chunk(inputArray),
            };

            foreach (var item in list_of_chunks)
            {
                item.PlotChunk(destination_file_path);
            }
        }
        public string GetChunksData(string png_file_path)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(png_file_path);
            List<ChunkABS> list_of_chunks = new List<ChunkABS>()
            {
                //Critical  Chunks
                new IHDR_Chunk(inputArray),
                new PLTE_Chunk(inputArray),
                new IDAT_Chunk(inputArray),
                new IEND_Chunk(inputArray),
                //Ancillary  Chunks
                new cHRM_Chunk(inputArray),
                new gAMA_Chunk(inputArray),
                new sBIT_Chunk(inputArray),
                new sRGB_Chunk(inputArray),
                new bKGD_Chunk(inputArray),
                new pHYs_Chunk(inputArray),

                new iTXt_Chunk(inputArray),
                new tEXt_Chunk(inputArray),
                new zTXt_Chunk(inputArray),
            };

            string text = "";
            foreach (var item in list_of_chunks)
            {
                if (item.ChunkExist)
                {
                    text += "--------------------------------------------------\r\n";
                    text += item.GetChunkAsString();
                }
            }
            return text;
        }
    }
}
