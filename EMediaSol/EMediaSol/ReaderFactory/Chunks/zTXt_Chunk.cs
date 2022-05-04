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

                var tmp99 = SharpZipLibDecompress(tmp_arr);
                //model.DecompressedText = Unzip(tmp_arr);


                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);



                ListOfTEXtChuks.Add(model);
            }
        }

        public static string SharpZipLibDecompress(byte[] data)
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
        /*

        public static byte[] ZLibDotnetDecompress(byte[] data, int size)
        {
            MemoryStream compressed = new MemoryStream(data);
            ZInputStream inputStream = new ZInputStream(compressed);
            byte[] result = new byte[size];   //  Since zinputstream inherits binaryreader instead of stream, it can only prepare the output buffer in advance and use read to obtain fixed length data.
            inputStream.read(result, 0, result.Length); //  Note that the initial of read here is lowercase
            return result;
        }

        */
        public static string MicrosoftDecompress(byte[] data)
        {
            MemoryStream compressed = new MemoryStream(data);
            MemoryStream decompressed = new MemoryStream();
            DeflateStream deflateStream = new DeflateStream(compressed, CompressionMode.Decompress); //  Note: the first parameter here is also to fill in compressed data, but this time it is used as input data
            deflateStream.CopyTo(decompressed);
            byte[] result = decompressed.ToArray();

            string text = "";
            foreach (var item in result)
            {
                text += (char)((int)item);
            }
            return text;

            //return result;
        }











        private static string UnGZipxx(byte[] Dado)
        {
            MemoryStream outputMemStream = new MemoryStream(Dado);
            MemoryStream PlainStream = new MemoryStream();
            using (GZipStream zipInput = new GZipStream(outputMemStream, CompressionMode.Decompress, true))
            {

                byte[] buf = new byte[16384];
                int l = -1;
                while ((l = zipInput.Read(buf, 0, buf.Length)) != 0)
                    PlainStream.Write(buf, 0, l);

                return Encoding.ASCII.GetString(PlainStream.ToArray());
            }
        }

        public void Decompresss(byte[] input)
        {
            //ICSharpCode.SharpZipLib.

        }

        public static void CopyTo(Stream src, Stream dest)
        {
            byte[] bytes = new byte[4096];

            int cnt;

            while ((cnt = src.Read(bytes, 0, bytes.Length)) != 0)
            {
                dest.Write(bytes, 0, cnt);
            }
        }
        public static string Unzip(byte[] bytes)
        {
            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(msi, CompressionMode.Decompress))
                {
                    //gs.CopyTo(mso);
                    CopyTo(gs, mso);
                }

                return Encoding.UTF8.GetString(mso.ToArray());
            }
        }
        public string Decompress(byte[] data)
        {
            using (var compressedStream = new MemoryStream(data))
            {
                using (var zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    using (var resultStream = new MemoryStream())
                    {
                        zipStream.CopyTo(resultStream);
                        var tmp = resultStream.ToArray();

                        string text = "";
                        foreach (var item in tmp)
                        {
                            text += (char)((int)item);
                        }
                        return text;
                    }
                }
            }
        }

        protected override string GetChunkName()
        {
            return "zTXt";
        }
    }
}
