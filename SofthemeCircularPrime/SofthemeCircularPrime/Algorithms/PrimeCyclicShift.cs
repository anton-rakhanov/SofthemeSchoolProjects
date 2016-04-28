using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthemeCircularPrime.Algorithms
{
    class PrimeCyclicShift
    {
        // Private field which contains set of prime numbers.
        private SortedSet<int> _primeNumbers;

        public PrimeCyclicShift(SortedSet<int> primeNumbers)
        {
            this._primeNumbers = primeNumbers;
        }

        public List<int> AmountOfCircularPrimeNumbers()
        {
            // This list will contain all circular prime numbers which will be found in SortedSet.
            List<int> trueCircularPrimes = new List<int>();

            // We have to add this 2 circular prime numbers to list manually because of specific of the algorithm.
            trueCircularPrimes.Add(2);
            trueCircularPrimes.Add(5);

            while (_primeNumbers.Count > 0)
            {
                // Variable contains current prime number, it's neccessary because of specific of the algorithm
                int currentPrime = _primeNumbers.Min;

                int number = currentPrime;

                int multiplier = 1;

                // Variable contains amount of digits in number
                int digits = 0;

                // Variable contains remainder of the division.
                int modulo;

                // This part of algorithm counts digits and checks number with at least 2 digits on presence of 0,2,4,5,6,8 , it's doing to improve searching.
                while (number > 0)
                {
                    modulo = number % 10;
                    if (modulo % 2 == 0 || modulo == 5)
                    {
                        _primeNumbers.Remove(_primeNumbers.Min);
                    }
                    number /= 10;
                    multiplier *= 10;
                    digits++;
                }
                multiplier /= 10;

                number = currentPrime;

                // List will contain all varieties of the number after rotation.
                List<int> possibleCircularPrimes = new List<int>();

                // This part of algorithm rotates current number and checks if rotated varieties of this number are prime.
                for (int i = 0; i < digits; i++)
                {
                    if (_primeNumbers.Contains(number))
                    {
                        trueCircularPrimes.Add(number);
                        possibleCircularPrimes.Add(number);
                        _primeNumbers.Remove(number);
                    }
                    else
                    {
                        if (!possibleCircularPrimes.Contains(number))
                        {   
                            // This part will remove all varieties of the number after rotation from circular primes list if they are not circular primes
                            foreach (int notTrueCircPrime in possibleCircularPrimes)
                            {
                                if (trueCircularPrimes.Contains(notTrueCircPrime))
                                {
                                    trueCircularPrimes.Remove(notTrueCircPrime);
                                }
                            }
                            break;
                        }
                    }
                    modulo = number % 10;
                    number = modulo * multiplier + number / 10;
                }
            }

            trueCircularPrimes.Sort();

            return trueCircularPrimes;
        }
    }
}
