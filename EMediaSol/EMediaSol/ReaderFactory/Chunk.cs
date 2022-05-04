using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class Chunk : PngBitReader
    {
        public string Name;
        public long Size;
        public byte[] Data;
        public string CRC;
        public bool ChunkExist;

        /// <summary>
        /// temporary table for storing file bytes
        /// </summary>
        protected byte[] tab;
    }
}
