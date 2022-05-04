using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class sRGB_Chunk : ChunkABS
    {
        public int RenderingIntent_Number = 0;
        public string RenderingIntent = "";
        public sRGB_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            RenderingIntent_Number = getNextByte(ref Data, ref index);
            switch (RenderingIntent_Number)
            {
                case 0:
                    RenderingIntent = "Perceptual";
                    break;
                case 1:
                    RenderingIntent = "Relative colorimetric";
                    break;
                case 2:
                    RenderingIntent = "Saturation";
                    break;
                case 3:
                    RenderingIntent = "Absolute colorimetric";
                    break;
                default:
                    break;
            }
        }

        protected override string GetChunkName()
        {
            return "sRGB";
        }
    }
}
