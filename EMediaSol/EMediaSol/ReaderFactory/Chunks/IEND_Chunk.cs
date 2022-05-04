using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class IEND_Chunk : ChunkABS
    {
        public IEND_Chunk(byte[] _tab) : base(_tab)
        {
        }

        protected override void getData()
        {
            if (Size != 0)
            {
                throw new Exception("Size is not 0 -> IEND_Chunk -> getData()");
            }
        }

        protected override string GetChunkName()
        {
            return "IEND";
        }
    }
}
