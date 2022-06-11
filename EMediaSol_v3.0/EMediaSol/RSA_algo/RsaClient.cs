using EMediaSol.ReaderFactory.Chunks;
using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMediaSol.RSA_algo
{
    public class RsaClient
    {
        public BigInteger Encrypt(BigInteger number)
        {
            return new BigInteger(new Encryptor().Encrypt(number.ToByteArray(), RsaNumbers.e, RsaNumbers.n));
        }
        public BigInteger Decrypt(BigInteger number)
        {
            return new BigInteger(new Decryptor().Decrypt(number.ToByteArray(), RsaNumbers.d, RsaNumbers.n));
        }
        /*
        public IDAT_Chunk EncryptIdata(IDAT_Chunk imputChunk)
        {

        }
        */
    }
}


