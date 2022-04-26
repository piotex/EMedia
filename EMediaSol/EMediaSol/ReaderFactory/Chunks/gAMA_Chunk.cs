using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class gAMA_Chunk : Chunk
    {
        double Gamma;
        public gAMA_Chunk(string path)
        {
            tab = ReadPngFile(path);
            ChunkName = GetChunkName();

            getData();
        }
        public gAMA_Chunk(byte[] _tab)
        {
            tab = _tab;
            ChunkName = GetChunkName();

            getData();
        }
        public void getData()
        {
            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + ChunkName.Length;
            byte[] tmp = getNextFourBytes(ref tab, ref index);
            Gamma = ConvertByteArrayToInt(tmp) * 0.00001;
        }

        protected override string GetChunkName()
        {
            return "gAMA";
        }
    }
}
