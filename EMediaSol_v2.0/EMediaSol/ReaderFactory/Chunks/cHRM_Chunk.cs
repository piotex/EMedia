using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class cHRM_Chunk : ChunkABS
    {
        public double WhitePointX;
        public double WhitePointY;
        public double RedX;  
        public double RedY;  
        public double GreenX;  
        public double GreenY;  
        public double BlueX;
        public double BlueY;

        public cHRM_Chunk(byte[] _tab) : base(_tab)
        {
        }
        protected override void getData()
        {
            double prescalet = 0.00001;
            int chunkIndex = GetChunkIndex();
            long index = chunkIndex + Name.Length;


            byte[] tmp = getNextTwoBytes(ref tab, ref index);
            WhitePointX = ConvertByteArray2ElemToInt(tmp) * prescalet;
            tmp = getNextTwoBytes(ref tab, ref index);
            WhitePointY = ConvertByteArray2ElemToInt(tmp) * prescalet;

            tmp = getNextTwoBytes(ref tab, ref index);
            RedX = ConvertByteArray2ElemToInt(tmp) * prescalet;
            tmp = getNextTwoBytes(ref tab, ref index);
            RedY = ConvertByteArray2ElemToInt(tmp) * prescalet;

            tmp = getNextTwoBytes(ref tab, ref index);
            GreenX = ConvertByteArray2ElemToInt(tmp) * prescalet;
            tmp = getNextTwoBytes(ref tab, ref index);
            GreenY = ConvertByteArray2ElemToInt(tmp) * prescalet;

            tmp = getNextTwoBytes(ref tab, ref index);
            BlueX = ConvertByteArray2ElemToInt(tmp) * prescalet;
            tmp = getNextTwoBytes(ref tab, ref index);
            BlueX = ConvertByteArray2ElemToInt(tmp) * prescalet;
        }

        protected override string GetChunkName()
        {
            return "cHRM";
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
                sw.WriteLine("------- cHRM Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("WhitePointX: " + WhitePointX);
                    sw.WriteLine("WhitePointY: " + WhitePointY);
                    sw.WriteLine("RedX       : " + RedX);
                    sw.WriteLine("RedY       : " + RedY);
                    sw.WriteLine("GreenX     : " + GreenX);
                    sw.WriteLine("GreenY     : " + GreenY);
                    sw.WriteLine("BlueX      : " + BlueX);
                    sw.WriteLine("BlueY      : " + BlueY);
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
                text += "WhitePointX: " + WhitePointX + "\r\n";
                text += "WhitePointY: " + WhitePointY + "\r\n";
                text += "RedX       : " + RedX + "\r\n";
                text += "RedY       : " + RedY + "\r\n";
                text += "GreenX     : " + GreenX + "\r\n";
                text += "GreenY     : " + GreenY + "\r\n";
                text += "BlueX      : " + BlueX + "\r\n";
                text += "BlueY      : " + BlueY + "\r\n";
            }
            return text;
        }
    }
}
