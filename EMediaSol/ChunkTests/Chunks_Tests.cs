using EMediaSol.ReaderFactory;
using NUnit.Framework;
using EMediaSol.ReaderFactory.Chunks;

namespace ChunkTests
{
    public class Chunks_Tests
    {
        //do liczenia crc
        //https://www-libpng-org.translate.goog/pub/png/spec/1.2/PNG-CRCAppendix.html?_x_tr_sl=en&_x_tr_tl=pl&_x_tr_hl=pl&_x_tr_pto=wapp&_x_tr_sch=http

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
            Assert.AreEqual(IEND_Chunk.Size, 0);
            Assert.AreEqual(IEND_Chunk.Name, "IEND");
            Assert.AreEqual(IEND_Chunk.CRC, "®B`\u0082");
            Assert.Pass();
        }

        [Test]
        public void PLTE_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            PLTE_Chunk PLTE_Chunk = new PLTE_Chunk(inputArray);
            Assert.True(PLTE_Chunk.ChunkExist);
            Assert.AreEqual(PLTE_Chunk.Size, 357);
            Assert.AreEqual(PLTE_Chunk.RgbPaletList.Count, PLTE_Chunk.Size/3);
            Assert.AreEqual(PLTE_Chunk.Name, "PLTE");
            Assert.AreEqual(PLTE_Chunk.CRC, "\u0002 Ç\u0005");
            Assert.Pass();
        }

        [Test]
        public void pHYs_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\kwiat.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            pHYs_Chunk pHYs_Chunk = new pHYs_Chunk(inputArray);
            Assert.True(pHYs_Chunk.ChunkExist);
            Assert.AreEqual(pHYs_Chunk.Size, 9);
            Assert.AreEqual(pHYs_Chunk.PixelPerUnitX, 4724);
            Assert.AreEqual(pHYs_Chunk.PixelPerUnitY, 4724);
            Assert.AreEqual(pHYs_Chunk.UnitSoecifier, 1);
            Assert.AreEqual(pHYs_Chunk.Name, "pHYs");
            Assert.AreEqual(pHYs_Chunk.CRC, "Þf\u001fx");
            Assert.Pass();
        }
        [Test]
        public void sBIT_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\gora.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            sBIT_Chunk sBIT_Chunk = new sBIT_Chunk(inputArray);
            Assert.True(sBIT_Chunk.ChunkExist);
            Assert.AreEqual(sBIT_Chunk.Size, 3);
            Assert.AreEqual(sBIT_Chunk.NumberOfSignificantBits_R, 8);
            Assert.AreEqual(sBIT_Chunk.NumberOfSignificantBits_G, 8);
            Assert.AreEqual(sBIT_Chunk.NumberOfSignificantBits_B, 8);
            Assert.AreEqual(sBIT_Chunk.NumberOfSignificantBits_Gray, 0);
            Assert.AreEqual(sBIT_Chunk.NumberOfSignificantBits_Alpha, 0);
            Assert.AreEqual(sBIT_Chunk.Name, "sBIT");
            Assert.AreEqual(sBIT_Chunk.CRC, "ÛáOà");
            Assert.Pass();
        }
        [Test]
        public void sRGB_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images1.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            sRGB_Chunk sRGB_Chunk = new sRGB_Chunk(inputArray);
            Assert.True(sRGB_Chunk.ChunkExist);
            Assert.AreEqual(sRGB_Chunk.Size, 1);
            Assert.AreEqual(sRGB_Chunk.RenderingIntent_Number, 0);
            Assert.AreEqual(sRGB_Chunk.RenderingIntent, "Perceptual");
            Assert.AreEqual(sRGB_Chunk.Name, "sRGB");
            Assert.AreEqual(sRGB_Chunk.CRC, "®Î\u001cé");
            Assert.Pass();
        }
        [Test]
        public void tEXt_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images1.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            tEXt_Chunk tEXt_Chunk = new tEXt_Chunk(inputArray);
            Assert.True(tEXt_Chunk.ChunkExist);
            Assert.AreEqual(tEXt_Chunk.ListOfTEXtChuks[0].Size, 33);
            Assert.AreEqual(tEXt_Chunk.ListOfTEXtChuks[0].Name, "tEXt");
            Assert.AreEqual(tEXt_Chunk.ListOfTEXtChuks[0].CRC, "Crea");
            Assert.AreEqual(tEXt_Chunk.ListOfTEXtChuks[0].Keyword, "Creation Time");
            Assert.AreEqual(tEXt_Chunk.ListOfTEXtChuks[0].Text, "2021:04:30 22:28:06");
            Assert.Pass();
        }
        [Test]
        public void zEXt_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            zTXt_Chunk zTXt_Chunk = new zTXt_Chunk(inputArray);
            Assert.True(zTXt_Chunk.ChunkExist);
            Assert.True(zTXt_Chunk.ListOfTEXtChuks[0].ChunkExist);
            Assert.AreEqual(zTXt_Chunk.ListOfTEXtChuks[0].DecompressedText, "Papuga");
            Assert.AreEqual(zTXt_Chunk.ListOfTEXtChuks[0].Keyword, "Description");
            Assert.Pass();
        }
        [Test]
        public void iEXt_Chunk_Test()
        {
            string inputFilename = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\images3.png";

            byte[] inputArray = new PngBitReader().ReadPngFile(inputFilename);

            iTXt_Chunk iTXt_Chunk = new iTXt_Chunk(inputArray);
            Assert.True(iTXt_Chunk.ChunkExist);
            
            Assert.True(iTXt_Chunk.ListOfITXtChuks[0].ChunkExist);
            Assert.AreEqual(iTXt_Chunk.ListOfITXtChuks[0].Keyword, "Title");
            Assert.AreEqual(iTXt_Chunk.ListOfITXtChuks[0].Text, "Kolorowa papuga");
            Assert.AreEqual(iTXt_Chunk.ListOfITXtChuks[0].Size, 25);
            Assert.Pass();
            
        }

    }
}