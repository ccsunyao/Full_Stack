using System;

namespace Exercise5
{
    class BianryTriangle
    {
        static void Main(string[] args)
        {
            int p, lastInt = 0, input;
            Console.WriteLine("Enter the Number of Rows : ");
            input = Convert.ToInt16(Console.ReadLine());
            for (int i = 1; i <= input; i++)
            {
                for (p = 1; p <= i; p++)
                {
                    if (lastInt == 1)
                    {
                        Console.Write("0");
                        lastInt = 0;
                    }
                    else if (lastInt == 0)
                    {
                        Console.Write("1");
                        lastInt = 1;
                    }
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }
    }
}
