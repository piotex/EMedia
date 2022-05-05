using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class IDAT_Chunk : ChunkABS
    {
        public List<Chunk> ListOfIdatChuks;
        public IDAT_Chunk(byte[] _tab) //: base(_tab)
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
            ListOfIdatChuks = new List<Chunk>();
            Chunk model;

            long index = 0;
            while (index != -1)
            {
                index = GetChunkIndex(index);
                if (index == -1)
                    break;

                model = new Chunk();
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
                    body[i] = tab[i+index];
                }
                model.Data = body;

                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);
                ListOfIdatChuks.Add(model);
            }
        }

        protected override string GetChunkName()
        {
            return "IDAT";
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

                    foreach (var item in ListOfIdatChuks)
                    {
                        sw.WriteLine("");
                        sw.WriteLine("------- IDAT Chunk -------");
                        sw.WriteLine("Name      : " + item.Name);
                        sw.WriteLine("Size      : " + item.Size);
                        sw.WriteLine("CRC       : " + item.CRC);
                    }
                }
                else
                {
                    sw.WriteLine("");
                    sw.WriteLine("------- IDAT Chunk -------");
                    sw.WriteLine("Chunk does not exist.");
                }
            }
        }
    }
}
