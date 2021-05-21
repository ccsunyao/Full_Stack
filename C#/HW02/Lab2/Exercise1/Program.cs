using System;

namespace Exercise1
{
    class Program
    {
        static void Main(string[] args)
        {
            Rectangle r = new Rectangle();
            r.GetData();
            Console.WriteLine("Area:" + r.GetArea());
            Console.WriteLine("Perimeter" + r.GetPerimeter());
            Console.ReadKey();
        }
    }
}
