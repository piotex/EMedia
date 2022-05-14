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

        }
    }
}