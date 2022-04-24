using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class PLTE_Chunk : Chunk
    {
        public PLTE_Chunk(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public PLTE_Chunk(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public void getData()
        {
            int chunkIndex = GetChunkIndex();
            if (chunkIndex == -1)
            {
                throw new Exception(string.Format("Brak obowiazkowego chunka -> {0}_Chunk -> getData()",GetChunkName()));
            }
            int index = chunkIndex + ChunkName.Length;

        }

        protected override string GetChunkName()
        {
            return "PLTE";
        }
    }
}
