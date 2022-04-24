using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMediaSol.ReaderFactory
{
    public class PngBitReader
    {
        public byte[] ReadPngFile(string inputFilename)
        {
            byte[] bytes = ReadFile(inputFilename);
            string png_string = "PNG";
            for (int i = 0; i < png_string.Length; i++)
            {
                if (bytes[i+1] != png_string[i])
                {
                    throw new Exception("To nie jest obraz PNG -> PngBitReader -> ReadPngFile()");
                }
            }
            return bytes;
        }

        protected byte[] ReadFile(string inputFilename)
        {
            byte[] fileBytes = File.ReadAllBytes(inputFilename);

            return fileBytes;

            //------------------------Convert to Bits------------------------------
            /*
            StringBuilder sb = new StringBuilder();
            foreach (byte b in fileBytes)
            {
                sb.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }
            string bits = sb.ToString();
            */
        }
    }
}
