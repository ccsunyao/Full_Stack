using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1
{
    class Circle : Shape1
    {
        float radius = 1;
        public void GetData()
        {
         again:
            Console.Write("Enter Radius : ");
            radius = Convert.ToSingle(Console.ReadLine());
            if (radius < 0 || radius > 20)
            {
                Console.WriteLine("Please enter length and width between 0 and 20");
                goto again;
            }
        }

        public override float Area()
        {
            return Convert.ToSingle(Math.PI * Math.Pow(radius, 2));
        }

        public override float Circumference()
        {
            return Convert.ToSingle(2 * Math.PI * radius);
        }
    }
}
