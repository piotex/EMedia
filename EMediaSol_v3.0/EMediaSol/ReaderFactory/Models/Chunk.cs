using Force.Crc32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class Chunk : PngBitReader
    {
        public string Name;                  //4 byte
        public long   Size;                  //4 byte
        public byte[] Data;
        public byte[] CRC;                   //4 byte
        public bool   ChunkExist;

        /// <summary>
        /// temporary table for storing file bytes
        /// </summary>
        protected byte[] tab;

        public Chunk()
        {
        }

        ulong[] crc_table = new ulong[256];
        int crc_table_computed = 0;

        public void make_crc_table()
        {
          ulong c;
          int n, k;
      
          for (n = 0; n < 256; n++) {
            c = (ulong) n;
            for (k = 0; k < 8; k++) {
              if ((c&1) != 0)
                c = 0xedb88320L ^ (c >> 1);
              else
                c = c >> 1;
            }
            crc_table[n] = c;
          }
          crc_table_computed = 1;
        }
        ulong update_crc(ulong crc, byte[] buf, int len)
        {
            ulong c = crc;
            int n;

            if (!(crc_table_computed != 0))
                make_crc_table();
            for (n = 0; n < len; n++)
            {
                c = crc_table[(c ^ buf[n]) & 0xff] ^ (c >> 8);
            }
            return c;
        }
        ulong crc(byte[] buf, int len)
        {
            return update_crc(0xffffffffL, buf, len) ^ 0xffffffffL;
        }

        public byte[] CalcCRC()
        {
            byte[] old_crc = CRC;

            byte[] name = NameToByte();
            byte[] size = SizeToByte();
            byte[] data = Data;

            byte[] inputArr = new byte[name.Length + size.Length + data.Length];

            name.CopyTo(inputArr, 0);
            size.CopyTo(inputArr, name.Length);
            data.CopyTo(inputArr, name.Length+size.Length);

            ulong tttt = crc(inputArr, inputArr.Length);
            byte[] res999 = BitConverter.GetBytes(tttt).Reverse<byte>().ToArray();
            byte[] res998 = res999.Skip(4).Take(4).ToArray();


            /*
            // write real data to inputArray
            uint tttt = Crc32Algorithm.Compute(inputArr, 0, inputArr.Length); // last 4 bytes contains CRC
            byte[] res999 = BitConverter.GetBytes(tttt).Reverse<byte>().ToArray();
            */
            if (!res998.SequenceEqual<byte>(old_crc))
            {
                throw new Exception(";(");
            }


            return res998;
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

        public virtual byte[] GetByteChunk()
        {
            byte[] res = new byte[4 + 4 + Data.Length + 4];
            int idx = 0;
            var name = NameToByte();
            var size = SizeToByte();
            var crc = CRCToByte();

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

    }
}
