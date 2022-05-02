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
            getData();
        }

        public void getData()
        {
            long index = 0;
            index = GetChunkIndex(index);
            
            index -= 4;                                                 //cofam sie 4 byte-y -> zeby pobrac size
            byte[] tmp = getNextFourBytes(ref tab, ref index);
            Size = ConvertByteArrayToInt(tmp);
            tmp = getNextFourBytes(ref tab, ref index);
            Name = ConvertByteArrayToString(tmp);

            if (Size != 0)
            {
                throw new Exception("Size is not 0 -> IEND_Chunk -> getData()");
            }

            tmp = getNextFourBytes(ref tab, ref index);
            CRC = ConvertByteArrayToString(tmp);
        }

        protected override string GetChunkName()
        {
            return "IEND";
        }
    }
}
