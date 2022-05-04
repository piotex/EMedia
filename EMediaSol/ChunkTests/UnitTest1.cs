using EMediaSol.ReaderFactory;
using NUnit.Framework;
using EMediaSol.ReaderFactory.Chunks;

namespace ChunkTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IHDR_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";          //papuga

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            IHDR_Chunk IHDR_Chunk = new IHDR_Chunk(inputArray);
            Assert.True(IHDR_Chunk.ChunkExist);
            Assert.AreEqual(IHDR_Chunk.Name, "IHDR");
            Assert.AreEqual(IHDR_Chunk.BitDepth , 8);
            Assert.AreEqual(IHDR_Chunk.CRC , "=[èW");
            Assert.AreEqual(IHDR_Chunk.ColorType , 3);
            Assert.AreEqual(IHDR_Chunk.CompressionMethod , 0);
            Assert.AreEqual(IHDR_Chunk.FilterMethod , 0);
            Assert.AreEqual(IHDR_Chunk.Height , 200);
            Assert.AreEqual(IHDR_Chunk.InterlaceMethod , 0);
            Assert.AreEqual(IHDR_Chunk.Size , 13);
            Assert.AreEqual(IHDR_Chunk.Width , 150);
            Assert.Pass();
        }

        [Test]
        public void bKGD_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gora.png";      //text

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            bKGD_Chunk bKGD_Chunk = new bKGD_Chunk(inputArray);
            Assert.True(bKGD_Chunk.ChunkExist);
            Assert.AreEqual(bKGD_Chunk.Blue , 255);
            Assert.AreEqual(bKGD_Chunk.CRC , " ½§\u0093");
            Assert.AreEqual(bKGD_Chunk.Gray , 0);
            Assert.AreEqual(bKGD_Chunk.Green , 255);
            Assert.AreEqual(bKGD_Chunk.Name , "bKGD");
            Assert.AreEqual(bKGD_Chunk.PaletteIndex , 0);
            Assert.AreEqual(bKGD_Chunk.Red , 255);
            Assert.AreEqual(bKGD_Chunk.Size , 6);
            Assert.Pass();
        }

        [Test]
        public void cHRM_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images5.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            cHRM_Chunk cHRM_Chunk = new cHRM_Chunk(inputArray);
            Assert.True(cHRM_Chunk.ChunkExist);
            Assert.AreEqual(cHRM_Chunk.BlueX , 0.33);
            Assert.AreEqual(cHRM_Chunk.BlueY , 0);
            Assert.AreEqual(cHRM_Chunk.GreenX , 0);
            Assert.AreEqual(cHRM_Chunk.GreenY , 0.64);
            Assert.AreEqual(cHRM_Chunk.Name , "cHRM");
            Assert.AreEqual(cHRM_Chunk.RedX , 0);
            Assert.AreEqual(cHRM_Chunk.RedY , 0.329);
            Assert.AreEqual(cHRM_Chunk.Size , 32);
            Assert.AreEqual(cHRM_Chunk.WhitePointX , 0);
            Assert.True(cHRM_Chunk.WhitePointY - 0.3127 < 0.0001);
            Assert.AreEqual(cHRM_Chunk.CRC , "\u009cºQ<");
            Assert.Pass();
        }

        [Test]
        public void gAMA_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images5.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            gAMA_Chunk gAMA_Chunk = new gAMA_Chunk(inputArray);
            Assert.True(gAMA_Chunk.ChunkExist);
            Assert.AreEqual(gAMA_Chunk.CRC , "\vüa\u0005");
            Assert.AreEqual(gAMA_Chunk.Gamma , 0.45455);
            Assert.AreEqual(gAMA_Chunk.Name , "gAMA");
            Assert.AreEqual(gAMA_Chunk.Size , 4);
            Assert.Pass();
        }

        [Test]
        public void IDAT_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\Anonimization.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            IDAT_Chunk IDAT_Chunk = new IDAT_Chunk(inputArray);
            Assert.True(IDAT_Chunk.ChunkExist);
            Assert.AreEqual(IDAT_Chunk.ListOfIdatChuks.Count , 9);
            Assert.AreEqual(IDAT_Chunk.ListOfIdatChuks[0].CRC, "xÚÌý");
            Assert.AreEqual(IDAT_Chunk.ListOfIdatChuks[0].Size, 32768);
            Assert.AreEqual(IDAT_Chunk.ListOfIdatChuks[0].Name, "IDAT");
            Assert.Pass();
        }

        [Test]
        public void IEND_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images5.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            IEND_Chunk IEND_Chunk = new IEND_Chunk(inputArray);
            Assert.True(IEND_Chunk.ChunkExist);
            Assert.AreEqual(IEND_Chunk.Size , 0);
            Assert.AreEqual(IEND_Chunk.Name , "IEND");
            Assert.AreEqual(IEND_Chunk.CRC , "®B`\u0082");
            Assert.Pass();
        }

    }
}