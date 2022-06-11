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
        BigInteger p;
        BigInteger q;
        BigInteger n;
        BigInteger fi;
        BigInteger e;
        BigInteger d;


        public RsaNumbers()
        {
            _init();
        }


        private void _init()
        {
            p = new PrimeNumber().ReadRandomPrimeNumber();
            while (p==q)
            {
                q = new PrimeNumber().ReadRandomPrimeNumber();
            }

        }

    }

}
