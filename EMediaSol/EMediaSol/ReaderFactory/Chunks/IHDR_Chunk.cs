using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//http://www.libpng.org/pub/png/spec/1.2/PNG-Chunks.html

namespace EMediaSol.ReaderFactory.Chunks
{
    public class IHDR_Chunk : ChunkABS
    {
        public uint Width;
        public uint Height;
        public uint BitDepth;            //giving the number of bits per sample or per palette index (not per pixel).
                                        //Valid values are 1, 2, 4, 8, and 16
        public int ColorType;           //describes the interpretation of the image data.
                                        //Color type codes represent sums of the following values: 1 (palette used), 2 (color used), and 4 (alpha channel used).
                                        //Valid values are 0, 2, 3, 4, and 6.
        public int CompressionMethod;   //indicates the method used to compress the image data. At present, only compression method 0  
        public int FilterMethod;        //indicates the preprocessing method applied to the image data before compression. At present, only filter method 0 
        public int InterlaceMethod;     //indicates the transmission order of the image data. Two values are currently defined: 0 (no interlace) or 1 (Adam7 interlace).

        public IHDR_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;

            byte[] tmp = getNextFourBytes(ref Data, ref index);
            Width = ConvertByteArrayToInt(tmp);

            tmp = getNextFourBytes(ref Data, ref index);
            Height = ConvertByteArrayToInt(tmp);

            BitDepth = getNextByte(ref Data, ref index);
            ColorType = getNextByte(ref Data, ref index);
            CompressionMethod = getNextByte(ref Data, ref index);
            FilterMethod = getNextByte(ref Data, ref index);
            InterlaceMethod = getNextByte(ref Data, ref index);
        }

        protected override string GetChunkName()
        {
            return "IHDR";
        }
    }
}
