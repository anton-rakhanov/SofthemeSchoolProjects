using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SofthemeTriangles.Algorithm
{
    class PathFinder
    {
        /// <summary>
        /// Finds the max sum of path from top to bottom.
        /// </summary>
        /// <param name="triangle">Triangle for which need to find max sum path</param>
        /// <returns>Value of the last array from jagged array that represents max sum of path</returns>
        public int MaxSumPathToEnd(int[][] triangle)
        {
            int firstResult;
            int secondResult;

            for (int i = 0; i <= triangle.Length - 1; i++)
            {
                for (int j = triangle[i].Length - 1; j >= 1; j--)
                {
                    /*
                     * Algorithm starts from right top corner of the triangle and separate it into small triangles,
                     * compares results of it sums, choose greatest, rewrite value in row below current and so on until the end of triangle.*/
                    firstResult = triangle[i][j] + triangle[i+1][j-1];
                    secondResult = triangle[i][j-1] + triangle[i+1][j-1];
                    triangle[i+1][j-1] = (firstResult > secondResult) ? firstResult : secondResult;
                }
            }

            return triangle[triangle.Length - 1][0];
        }

    }
}
