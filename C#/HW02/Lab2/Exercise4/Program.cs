using System;

namespace Exercise4
{

    class Program
    {
        static void Main(string[] args)
        {
            int[,] matrix = new int[,] { { 1, 2, 3 }, { 5, 6, 7 }, { 9, 8, 7 } };
            for (int i=0; i<matrix.GetLength(0); i++)
            {
                for (int j=0; j<matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                    Console.Write(" ");
                }
            }
            Console.ReadKey();
        }
    }
}
