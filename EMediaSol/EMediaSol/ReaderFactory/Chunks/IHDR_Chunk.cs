using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.libpng.org/pub/png/spec/1.2/PNG-Chunks.html

namespace EMediaSol.ReaderFactory.Chunks
{
    public class IHDR_Chunk : Chunk
    {
        public int Width;
        public int Height;
        public int BitDepth;            //giving the number of bits per sample or per palette index (not per pixel).
                                        //Valid values are 1, 2, 4, 8, and 16
        public int ColorType;           //describes the interpretation of the image data.
                                        //Color type codes represent sums of the following values: 1 (palette used), 2 (color used), and 4 (alpha channel used).
                                        //Valid values are 0, 2, 3, 4, and 6.
        public int CompressionMethod;   //indicates the method used to compress the image data. At present, only compression method 0  
        public int FilterMethod;        //indicates the preprocessing method applied to the image data before compression. At present, only filter method 0 
        public int InterlaceMethod;     //indicates the transmission order of the image data. Two values are currently defined: 0 (no interlace) or 1 (Adam7 interlace).

        public IHDR_Chunk(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public IHDR_Chunk(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public void getData()
        {
            int index = GetChunkIndex() + ChunkName.Length;

            byte[] tmp = getNextFourBytes(ref index);
            Width = ConvertByteArrayToInt(tmp);

            tmp = getNextFourBytes(ref index);
            Height = ConvertByteArrayToInt(tmp);

            BitDepth = getNextByte(ref index);
            ColorType = getNextByte(ref index);
            CompressionMethod = getNextByte(ref index);
            FilterMethod = getNextByte(ref index);
            InterlaceMethod = getNextByte(ref index);
        }

        protected int ConvertByteArrayToInt(byte[] tmp)
        {
            Array.Reverse(tmp);
            return BitConverter.ToInt32(tmp, 0);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return next 4 bytes and update index!!! </returns>
        protected byte getNextByte(ref int index)
        {
            return tab[index++];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return next byte and update index!!! </returns>
        protected byte[] getNextFourBytes(ref int index)
        {
            byte[] tmp = new byte[4];
            for (int i = 0; i < 4; i++)
            {
                tmp[i] = tab[index + i];
            }
            index += 4;
            return tmp;
        }
        protected override string GetChunkName()
        {
            return "IHDR";
        }
    }
}
