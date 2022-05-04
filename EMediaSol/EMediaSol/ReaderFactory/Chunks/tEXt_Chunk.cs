using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class tEXt_Chunk : ChunkABS
    {
        public List<tEXt_Model> ListOfTEXtChuks = new List<tEXt_Model>();
        public tEXt_Chunk(byte[] _tab) //: base(_tab)
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
            ListOfTEXtChuks = new List<tEXt_Model>();
            tEXt_Model model;

            long index = 0;
            while (index != -1)
            {
                index = GetChunkIndex(index);
                if (index == -1)
                    break;

                model = new tEXt_Model();
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
                int idx1 = 0;
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    keyword += (char)((int)model.Data[idx1]);
                    idx1++;
                }

                string text = "";
                idx1++;
                while (idx1 < model.Data.Length && model.Data[idx1] != 0)
                {
                    text += (char)((int)model.Data[idx1]);
                    idx1++;
                }
                model.Keyword = keyword;
                model.Text = text;

                tmp = getNextFourBytes(ref tab, ref index);
                model.CRC = ConvertByteArrayToString(tmp);

                ListOfTEXtChuks.Add(model);
            }
        }

        protected override string GetChunkName()
        {
            return "tEXt";
        }
    }
}
