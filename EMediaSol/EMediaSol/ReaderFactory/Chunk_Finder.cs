using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class Chunk_Finder : PngBitReader
    {
        protected byte[] tab;

        public Chunk_Finder(string path)
        {
            tab = ReadPngFile(path);

            getData();
        }
        public Chunk_Finder(byte[] _tab)
        {
            tab = _tab;

            getData();
        }
        public List<Chunk> getData()
        {
            long index = 0;
            checkPngImgIsCorrect(ref index);
            return GetChunk(ref index);
        }

        private List<Chunk> GetChunk(ref long index)
        {
            List<Chunk> result = new List<Chunk>();
            Chunk model = new Chunk();

            string endChunk = "IEND";
            while (model.Name != endChunk)
            {
                model = new Chunk();
                byte[] tmp = getNextFourBytes(ref tab, ref index);
                model.Size = ConvertByteArrayToInt(tmp);
                tmp = getNextFourBytes(ref tab, ref index);
                model.Name = ConvertByteArrayToString(tmp);

                index += model.Size;                                //pominiecie danych w chunku

                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);
                result.Add(model);
            }
            return result;
        }

        private void checkPngImgIsCorrect(ref long index)
        {
            byte[] png_sig = { 137, 80, 78, 71, 13, 10, 26, 10 };
            for (int i = 0; i < png_sig.Length; i++)
            {
                if (png_sig[i] != tab[i])
                {
                    throw new Exception("Problem z formatem -> Chunk_Finder -> checkPngImgIsCorrect()");
                }
            }
            index += png_sig.Length;
        }
    }
}
