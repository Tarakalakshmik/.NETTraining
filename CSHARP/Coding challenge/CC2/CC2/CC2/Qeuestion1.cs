
//1.Create an Abstract class Student with Name, StudentId, Grade as members and also an abstract method Boolean Ispassed(grade) which takes grade as an input and checks whether student passed the course or not.  

//Create 2 Sub classes Undergraduate and GraduateGraduate that inherits all members of the student and overrides Ispassed(grade) method

//For the UnderGrad class, if the grade is above 70.0, then isPassed returns true, otherwise it returns false. For the Grad class, if the grade is above 80.0, then isPassed returns true, otherwise returns false.

//Test the above by creating appropriate objects


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
    abstract public class  Student
    {
        public string name;
        public string StudentId;
        public  Single grade;
        abstract public Boolean Ispassed(Single grade);
        //public void display(string name,string StudentId,Single grade,Single grade1,bool a,bool b)
        //{
        //    Console.WriteLine("Student name is {0}",name);
        //    Console.WriteLine("Student id is {0}",StudentId);
        //    Console.WriteLine("student grade in undergraduate {0}",grade);
        //    Console.WriteLine("Student passed {0}",a);
        //    Console.WriteLine("Student grade in graduate {0}",grade1);
        //    Console.WriteLine("Student passed {0}",b);


        //}
    }
    class Undergraduate : Student
    {
        override public Boolean Ispassed(Single grade)
        {
            if(grade>=70.0f)
            {
                return true;
            }
            else
                {
                return false;
            }
        }
    }
    class Graduate : Student {
        override public Boolean Ispassed(Single grade)
        {
            if (grade >= 80.0f)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }


    class Qeuestion1
    {
        static void Main(string[] args)
        {
            Undergraduate ug = new Undergraduate();
            Graduate g = new Graduate();
            Console.WriteLine("Enter student name");
            ug.name = Console.ReadLine();
            Console.WriteLine("Enter studentid");
            ug.StudentId = Console.ReadLine();
            char ch;
            
            Console.WriteLine("Enter a character G or UG graduate or Under graduate G for Grduate ,U for undergrduate");
            ch =Convert.ToChar(Console.ReadLine());
            if (ch == 'G')
            {
                Console.WriteLine("Enter grade marks for Graduate");
                ug.grade = Convert.ToSingle(Console.ReadLine());
                bool a = ug.Ispassed(ug.grade);
                Console.WriteLine(ug.Ispassed(ug.grade));
                
                    Console.WriteLine("Student {0} has passed: {1}",ug.name,a);
                
            }
            if (ch == 'U')
            {
                Console.WriteLine("Enter grade marks for under graduate");
                bool b = ug.Ispassed(ug.grade);
                g.grade = Convert.ToSingle(Console.ReadLine());
                Console.WriteLine(g.Ispassed(g.grade));
                Console.WriteLine("Student {0} has passed: {1}", ug.name, b);
            }
            //ug.display(ug.name, ug.StudentId, ug.grade, g.grade,a,b);
            Console.ReadLine();

        }
    }
}
