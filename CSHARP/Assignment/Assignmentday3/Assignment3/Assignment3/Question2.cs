using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    public class Student
    {
        public int rollno;
        public string name;
        public string sem;
        public string branch;
        public int[] marks = new int[5];
        public void GetMarks()
        {
            for(int i=0;i<5;i++)
            {
                Console.WriteLine("Enter subject {0} marks",i+1);
                marks[i] = Convert.ToInt32(Console.ReadLine());
            }
        }
        public Student(int rollno,string name,string sem,string branch)
        {
            this.rollno = rollno;
            this.name = name;
            this.sem = sem;
            this.branch = branch;
        }
        public void displaydetails()
        {
            Console.WriteLine("Rollno is {0}",rollno);
            Console.WriteLine("Rollno is {0}", name);
            Console.WriteLine("Rollno is {0}", sem);
            Console.WriteLine("Rollno is {0}", branch);
        }
        public void displayresult(int[] marks) 
        {
            double avg = marks.Average();
            Console.WriteLine("{0}",avg);
            bool flag = true;
            for (int i = 0; i < 5; i++)
            {
                if (marks[i] < 35)
                {
                    flag = false;
                    Console.WriteLine("Failed");
                    return;

                }
            }
                    if(avg>50 & flag)
                    {
                        Console.WriteLine("Passed");

                    }
                    else
                    {
                        Console.WriteLine("Failed");
                    }
                

                
            }
        }

    class Question2
    {
        
        public static void Main(String[] args)
        {
            Console.WriteLine("Enter Roll Number");
            int rollno = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Semester");
            string sem = Console.ReadLine();
            Console.WriteLine("Enter Branch");
            string branch = Console.ReadLine();
            Student s = new Student(rollno, name, sem, branch);
            s.GetMarks();
            s.displayresult(s.marks);
            Console.Read();

        }

    }

}
