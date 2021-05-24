using System;

namespace Exercise1
{
    class Rectangle : Shape1
    {
        float length = 1;
        float width = 1;
        public void GetData()
        {
        again:
            Console.Write("Enter Length : ");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter Width : ");
            width = Convert.ToInt32(Console.ReadLine());
            if (length < 0 || length > 20 || width < 0 || width > 20)
            {
                Console.WriteLine("Please enter length and width between 0 and 20");
                goto again;
            }
        }

        public override float Area()
        {
            return length * width;
        }

        public override float Circumference()
        {
            return 2 * (length + width);
        }
    }
}
