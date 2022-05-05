using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class zTXt_Model : Chunk
    {
        public string Keyword           = "";
        public int    CompressionMethod = -1;
        public string CompressedText    = "";
        public string DecompressedText  = "";
    }
}
