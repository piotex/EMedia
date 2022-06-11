using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EMediaSol.RSA_algo
{
    public sealed class RsaNumbers
    {
        static int bit_count = ConfigClass.TestBitCount;
        public static BigInteger p;
        public static BigInteger q;
        public static BigInteger n;
        public static BigInteger fi;
        public static BigInteger e;
        public static BigInteger d;

        private RsaNumbers() { }

        private static RsaNumbers _instance;

        public static RsaNumbers GetInstance()
        {
            if (_instance == null)
            {
                _init_();
                _instance = new RsaNumbers();
            }
            return _instance;
        }

        public static void _init_()
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
            while (BigInteger.GreatestCommonDivisor(e, fi) != 1)
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
        }

    }

}
