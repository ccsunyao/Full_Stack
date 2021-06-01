using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise4
{
    class Person
    {
        protected string name;
        protected int age;
        
        public Person(string name)
        {
            this.name = name;
        }
        public void SetAge(int n)
        {
            this.age = n;
        }

        public virtual void Greet()
        {
            Console.WriteLine("Person " + name + " says hello.");
        }
    }
}
