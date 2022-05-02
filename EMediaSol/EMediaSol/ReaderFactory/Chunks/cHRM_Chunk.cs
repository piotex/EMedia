using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.ReaderFactory.Chunks
{
    public class cHRM_Chunk : ChunkABS
    {
        double WhitePointX;
        double WhitePointY;
        double RedX;  
        double RedY;  
        double GreenX;  
        double GreenY;  
        double BlueX; 
        double BlueY;

        public cHRM_Chunk(byte[] _tab) : base(_tab)
        {
            getData();
        }
        public void getData()
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
            return "";
        }
    }
}
