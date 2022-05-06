using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class Chunk : PngBitReader
    {
        public string Name;
        public long   Size;
        public byte[] Data;
        public string CRC;
        public bool   ChunkExist;

        /// <summary>
        /// temporary table for storing file bytes
        /// </summary>
        protected byte[] tab;

        public Chunk()
        {
        }

        public byte[] NameToByte()
        {
            byte[] res = new byte[Name.Length];
            for (int i = 0; i < Name.Length; i++)
            {
                res[i] = (byte)((int)Name[i]);
            }
            return res;
        }
        public byte[] SizeToByte()
        {
            var ttt = BitConverter.GetBytes((Int32)Size);
            Array.Reverse(ttt);
            return ttt;
        }
        public byte[] CRCToByte()
        {
            byte[] res = new byte[CRC.Length];
            for (int i = 0; i < Name.Length; i++)
            {
                res[i] = (byte)((int)CRC[i]);
            }
            return res;
        }



    }
}
