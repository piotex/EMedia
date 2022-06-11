using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;

namespace EMediaSol.RSA_algo
{
    public class PrimeNumber
    {
        private List<BigInteger> _numbers = new List<BigInteger>(){
            1,
            3


            };



        public BigInteger ReadRandomPrimeNumber()
        {
            //string path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\PrimeNumbers.txt";
            string path = @"C:\Users\pkubo\OneDrive\Dokumenty\GitHub\EMedia\PrimeNumbers.txt";

            int counter = 0;

            int rInt = new Random().Next(0, System.IO.File.ReadLines(path).Count()-1);

            foreach (string line in File.ReadLines(path))
            {
                System.Console.WriteLine(line);
                if (counter == rInt)
                {
                    return BigInteger.Parse(line);
                }
                counter++;
            }
            return -1;
        }
        public BigInteger GenerateNBitPrimeNumber(int bit_count)
        {
            while (true)
            {
                int n = bit_count;
                int certainty = 1000;
                BigInteger primeCandidate = getLowLevelPrime(n);
                if (!IsProbablePrime(primeCandidate, certainty))
                {
                    continue;
                }
                else
                {
                    return primeCandidate;
                }
            }
        }


        private int[] first_primes_list = new int[]{   2,   3,   5,   7,  11,  13,  17, 
                                                      19,  23,  29,  31,  37,  41,  43,  
                                                      47,  53,  59,  61,  67,  71,  73,  
                                                      79,  83,  89,  97, 101, 103,
                                                     107, 109, 113, 127, 131, 137, 139,
                                                     149, 151, 157, 163, 167, 173, 179,
                                                     181, 191, 193, 197, 199, 211, 223,
                                                     227, 229, 233, 239, 241, 251, 257,
                                                     263, 269, 271, 277, 281, 283, 293,
                                                     307, 311, 313, 317, 331, 337, 347, 349 };
        private BigInteger nBitRandom(int bit_count)
        {
            Random random = new Random();
            byte[] data = new byte[bit_count];
            random.NextBytes(data);

            data[data.Length - 1] = 127;

            return new BigInteger(data);
        }

        private BigInteger getLowLevelPrime(int bit_count)
        {
            while (true)
            {
                var prime_candidate = nBitRandom(bit_count);
                foreach (var divisor in first_primes_list)
                {
                    if (prime_candidate % divisor == 0 && (divisor*divisor) <= prime_candidate)
                    {
                        break;
                    }
                    else
                    {
                        return prime_candidate;
                    }
                }
            }
        }

        //Miller–Rabin primality test
        //http://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
        private bool IsProbablePrime(BigInteger source, int certainty)
        {
            if (source == 2 || source == 3)
                return true;
            if (source < 2 || source % 2 == 0)
                return false;

            BigInteger d = source - 1;
            int s = 0;

            while (d % 2 == 0)
            {
                d /= 2;
                s += 1;
            }

            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[source.ToByteArray().LongLength];
            BigInteger a;

            for (int i = 0; i < certainty; i++)
            {
                do
                {
                    // This may raise an exception in Mono 2.10.8 and earlier.
                    // http://bugzilla.xamarin.com/show_bug.cgi?id=2761
                    rng.GetBytes(bytes);
                    a = new BigInteger(bytes);
                }
                while (a < 2 || a >= source - 2);

                BigInteger x = BigInteger.ModPow(a, d, source);
                if (x == 1 || x == source - 1)
                    continue;

                for (int r = 1; r < s; r++)
                {
                    x = BigInteger.ModPow(x, 2, source);
                    if (x == 1)
                        return false;
                    if (x == source - 1)
                        break;
                }

                if (x != source - 1)
                    return false;
            }

            return true;
        }

        //Miller–Rabin primality test
        //http://rosettacode.org/wiki/Miller%E2%80%93Rabin_primality_test#C.23
        private bool IsPrime(int n, int k)
        {
            if ((n < 2) || (n % 2 == 0)) return (n == 2);

            int s = n - 1;
            while (s % 2 == 0) s >>= 1;

            Random r = new Random();
            for (int i = 0; i < k; i++)
            {
                int a = r.Next(n - 1) + 1;
                int temp = s;
                long mod = 1;
                for (int j = 0; j < temp; ++j) mod = (mod * a) % n;
                while (temp != n - 1 && mod != 1 && mod != n - 1)
                {
                    mod = (mod * mod) % n;
                    temp *= 2;
                }

                if (mod != n - 1 && temp % 2 == 0) return false;
            }
            return true;
        }

    }
}

