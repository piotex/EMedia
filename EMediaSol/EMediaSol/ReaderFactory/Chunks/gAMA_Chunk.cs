using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class gAMA_Chunk : ChunkABS
    {
        public double Gamma;
        public gAMA_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            byte[] tmp = getNextFourBytes(ref Data, ref index);
            Gamma = ConvertByteArrayToInt(tmp) * 0.00001;
        }

        protected override string GetChunkName()
        {
            return "gAMA";
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
                sw.WriteLine("------- gAMA Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("Gamma: " + Gamma);
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
