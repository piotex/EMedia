using EMediaSol.ReaderFactory;
using NUnit.Framework;
using EMediaSol.ReaderFactory.Chunks;
using System.IO;

namespace ChunkTests
{
    public class ChunkAnonimizator_Tests
    {
        //do liczenia crc
        //https://www-libpng-org.translate.goog/pub/png/spec/1.2/PNG-CRCAppendix.html?_x_tr_sl=en&_x_tr_tl=pl&_x_tr_hl=pl&_x_tr_pto=wapp&_x_tr_sch=http

        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void Append_Test()
        {
            string file_path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";              //papuga
            string dest_path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\anonim_file.png";          //papuga

            byte[] inputArray = new PngBitReader().ReadPngFile(file_path);
            byte[] header = { 137, 80, 78, 71, 13, 10, 26, 10 };

            var IHDR_Chunk = new IHDR_Chunk(inputArray);
            var PLTE_Chunk = new PLTE_Chunk(inputArray);
            var IDAT_Chunk = new IDAT_Chunk(inputArray);
            var IEND_Chunk = new IEND_Chunk(inputArray);

            IHDR_Chunk.DeleteFile(dest_path);
            IHDR_Chunk.AppendAllBytes(dest_path, header);
            IHDR_Chunk.AppendChunkBytesToFile(dest_path);
            PLTE_Chunk.AppendChunkBytesToFile(dest_path);



            string msg = "0007IDAT\r\n\r\n-\r\nXXXX";
            byte[] xxx = new byte[msg.Length];
            for (int i = 0; i < msg.Length; i++)
            {
                xxx[i] = (byte)(int)msg[i];
            }
            IHDR_Chunk.AppendAllBytes(dest_path, xxx);




            IDAT_Chunk.AppendChunkBytesToFile(dest_path);
            IEND_Chunk.AppendChunkBytesToFile(dest_path);
        }
    }
}