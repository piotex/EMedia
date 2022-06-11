using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class pHYs_Chunk : ChunkABS
    {
        public long PixelPerUnitX = 0;
        public long PixelPerUnitY = 0;
        public int  UnitSoecifier = 0;

        public pHYs_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            byte[] tmp = getNextFourBytes(ref Data, ref index);
            PixelPerUnitX = ConvertByteArrayToInt(tmp);
            tmp = getNextFourBytes(ref Data, ref index);
            PixelPerUnitY = ConvertByteArrayToInt(tmp);
            UnitSoecifier = getNextByte(ref Data, ref index);

        }

        protected override string GetChunkName()
        {
            return "pHYs";
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
                sw.WriteLine("------- pHYs Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("PixelPerUnitX: " + PixelPerUnitX);
                    sw.WriteLine("PixelPerUnitY: " + PixelPerUnitY);
                    sw.WriteLine("UnitSoecifier: " + UnitSoecifier);
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }

        public override string GetChunkAsString()
        {
            string text = "";
            if (ChunkExist)
            {
                text += "Name      : " + Name + "\r\n";
                text += "Size      : " + Size + "\r\n";
                text += "CRC       : " + CRC + "\r\n";
                text += "" + "\r\n";
                text += "PixelPerUnitX: " + PixelPerUnitX + "\r\n";
                text += "PixelPerUnitY: " + PixelPerUnitY + "\r\n";
                text += "UnitSoecifier: " + UnitSoecifier + "\r\n";
            }
            return text;
        }
    }
}
