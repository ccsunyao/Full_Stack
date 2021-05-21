using System;

namespace Exercies4
{
    class ArmstrongNumber
    {
        static void Main(string[] args)
        {
            int num, r, sum, temp;
            int start, end;

            Console.Write("Input starting number of range: ");
            start = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input ending number of range : ");
            end = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Armstrong numbers in given range are: ");

            for (num = start; num <= end; num++)
            {
                temp = num;
                sum = 0;

                while (temp != 0)
                {
                    r = temp % 10;
                    temp = temp / 10;
                    sum = sum + (r * r * r);
                }
                if (sum == num)
                    Console.WriteLine(num);
            }
            Console.ReadKey();
        }
    }
}
