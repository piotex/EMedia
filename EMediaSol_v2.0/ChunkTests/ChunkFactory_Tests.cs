using EMediaSol.ReaderFactory;
using NUnit.Framework;
using EMediaSol.ReaderFactory.Chunks;
using System.IO;

namespace ChunkTests
{
    public class ChunkFactory_Tests
    {
        //do liczenia crc
        //https://www-libpng-org.translate.goog/pub/png/spec/1.2/PNG-CRCAppendix.html?_x_tr_sl=en&_x_tr_tl=pl&_x_tr_hl=pl&_x_tr_pto=wapp&_x_tr_sch=http

        [SetUp]
        public void Setup()
        {
        }
        [Test]
        public void Ploting_Test()
        {
            string mainPath = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia";
            DirectoryInfo d = new DirectoryInfo(mainPath); 

            FileInfo[] Files = d.GetFiles("*.png");

            foreach (FileInfo file in Files)
            {
                new ChunkFactory().PrintChunksInPngImg(file.FullName, mainPath + @"\_Output_Files\_" + file.Name+".txt");
            }

            Assert.Pass();
            
        }
    }
}