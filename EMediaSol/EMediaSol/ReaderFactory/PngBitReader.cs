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

        protected int ConvertByteArrayToInt(byte[] tmp)
        {
            Array.Reverse(tmp);
            return BitConverter.ToInt32(tmp, 0);
        }
        protected string ConvertByteArrayToString(byte[] tmp)
        {
            string result = "";
            for (int i = 0; i < tmp.Length; i++)
            {
                result += (char)((int)tmp[i]);
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return next 4 bytes and update index!!! </returns>
        protected byte getNextByte(ref byte[] tab, ref int index)
        {
            return tab[index++];
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return next byte and update index!!! </returns>
        protected byte[] getNextFourBytes(ref byte[] tab, ref int index)
        {
            const int count = 4;
            byte[] tmp = new byte[count];
            for (int i = 0; i < count; i++)
            {
                tmp[i] = tab[index + i];
            }
            index += count;
            return tmp;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return next byte and update index!!! </returns>
        protected byte[] getNextEigthBytes(ref byte[] tab, ref int index)
        {
            const int count = 8;
            byte[] tmp = new byte[count];
            for (int i = 0; i < count; i++)
            {
                tmp[i] = tab[index + i];
            }
            index += count;
            return tmp;
        }
    }
}
