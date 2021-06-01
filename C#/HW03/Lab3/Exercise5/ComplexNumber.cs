using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5
{
    class ComplexNumber
    {
        protected int real;
        protected int complex;
        public ComplexNumber(int real, int complex)
        {
            this.real = real;
            this.complex = complex;
        }
        public void SetImaginary(int complex)
        {
            this.complex = complex;
        }
        public double GetMagnitude()
        {
            return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(complex, 2));
        }
        public void Add(ComplexNumber number)
        {
            real += number.real;
            complex += number.complex;
        }

        public string toString()
        {
            return "(" + real + ", " + complex + ")";
        }
    }
}
