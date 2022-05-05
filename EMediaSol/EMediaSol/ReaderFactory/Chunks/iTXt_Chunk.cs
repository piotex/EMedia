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
    public class iTXt_Chunk : ChunkABS
    {
        public List<iTXt_Model> ListOfITXtChuks = new List<iTXt_Model>();
        public iTXt_Chunk(byte[] _tab) //: base(_tab)
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
            ListOfITXtChuks = new List<iTXt_Model>();
            iTXt_Model model;

            long index = 0;
            while (index != -1)
            {
                //--------------------------------------------------------Geting Name Size and DATA--------------------------------------------------------------------------
                index = GetChunkIndex(index);
                if (index == -1)
                    break;

                model = new iTXt_Model();
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
                //---------------------------------------------------------Geting Keyword-------------------------------------------------------------------------
                long idx1 = 0;
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    model.Keyword += (char)((int)model.Data[idx1]);
                    idx1++;
                }
                //---------------------------------------------------------Null Separator-------------------------------------------------------------------------
                idx1++;
                //---------------------------------------------------------Geting Compresion Method and Flag-------------------------------------------------------------------------
                model.CompressionFlag = getNextByte(ref model.Data, ref idx1);
                model.CompressionMethod = getNextByte(ref model.Data, ref idx1);
                //---------------------------------------------------------Geting Language Tag-------------------------------------------------------------------------
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    model.LanguageTag += (char)((int)model.Data[idx1]);
                    idx1++;
                }
                //---------------------------------------------------------Null Separator-------------------------------------------------------------------------
                idx1++;
                //---------------------------------------------------------Geting Translated Keyword-------------------------------------------------------------------------
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    model.TranslatedKeyword += (char)((int)model.Data[idx1]);
                    idx1++;
                }
                //---------------------------------------------------------Null Separator-------------------------------------------------------------------------
                idx1++;
                //---------------------------------------------------------Geting Text-------------------------------------------------------------------------
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    model.Text += (char)((int)model.Data[idx1]);
                    idx1++;
                }


                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);

                ListOfITXtChuks.Add(model);
            }
        }

        
        protected override string GetChunkName()
        {
            return "iTXt";
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
                    foreach (var item in ListOfITXtChuks)
                    {
                        sw.WriteLine("");
                        sw.WriteLine("------- iTXt Chunk -------");
                        sw.WriteLine("Name      : " + item.Name);
                        sw.WriteLine("Size      : " + item.Size);
                        sw.WriteLine("CRC       : " + item.CRC);
                        sw.WriteLine("");
                        sw.WriteLine("Keyword          : " + item.Keyword          );
                        sw.WriteLine("CompressionFlag  : " + item.CompressionFlag  );
                        sw.WriteLine("CompressionMethod: " + item.CompressionMethod);
                        sw.WriteLine("LanguageTag      : " + item.LanguageTag      );
                        sw.WriteLine("TranslatedKeyword: " + item.TranslatedKeyword);
                        sw.WriteLine("Text             : " + item.Text);
                    }
                }
                else
                {
                    sw.WriteLine("");
                    sw.WriteLine("------- iTXt Chunk -------");
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
