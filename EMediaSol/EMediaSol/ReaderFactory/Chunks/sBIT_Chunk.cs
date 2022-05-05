using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class sBIT_Chunk : ChunkABS
    {
        public int NumberOfSignificantBits_Gray  = 0;
        public int NumberOfSignificantBits_R     = 0;
        public int NumberOfSignificantBits_G     = 0;
        public int NumberOfSignificantBits_B     = 0;
        public int NumberOfSignificantBits_Alpha = 0;
        public sBIT_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            IHDR_Chunk iHDR = new IHDR_Chunk(tab);
            int ColorType = iHDR.ColorType;

            long index = 0;

            if (ColorType == 0)
            {
                NumberOfSignificantBits_Gray = getNextByte(ref Data, ref index);
            }
            if (ColorType == 2)
            {
                NumberOfSignificantBits_R = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_G = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_B = getNextByte(ref Data, ref index);
            }
            if (ColorType == 3)
            {
                NumberOfSignificantBits_R = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_G = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_B = getNextByte(ref Data, ref index);
            }
            if (ColorType == 4)
            {
                NumberOfSignificantBits_Gray = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_Alpha = getNextByte(ref Data, ref index);
            }
            if (ColorType == 6)
            {
                NumberOfSignificantBits_R = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_G = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_B = getNextByte(ref Data, ref index);
                NumberOfSignificantBits_Alpha = getNextByte(ref Data, ref index);
            }
        }

        protected override string GetChunkName()
        {
            return "sBIT";
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
                sw.WriteLine("------- sBIT Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("NumberOfSignificantBits_Gray : " + NumberOfSignificantBits_Gray );
                    sw.WriteLine("NumberOfSignificantBits_R    : " + NumberOfSignificantBits_R    );
                    sw.WriteLine("NumberOfSignificantBits_G    : " + NumberOfSignificantBits_G    );
                    sw.WriteLine("NumberOfSignificantBits_B    : " + NumberOfSignificantBits_B    );
                    sw.WriteLine("NumberOfSignificantBits_Alpha: " + NumberOfSignificantBits_Alpha);
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
