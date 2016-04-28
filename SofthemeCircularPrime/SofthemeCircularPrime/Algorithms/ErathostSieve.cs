using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthemeCircularPrime.Algorithms
{
    class ErathostSieve
    {
        public SortedSet<int> FindAllPrimeNumbers(int upperLimit)
        {
            // Bit array which represents each number from 0 to upperLimit
            BitArray bitArr = new BitArray(upperLimit, true);

            // Set first 2 numbers as not prime.
            bitArr.Set(0, false);
            bitArr.Set(1, false);

            int sieveUpperLimit = (int)Math.Sqrt(upperLimit) + 1;

            // Algorithm represents sieve of eratosthenes
            for (int i = 2; i < sieveUpperLimit; i++)
            {
                if(bitArr.Get(i))
                {
                    for (int multiply = i * 2; multiply < upperLimit; multiply += i)
                    {
                        bitArr.Set(multiply, false);
                    }
                }
            }

            // SortedSet which will be filled with prime numbers
            SortedSet<int> primesSet = new SortedSet<int>();
            
            // Filling primeSet with primes.
            for(int i = 2; i < upperLimit; i++)
            {
                if(bitArr.Get(i))
                {
                    primesSet.Add(i);
                }
            }

            return primesSet;
        }
    }
}
