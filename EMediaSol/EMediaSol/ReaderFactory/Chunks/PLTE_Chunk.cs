using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class PLTE_Chunk : ChunkABS
    {
        public List<RgbModel> RgbPaletList = new List<RgbModel>();

        public PLTE_Chunk(byte[] _tab) : base(_tab)
        {
            makeImg();
        }
        protected override void getData()
        {
            long index = 0;
            while (index < Size)
            {
                RgbModel model = new RgbModel()
                {
                    R = getNextByte(ref Data, ref index),
                    G = getNextByte(ref Data, ref index),
                    B = getNextByte(ref Data, ref index)
                };
                RgbPaletList.Add(model);
            }
        }

        private void makeImg()
        {
            //List<byte> bytes = new List<byte>(); // this list should be filled with values
            int width = 100;
            int height = 100;
            int row_size = 32;
            int pixel_size = 50;

            //Bitmap bmp = new Bitmap(width, height);
            Bitmap bmp = new Bitmap(row_size*pixel_size, ((RgbPaletList.Count/ row_size) +1)*pixel_size);

            for (int i = 0; i < RgbPaletList.Count; i++)
            {
                int row = (i % row_size) * pixel_size;
                int col = (i / row_size) * pixel_size;
                Color color = Color.FromArgb(RgbPaletList[i].R, RgbPaletList[i].G, RgbPaletList[i].B);
                for (int x = 0; x < pixel_size; x++)
                {
                    for (int y = 0; y < pixel_size; y++)
                    {
                        bmp.SetPixel(row+x, col+y, color);
                    }
                }
            }
            bmp.Save(@"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\xxx_file.png", ImageFormat.Png);
        }

        protected override string GetChunkName()
        {
            return "PLTE";
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
                sw.WriteLine("------- PLTE Chunk -------");
                if (ChunkExist)
                {
                    sw.WriteLine("Name      : " + Name);
                    sw.WriteLine("Size      : " + Size);
                    sw.WriteLine("CRC       : " + CRC);
                    sw.WriteLine("");
                    sw.WriteLine("RGB Palet List: ");
                    foreach (var item in RgbPaletList)
                    {
                        sw.Write(" R : " + item.R);
                        sw.Write(" G : " + item.G);
                        sw.Write(" B : " + item.B);
                        sw.WriteLine("");
                    }
                }
                else
                {
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
