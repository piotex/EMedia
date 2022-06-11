using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMediaSol.RSA_algo
{
    public class RsaNumbers
    {
        int bit_count = ConfigClass.TestBitCount;
        public BigInteger p;
        public BigInteger q;
        public BigInteger n;
        public BigInteger fi;
        public BigInteger e;
        public BigInteger d;


        public RsaNumbers()
        {
            //_init();
        }


        public RsaNumbers GetNewObj()
        {
            if (ConfigClass.IsTestVers){
                p = new PrimeNumber().GenerateNBitPrimeNumber(bit_count);
                q = new PrimeNumber().GenerateNBitPrimeNumber(bit_count);
            }
            else{
                p = new PrimeNumber().ReadRandomPrimeNumber();
                q = new PrimeNumber().ReadRandomPrimeNumber();
            }
            while (p==q)
            {
                if (ConfigClass.IsTestVers){
                    q = new PrimeNumber().GenerateNBitPrimeNumber(bit_count);
                }
                else{
                    q = new PrimeNumber().ReadRandomPrimeNumber();
                }
            }
            n = p * q;
            fi = (p-1)*(q-1);


            if (ConfigClass.IsTestVers){
                e = new PrimeNumber().GenerateNBitPrimeNumber(bit_count);
            }
            else{
                e = new PrimeNumber().ReadRandomPrimeNumber();
            }
            while (GCD(e, fi) != 1)
            {
                e++;
            }
            if (e > fi)
            {
                throw new Exception("RsaNumbers() -> Generated to big: e");
            }

            BigInteger k = 1;
            while (((k*fi)+1)%e != 0)
            {
                k++;
            }
            d = ((k*fi)+1)/e;
            /*
            d = 1;
            while ((d*e)%fi != 1)
            {
                d++;
            }
            */
            return this;
        }

        private BigInteger GCD(BigInteger a, BigInteger b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }
            return a | b;
        }

    }

}
