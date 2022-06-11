using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;

namespace EMediaSol.RSA_algo
{
    public class Decryptor
    {
        public byte[] Decrypt(byte[] number, BigInteger e, BigInteger n)
        {
            BigInteger num = new BigInteger(number);

            BigInteger res = BigInteger.ModPow(num, e, n);

            return res.ToByteArray();
        }
        public BigInteger Decrypt(BigInteger number, BigInteger e, BigInteger n)
        {
            return BigInteger.ModPow(number, e, n);
        }
    }
}
