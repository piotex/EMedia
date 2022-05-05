using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    /// <summary>
    /// The bKGD chunk specifies a default background color to present the image against.
    /// </summary>
    public class bKGD_Chunk : ChunkABS
    {
        public int PaletteIndex;
        public int Gray;
        public int Red;
        public int Green;
        public int Blue;

        public bKGD_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            IHDR_Chunk iHDR = new IHDR_Chunk(tab);
            int ColorType = iHDR.ColorType;

            long index = 0;

            if (ColorType == 3)
            {
                PaletteIndex = getNextByte(ref Data, ref index);
            }
            if (ColorType == 0 || ColorType == 4)
            {
                byte[] tmp = getNextTwoBytes(ref Data, ref index);
                Gray = ConvertByteArray2ElemToInt(tmp);
            }
            if (ColorType == 2 || ColorType == 6)
            {
                byte[] tmp = getNextTwoBytes(ref Data, ref index);
                Red = ConvertByteArray2ElemToInt(tmp); 
                tmp = getNextTwoBytes(ref Data, ref index);
                Green = ConvertByteArray2ElemToInt(tmp);
                tmp = getNextTwoBytes(ref Data, ref index);
                Blue = ConvertByteArray2ElemToInt(tmp);
            }
        }


        protected override string GetChunkName()
        {
            return "bKGD";
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
                sw.WriteLine("------- bKGD Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("PaletteIndex: " + PaletteIndex);
                    sw.WriteLine("Gray        : " + Gray);
                    sw.WriteLine("Red         : " + Red);
                    sw.WriteLine("Green       : " + Green);
                    sw.WriteLine("Blue        : " + Blue);
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}

/*





*/