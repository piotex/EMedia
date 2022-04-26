using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class _Chunk : Chunk
    {
        public _Chunk(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public _Chunk(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public void getData()
        {
            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + ChunkName.Length;

        }

        protected override string GetChunkName()
        {
            return "";
        }
    }
}
