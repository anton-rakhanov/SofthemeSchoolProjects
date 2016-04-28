using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SofthemeTriangles.FileToJaggedArray;
using SofthemeTriangles.Algorithm;

namespace SofthemeTriangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Convertation convertationObj = new Convertation();
            PathFinder pathFinderObj = new PathFinder();

            bool loopIsActive = true;

            Console.WriteLine("Hello, this program was created to find maximum sums of path from top to bottom of the two triangles");
            Console.WriteLine("Please, choose a triangle for which you want to find the maximum sum of the path. \n");

            do
            {
                Console.WriteLine("Press 1 to choose 'simple_triangle'.");
                Console.WriteLine("Press 2 to choose 'triangle'.");
                Console.WriteLine("Press 0 to exit.\n");

                switch (Console.ReadKey().KeyChar)
                {
                    case '1':
                        {
                            Console.WriteLine("\n");
                            int result = pathFinderObj.MaxSumPathToEnd(convertationObj.ConvertFileToJaggedArray("simple_triangle"));
                            Console.WriteLine("Maximum sum of path for 'simple_triangle' is: " + result + "\n");
                            Console.WriteLine("Thank you for your time, good luck! \nPress any key to exit");
                            Console.ReadKey();
                            loopIsActive = false;
                            break;
                        }
                    case '2':
                        {
                            Console.WriteLine("\n");
                            int result = pathFinderObj.MaxSumPathToEnd(convertationObj.ConvertFileToJaggedArray("triangle"));
                            Console.WriteLine("\nMaximum sum of path for 'triangle' is: " + result + "\n");
                            Console.WriteLine("Thank you for your time, good luck! \nPress any key to exit");
                            Console.ReadKey();
                            loopIsActive = false;
                            break;
                        }
                    case '0':
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Thank you for your time, good luck!");
                            System.Threading.Thread.Sleep(3000);
                            loopIsActive = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("\n");
                            Console.WriteLine("Sorry but you entered wrong data, please try again\n");
                            break;
                        }
                }
            }
            while (loopIsActive);
        }
    }
}
