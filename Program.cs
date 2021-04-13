using System;
using System.Linq;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] sizeMatrix = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            int[,] matrix = new int[sizeMatrix[0], sizeMatrix[1]];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arrNumbers = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arrNumbers[col];
                }
            }

            int maxSum = int.MinValue;
            int minIdxRow = 0;
            int minIdxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)  //to avoid get out of boundaries
            {
                int currSum = 0;

                for (int col = 0; col < matrix.GetLength(1) - 1 ; col++)
                {
                    int first = matrix[row, col];
                    int sec = matrix[row, col + 1];
                    int third = matrix[row + 1, col];  // numbers in SubSquareMatrix
                    int fourth = matrix[row + 1, col + 1];

                    currSum = first + sec + third + fourth;

                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        minIdxRow = row;
                        minIdxCol = col;
                    }
                }                
            }

            Console.WriteLine(matrix[minIdxRow, minIdxCol] + " " + matrix[minIdxRow, minIdxCol + 1]);
            Console.WriteLine(matrix[minIdxRow + 1,minIdxCol] +" "+ matrix[minIdxRow +1,minIdxCol+1]);
            Console.WriteLine(maxSum);
        }
    }
}
