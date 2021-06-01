using System;

namespace Exercise4
{
    class Teacher : Person
    {
        public Teacher(string name) : base(name)
        {

        }
        public void Explain()
        {
            Console.WriteLine("explanation begins");
        }
        public override void Greet()
        {
            Console.WriteLine("Teacher " + name + " says hello.");
        }
    }
}




