using ICSharpCode.SharpZipLib.Zip;
using ICSharpCode.SharpZipLib.Zip.Compression.Streams;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class zTXt_Chunk : ChunkABS
    {
        public List<zTXt_Model> ListOfTEXtChuks = new List<zTXt_Model>();
        public zTXt_Chunk(byte[] _tab) //: base(_tab)
        {
            tab = _tab;
            Name = GetChunkName();

            long index = GetChunkIndex();
            ChunkExist = index != -1;
            if (ChunkExist)
            {
                getData();
            }
        }
        protected override void getData()
        {
            ListOfTEXtChuks = new List<zTXt_Model>();
            zTXt_Model model;

            long index = 0;
            while (index != -1)
            {
                index = GetChunkIndex(index);
                if (index == -1)
                    break;

                model = new zTXt_Model();
                model.ChunkExist = true;

                index -= 4;                                        //cofam sie 4 byte-y -> zeby pobrac size
                byte[] tmp = getNextFourBytes(ref tab, ref index);
                model.Size = ConvertByteArrayToInt(tmp);
                tmp = getNextFourBytes(ref tab, ref index);
                model.Name = ConvertByteArrayToString(tmp);

                //index += model.Size;                                    //pominiecie danych w chunku
                byte[] body = new byte[model.Size];

                for (long i = 0; i < model.Size; i++)
                {
                    body[i] = tab[i + index];
                }
                model.Data = body;

                string keyword = "";
                long idx1 = 0;
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    keyword += (char)((int)model.Data[idx1]);
                    idx1++;
                }
                idx1++;

                model.CompressionMethod = getNextByte(ref model.Data, ref idx1);

                int idxxxx = 0;
                string text = "";
                byte[] tmp_arr = new byte[(uint)(model.Data.Length - idx1)];

                while (idx1 < model.Data.Length)
                {
                    text += (char)((int)model.Data[idx1]);
                    tmp_arr[idxxxx] = model.Data[idx1];
                    idxxxx++;
                    idx1++;
                }
                model.Keyword = keyword;
                model.CompressedText = text;

                model.DecompressedText = SharpZipLibDecompress(tmp_arr);

                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);

                ListOfTEXtChuks.Add(model);
            }
        }


        public override void AppendChunkBytesToFile(string path)
        {
            if (!File.Exists(path))
            {
                using (StreamWriter sw = File.CreateText(path))
                {
                    sw.Write("");
                }
            }
            if (ChunkExist)
            {
                foreach (var item in ListOfTEXtChuks)
                {
                    byte[] bytes = item.GetByteChunk();
                    using (var stream = new FileStream(path, FileMode.Append))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
            }
        }
        protected string SharpZipLibDecompress(byte[] data)
        {
            MemoryStream compressed = new MemoryStream(data);
            MemoryStream decompressed = new MemoryStream();
            InflaterInputStream inputStream = new InflaterInputStream(compressed);
            inputStream.CopyTo(decompressed);

            var result = decompressed.ToArray();

            string text = "";
            foreach (var item in result)
            {
                text += (char)((int)item);
            }
            return text;

            //return decompressed.ToArray();
        }
        
        protected override string GetChunkName()
        {
            return "zTXt";
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
                if (ChunkExist)
                {
                    sw.WriteLine("");
                    sw.WriteLine("");
                    sw.WriteLine("");
                    foreach (var item in ListOfTEXtChuks)
                    {
                        sw.WriteLine("");
                        sw.WriteLine("------- zTXt Chunk -------");
                        sw.WriteLine("Name      : " + item.Name);
                        sw.WriteLine("Size      : " + item.Size);
                        sw.WriteLine("CRC       : " + item.CRC);
                        sw.WriteLine("");
                        sw.WriteLine("Keyword          : " + item.Keyword          );
                        sw.WriteLine("CompressionMethod: " + item.CompressionMethod);
                        sw.WriteLine("CompressedText   : " + item.CompressedText   );
                        sw.WriteLine("DecompressedText : " + item.DecompressedText);
                    }
                }
                else
                {
                    sw.WriteLine("");
                    sw.WriteLine("------- zTXt Chunk -------");
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }

        public override string GetChunkAsString()
        {
            string text = "";
            if (ChunkExist)
            {
                foreach (var item in ListOfTEXtChuks)
                {
                    text += "" + "\r\n";
                    text += "Name      : " + item.Name + "\r\n";
                    text += "Size      : " + item.Size + "\r\n";
                    text += "CRC       : " + item.CRC + "\r\n";
                    text += "" + "\r\n";
                    text += "Keyword          : " + item.Keyword + "\r\n";
                    text += "CompressionMethod: " + item.CompressionMethod + "\r\n";
                    text += "CompressedText   : " + item.CompressedText + "\r\n";
                    text += "DecompressedText : " + item.DecompressedText + "\r\n";
                }
            }
            return text;
        }
    }
}
