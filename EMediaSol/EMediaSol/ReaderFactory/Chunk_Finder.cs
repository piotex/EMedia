using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class BasicChunkModel
    {
        public long Size;
        public string Name; 
        public byte[] Data; 
        public string crc;
    }

    public class Chunk_Finder : Chunk
    {
        public Chunk_Finder(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public Chunk_Finder(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public List<BasicChunkModel> getData()
        {
            long index = 0;
            checkPngImgIsCorrect(ref index);
            return GetChunk(ref index);
        }

        private List<BasicChunkModel> GetChunk(ref long index)
        {
            List<BasicChunkModel> result = new List<BasicChunkModel>();
            BasicChunkModel model = new BasicChunkModel();

            string endChunk = "IEND";
            while (model.Name != endChunk)
            {
                model = new BasicChunkModel();
                byte[] tmp = getNextFourBytes(ref tab, ref index);
                model.Size = ConvertByteArrayToInt(tmp);
                tmp = getNextFourBytes(ref tab, ref index);
                model.Name = ConvertByteArrayToString(tmp);

                index += model.Size;                                //pominiecie danych w chunku

                tmp = getNextFourBytes(ref tab, ref index);
                model.crc = ConvertByteArrayToString(tmp);
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

        protected override string GetChunkName()
        {
            //throw new NotImplementedException();
            return "";
        }
    }
}
