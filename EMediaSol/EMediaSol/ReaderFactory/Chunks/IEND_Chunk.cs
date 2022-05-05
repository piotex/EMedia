using System;
using System.Collections.Generic;
using System.IO;
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
        public override void PlotChunk(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("");
                }
            }
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("");
                sw.WriteLine("------- IEND Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
