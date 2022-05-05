using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory
{
    public class iTXt_Model : Chunk
    {
        public string Keyword           = "";
        public int    CompressionFlag   = -1;
        public int    CompressionMethod = -1;
        public string LanguageTag       = "";
        public string TranslatedKeyword = "";
        public string Text              = "";
    }
}
