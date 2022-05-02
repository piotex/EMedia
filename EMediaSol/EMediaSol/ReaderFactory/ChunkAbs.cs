using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public abstract class ChunkABS : Chunk
    {
        public ChunkABS()
        {
        }
        public ChunkABS(string path)
        {
            tab = ReadPngFile(path);
            Name = GetChunkName();
        }
        public ChunkABS(byte[] _tab)
        {
            tab = _tab;
            Name = GetChunkName();
        }

        protected abstract string GetChunkName();

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the index where the chunk name begins !!!</returns>
        public int GetChunkIndex()
        {
            for (int i = 0; i < tab.Length; i++)
            {
                bool isCorrect = true;
                for (int j = 0; j < Name.Length; j++)
                {
                    int _tab = tab[i + j];
                    int _chunk = Name[j];

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
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns the index where the chunk name begins !!!</returns>
        public long GetChunkIndex(long startIndex)
        {
            for (long i = startIndex; i < tab.Length; i++)
            {
                bool isCorrect = true;
                for (int j = 0; j < Name.Length; j++)
                {
                    int _tab = tab[i + j];
                    int _chunk = Name[j];

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
