using System;

namespace Exercise3
{
    class Program
    {
        public static int Solution(int A, int B)
        {
            int cnt = 0;
            for (int i = A; i <= B; i++)
            {
                for(int j = 1; j <= B/2; j++)
                {
                    if(Math.Pow(j,2) == i)
                    {
                        cnt++;
                    }
                }
            }
            return cnt;
        }

        static void Main(string[] args)
        {
            int A, B;
            
            Console.WriteLine("Please enter the starting number: ");
            A = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the starting number: ");
            B = Convert.ToInt32(Console.ReadLine());
            int res = Solution(A, B);
            Console.WriteLine("No. of perfect squares is " + res.ToString());
            Console.ReadKey();
        }
    }
}
