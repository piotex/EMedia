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
    public class bKGD_Chunk : ChunkABS
    {
        public int PaletteIndex;
        public int Gray;
        public int Red;
        public int Green;
        public int Blue;

        public bKGD_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            IHDR_Chunk iHDR = new IHDR_Chunk(tab);
            int ColorType = iHDR.ColorType;

            long index = 0;

            if (ColorType == 3)
            {
                PaletteIndex = getNextByte(ref Data, ref index);
            }
            if (ColorType == 0 || ColorType == 4)
            {
                byte[] tmp = getNextTwoBytes(ref Data, ref index);
                Gray = ConvertByteArray2ElemToInt(tmp);
            }
            if (ColorType == 2 || ColorType == 6)
            {
                byte[] tmp = getNextTwoBytes(ref Data, ref index);
                Red = ConvertByteArray2ElemToInt(tmp); 
                tmp = getNextTwoBytes(ref Data, ref index);
                Green = ConvertByteArray2ElemToInt(tmp);
                tmp = getNextTwoBytes(ref Data, ref index);
                Blue = ConvertByteArray2ElemToInt(tmp);
            }
        }


        protected override string GetChunkName()
        {
            return "bKGD";
        }
    }
}
