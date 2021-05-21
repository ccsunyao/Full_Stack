using System;

namespace Exercise3
{
    class Program
    {
        public static string Reverse(string str)
        {
            char[] chars = str.ToCharArray();
            char[] result = new char[chars.Length];
            for (int i = 0, j = str.Length - 1; i < str.Length; i++, j--)
            {
                result[i] = chars[j];
            }
            return new string(result);
        }
        static void Main(string[] args)
        {
            string inputString;

            Console.WriteLine("Input string:");
            inputString = Console.ReadLine();
            Console.WriteLine("Reverse String:" + Reverse(inputString));
            Console.ReadKey();
        }
    }
}
