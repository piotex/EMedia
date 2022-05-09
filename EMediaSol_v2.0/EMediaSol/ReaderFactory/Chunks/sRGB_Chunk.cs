using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class sRGB_Chunk : ChunkABS
    {
        public int    RenderingIntent_Number = 0;
        public string RenderingIntent        = "";
        public sRGB_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            long index = 0;
            RenderingIntent_Number = getNextByte(ref Data, ref index);
            switch (RenderingIntent_Number)
            {
                case 0:
                    RenderingIntent = "Perceptual";
                    break;
                case 1:
                    RenderingIntent = "Relative colorimetric";
                    break;
                case 2:
                    RenderingIntent = "Saturation";
                    break;
                case 3:
                    RenderingIntent = "Absolute colorimetric";
                    break;
                default:
                    break;
            }
        }

        protected override string GetChunkName()
        {
            return "sRGB";
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
                sw.WriteLine("------- sRGB Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("RenderingIntent_Number: " + RenderingIntent_Number);
                    sw.WriteLine("RenderingIntent       : " + RenderingIntent);
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
                text += "RenderingIntent_Number: " + RenderingIntent_Number + "\r\n";
                text += "RenderingIntent       : " + RenderingIntent + "\r\n";
            }
            return text;
        }
    }
}
