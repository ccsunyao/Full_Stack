using System;

namespace Exercise4
{
    class Student : Person
    {
        public Student(string name) : base(name)
        {

        }
        public void GoToClasses()
        {
            Console.WriteLine("I'm going to class.");
        }
        public void ShowAge()
        {
            Console.WriteLine("My age is "+age+" years old."); 
        }
        public override void Greet()
        {
            Console.WriteLine("Student " + name + " says hello.");
        }
    }
}
