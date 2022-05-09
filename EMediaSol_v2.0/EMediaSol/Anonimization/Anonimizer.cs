using EMediaSol.ReaderFactory;
using EMediaSol.Forms;
using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.Anonimization
{
    public class Anonimizer
    {
        public void MakeAnonimFile(string path)
        {
            byte[] inputArray = new PngBitReader().ReadPngFile(MainForm.FilePath);
            byte[] header = { 137, 80, 78, 71, 13, 10, 26, 10 };

            var IHDR_Chunk = new IHDR_Chunk(inputArray);
            var PLTE_Chunk = new PLTE_Chunk(inputArray);
            var IDAT_Chunk = new IDAT_Chunk(inputArray);
            var IEND_Chunk = new IEND_Chunk(inputArray);

            IHDR_Chunk.DeleteFile(path);
            IHDR_Chunk.AppendAllBytes(path, header);
            IHDR_Chunk.AppendChunkBytesToFile(path);
            PLTE_Chunk.AppendChunkBytesToFile(path);

            /*

            string msg = "0007IDAT\r\n\r\n-\r\nXXXX";
            byte[] xxx = new byte[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                xxx[i] = (byte)(int)msg[i];
            }
            IHDR_Chunk.AppendAllBytes(dest_path, xxx);

            */


            IDAT_Chunk.AppendChunkBytesToFile(path);
            IEND_Chunk.AppendChunkBytesToFile(path);
        }
    }
}
