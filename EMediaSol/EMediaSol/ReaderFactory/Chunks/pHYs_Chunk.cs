using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class pHYs_Chunk : ChunkABS
    {
        public long PixelPerUnitX = 0;
        public long PixelPerUnitY = 0;
        public int UnitSoecifier = 0;

        public pHYs_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            byte[] tmp = getNextFourBytes(ref Data, ref index);
            PixelPerUnitX = ConvertByteArrayToInt(tmp);
            tmp = getNextFourBytes(ref Data, ref index);
            PixelPerUnitY = ConvertByteArrayToInt(tmp);
            UnitSoecifier = getNextByte(ref Data, ref index);

        }

        protected override string GetChunkName()
        {
            return "pHYs";
        }
    }
}
