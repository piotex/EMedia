using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class gAMA_Chunk : ChunkABS
    {
        public double Gamma;
        public gAMA_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            byte[] tmp = getNextFourBytes(ref Data, ref index);
            Gamma = ConvertByteArrayToInt(tmp) * 0.00001;
        }

        protected override string GetChunkName()
        {
            return "gAMA";
        }
    }
}
