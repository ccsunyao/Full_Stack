using System;

namespace Exercise4
{
    class StudentAndTeacherTEST
    {
        static void Main(string[] args)
        {
            Person p = new Person("Lloyd");
            p.Greet();

            Student s = new Student("Alpha");
            s.SetAge(20);
            s.Greet();
            s.ShowAge();

            Teacher t = new Teacher("Beta");
            t.SetAge(30);
            t.Greet();
            t.Explain();

            Console.ReadKey();
        }
    }
}
