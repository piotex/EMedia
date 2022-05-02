using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class _Chunk : ChunkABS
    {
        public _Chunk(byte[] _tab) : base(_tab)
        {
            getData();
        }
        public void getData()
        {
            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + Name.Length;

        }

        protected override string GetChunkName()
        {
            return "";
        }
    }
}
