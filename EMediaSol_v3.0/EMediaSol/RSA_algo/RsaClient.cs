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
        public byte[] Encrypt(byte[] number)
        {
            return new Encryptor().Encrypt(number, RsaNumbers.e, RsaNumbers.n);
        }
        public BigInteger Encrypt(BigInteger number)
        {
            return new Encryptor().Encrypt(number, RsaNumbers.e, RsaNumbers.n);
        }
        public byte[] Decrypt(byte[] number)
        {
            return new Decryptor().Decrypt(number, RsaNumbers.d, RsaNumbers.n);
        }
        public BigInteger Decrypt(BigInteger number)
        {
            return new Decryptor().Decrypt(number, RsaNumbers.d, RsaNumbers.n);
        }
        /*
        public IDAT_Chunk EncryptIdata(IDAT_Chunk imputChunk)
        {

        }
        */
    }
}


