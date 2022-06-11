using EMediaSol.ReaderFactory;
using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.RSA_algo
{
    public class IdatEncriptor
    {
        public IDAT_Chunk Encript(IDAT_Chunk iDAT)
        {
            List<Chunk> list_of_idat = iDAT.ListOfIdatChuks;

            ///int buff_size <= 2000;
            ///

            // size: 12
            // buff: 8
            // 1 1 1 1 1 1 1 1 ; 1 1 1 0  
            // 1 1 1 1 1 1 1 1 ; 1 1 1 0 0 0 0 0
            // enc
            // dec
            // 1 1 1 1 1 1 1 1 ; 1 1 1 0 0 0 0 0
            // size: 12 - buff : 8 = [ 4 ]
            // 1 1 1 1 1 1 1 1 ; 1 1 1 0


            //szyfrowanie

            return null;
        }
    }
}
