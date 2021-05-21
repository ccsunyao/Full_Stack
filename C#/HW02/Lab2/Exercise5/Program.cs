using System;

namespace Exercise5
{
    class Program
    {
        static void Main(string[] args)
        {
            int l, b, h;
            Box box = new Box();
            Console.WriteLine("Please enter the value of length: ");
            l = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the value of breadth: ");
            b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please enter the value of height: ");
            h = Convert.ToInt32(Console.ReadLine());
            box.setLength(l);
            box.setBreadth(b);
            box.setHeight(h);
            Console.WriteLine("Volume of Box : " + box.getVolume().ToString());
        }
    }
}
