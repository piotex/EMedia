using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class Chunk : PngBitReader
    {
        private string _path;
        public Chunk(string path)
        {
            _path = path;
        }

        public int GetChunkIndex(string chunk)
        {
            byte[] tab = ReadPngFile(_path);

            for (int i = 0; i < tab.Length; i++)
            {
                bool isCorrect = true;
                for (int j = 0; j < chunk.Length; j++)
                {
                    int _tab = tab[i + j];
                    int _chunk = chunk[j];

                    if (_tab != _chunk)
                    {
                        isCorrect = false;
                        break;
                    }
                }
                if (isCorrect)
                {
                    return i;
                }
            }
            return -1;
            //throw new Exception("Brak Chunka -> Chunk  -> GetChunkIndex(string)");
        }
    }
}
