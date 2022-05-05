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
        public ChunkABS(byte[] _tab)
        {
            tab = _tab;
            Name = GetChunkName();

            SetNameDataAndCRC();
            if (ChunkExist)
            {
                getData();
            }
        }

        protected abstract string GetChunkName();
        protected abstract void getData();
        public abstract void PlotChunk(string path);

        /// <summary>
        /// Metkod to set defoult parameters
        /// </summary>
        /// <param name="index"></param>
        protected void SetNameDataAndCRC()
        {
            long index = GetChunkIndex();

            ChunkExist = index != -1;
            if (!ChunkExist)
            {
                return;
            }

            index -= 4;                                                 //cofam sie 4 byte-y -> zeby pobrac size
            byte[] tmp = getNextFourBytes(ref tab, ref index);
            Size = ConvertByteArrayToInt(tmp);
            tmp = getNextFourBytes(ref tab, ref index);
            Name = ConvertByteArrayToString(tmp);

            Data = new byte[Size];
            for (int i = 0; i < Size; i++)
            {
                Data[i] = tab[i + index];
            }

            index += Size;

            tmp = getNextFourBytes(ref tab, ref index);
            CRC = ConvertByteArrayToString(tmp);
        }
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
