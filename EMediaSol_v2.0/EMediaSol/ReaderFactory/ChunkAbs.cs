using System;
using System.Collections.Generic;
using System.IO;
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
        public abstract string GetChunkAsString();

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
        public virtual void AppendAllBytes(string path, byte[] bytes)
        {
            using (var stream = new FileStream(path, FileMode.Append))
            {
                stream.Write(bytes, 0, bytes.Length);
            }
        }
        public virtual void DeleteFile(string path)
        {
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
        public virtual void AppendChunkBytesToFile(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("");
                }
            }
            if (ChunkExist)
            {
                byte[] bytes = GetByteChunk();
                using (var stream = new FileStream(path, FileMode.Append))
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
        }
        public virtual byte[] GetByteChunk()
        {
            byte[] res = new byte[4+4+Data.Length+4];
            int idx = 0;
            var name = NameToByte();
            var size = SizeToByte();
            var crc  = CRCToByte();

            for (int i = 0; i < 4; i++)
            {
                res[idx] = size[i];
                idx++;
            }
            for (int i = 0; i < 4; i++)
            {
                res[idx] = name[i];
                idx++;
            }
            for (int i = 0; i < Data.Length; i++)
            {
                res[idx] = Data[i];
                idx++;
            }
            for (int i = 0; i < 4; i++)
            {
                res[idx] = crc[i];
                idx++;
            }
            return res;
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
