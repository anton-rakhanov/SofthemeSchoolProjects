using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SofthemeCircularPrime.Algorithms;

namespace SofthemeCircularPrime
{
    class Program
    {
        private const int UpperLimit = 1000000;

        static void Main(string[] args)
        {
            Console.WriteLine("Hello, this program was created to find all circular prime numbers below one million!");
            Console.WriteLine("Press any key to start searching! \n");

            Console.ReadKey();

            var sieveObj = new ErathostSieve();
            SortedSet<int> primesSet = sieveObj.FindAllPrimeNumbers(UpperLimit);
            var shiftObj = new PrimeCyclicShift(primesSet);

            List<int> circularPrimes = shiftObj.AmountOfCircularPrimeNumbers();

            Console.WriteLine("\n\nAmount of circular prime numbers below one million are: " + circularPrimes.Count);
            Console.WriteLine("\nHere they are:");

            foreach(int circPrime in circularPrimes)
            {
                Console.Write(circPrime + " ");
            }

            Console.WriteLine("\n\nThank you for your time, good luck!");
            Console.WriteLine("\nPress any key to exit!");
            Console.ReadKey();
        }
    }
}
