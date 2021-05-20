using System;

namespace Exercise2
{
    public class Arithmetic
    {
        int a, b;
        public void GetData()
        {
            Console.WriteLine("Enter Integer a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Integer b");
            b = Convert.ToInt32(Console.ReadLine());
        }

        public void MathsChoice()
        {
            Console.WriteLine("1.Addition");
            Console.WriteLine("2.Subtraction");
            Console.WriteLine("3.Multiplication");
            Console.WriteLine("4.Divsion");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Arithmetic a1 = new Arithmetic();

            int a, b;

            Console.WriteLine("Enter Integer a");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Integer b");
            b = Convert.ToInt32(Console.ReadLine());

            a1.MathsChoice();
            int c = Convert.ToInt16(Console.ReadLine());
            switch (c)
            {
                case 1:
                    Console.WriteLine("Addition Of Two Numbers : " + (a + b));
                    break;
                case 2:
                    Console.WriteLine("Subtraction Of Two Numbers : " + (a - b));
                    break;
                case 3:
                    Console.WriteLine("Multiplicaion Of Two Numbers : " + (a * b));
                    break;
                case 4:
                    Console.WriteLine("Division Of Two Numbers : " + (a / b));
                    break;
            }
            Console.ReadKey();
        }
    }
}
