using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class gAMA_Chunk : ChunkABS
    {
        double Gamma;
        public gAMA_Chunk(byte[] _tab) : base(_tab)
        {
            getData();
        }
        public void getData()
        {
            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + Name.Length;
            byte[] tmp = getNextFourBytes(ref tab, ref index);
            Gamma = ConvertByteArrayToInt(tmp) * 0.00001;
        }

        protected override string GetChunkName()
        {
            return "gAMA";
        }
    }
}
