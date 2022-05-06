using EMediaSol.ReaderFactory;
using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol
{
    public class PngChunkFile
    {
        public string FilePath;
        public Dictionary<string, Chunk> Chunks;

        public PngChunkFile(string path)
        {
            FilePath = path;
            byte[] inputArray = new PngBitReader().ReadPngFile(path);
            Chunks = new Dictionary<string, Chunk>();
            Chunks.Add("IHDR_Chunk", new IHDR_Chunk(inputArray));
            Chunks.Add("PLTE_Chunk", new PLTE_Chunk(inputArray));
            Chunks.Add("IDAT_Chunk", new IDAT_Chunk(inputArray));
            Chunks.Add("IEND_Chunk", new IEND_Chunk(inputArray));
            //Ancillary  Chunks
            Chunks.Add("cHRM_Chunk", new cHRM_Chunk(inputArray));
            Chunks.Add("gAMA_Chunk", new gAMA_Chunk(inputArray));
            Chunks.Add("sBIT_Chunk", new sBIT_Chunk(inputArray));
            Chunks.Add("sRGB_Chunk", new sRGB_Chunk(inputArray));
            Chunks.Add("bKGD_Chunk", new bKGD_Chunk(inputArray));
            Chunks.Add("pHYs_Chunk", new pHYs_Chunk(inputArray));
            Chunks.Add("iTXt_Chunk", new iTXt_Chunk(inputArray));
            Chunks.Add("tEXt_Chunk", new tEXt_Chunk(inputArray));
            Chunks.Add("zTXt_Chunk", new zTXt_Chunk(inputArray));
        }

    }
}
