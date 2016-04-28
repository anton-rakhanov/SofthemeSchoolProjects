using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace SofthemeTriangles.FileToJaggedArray
{
    class Convertation
    {
        private string _pathPattern = @"{0}\Triangles\{1}.txt";

        /// <summary>
        /// Creates full path to the files that contain triangles, which are located in "..\SofthemeTriangles\SofthemeTriangles\bin\Debug\Triangles"
        /// </summary>
        /// <param name="fileName">File name which will be used to create full path to file</param>
        /// <returns>Jagged array which represents reversed triangle from file</returns>
        public int[][] ConvertFileToJaggedArray(string fileName)
        {
            // Creating full path to file
            string fullPath = string.Format(_pathPattern, Directory.GetCurrentDirectory(), fileName);
            string[] linesArray = File.ReadAllLines(fullPath);

            int[][] jaggedArray = new int[linesArray.Length][];

            // Triangle will be reversed.
            int jaggedCounter = jaggedArray.Length - 1;

            foreach (string line in linesArray)
            {
                // Spliting string by space separator. 
                string[] partsOfLine = line.Split(' ');

                // Creating inner arrays that will fill jagged array.
                int[] innerArray = new int[partsOfLine.Length];

                // Inner array counter.
                int counter = innerArray.Length - 1;

                foreach (string part in partsOfLine)
                {
                    // Variable that will contain parsed part of string.
                    int value = 0;
                    int.TryParse(part, out value);

                    innerArray[counter--] = value;
                }

                jaggedArray[jaggedCounter--] = innerArray;
            }

            return jaggedArray;
        }
    }
}
