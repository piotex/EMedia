using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    /// <summary>
    /// The bKGD chunk specifies a default background color to present the image against.
    /// </summary>
    public class bKGD_Chunk : Chunk
    {
        public int PaletteIndex;
        public int Gray;
        public int Red;
        public int Green;
        public int Blue;

        public bKGD_Chunk(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public bKGD_Chunk(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public void getData()
        {
            IHDR_Chunk iHDR = new IHDR_Chunk(tab);
            int ColorType = iHDR.ColorType;

            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + ChunkName.Length;

            if (ColorType == 3)
            {
                PaletteIndex = getNextByte(ref tab, ref index);
            }
            if (ColorType == 0 || ColorType == 4)
            {
                byte[] tmp = getNextTwoBytes(ref tab, ref index);
                Gray = ConvertByteArray2ElemToInt(tmp);
            }
            if (ColorType == 2 || ColorType == 6)
            {
                byte[] tmp = getNextTwoBytes(ref tab, ref index);
                Red = ConvertByteArray2ElemToInt(tmp); 
                tmp = getNextTwoBytes(ref tab, ref index);
                Green = ConvertByteArray2ElemToInt(tmp);
                tmp = getNextTwoBytes(ref tab, ref index);
                Blue = ConvertByteArray2ElemToInt(tmp);
            }
        }

        protected override string GetChunkName()
        {
            return "bKGD";
        }
    }
}
