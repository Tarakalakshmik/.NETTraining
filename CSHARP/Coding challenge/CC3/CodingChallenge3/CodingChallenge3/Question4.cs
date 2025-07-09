//4.Write a console program that uses delegate object as an argument to call Calculator Functionalities like 1. Addition, 2. Subtraction and 3. Multiplication by taking 2 integers and returning the output to the user. You should display all the return values accordingly.




using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge3
{
    public delegate int Calculator(int num1,int num2);
    class Question4
    {
        public static int Addition(int num1, int num2)
        {
            return num1 + num2;
        }

        public static int Subtraction(int num1, int num2)
        {
            return num1 - num2;
        }
        public static int Multiplication(int num1, int num2)
        {
            return num1 * num2;
        }

        static void Main()
        {

            Calculator c = new Calculator(Addition);
            int num1,num2;
            Console.WriteLine("Enter number 1");

            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter number 2");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Addition of two numbers is :{c(num1,num2)}");
            c = new Calculator(Subtraction);
            Console.WriteLine($"Subtraction of two numbers is :{c(num1, num2)}");
            c = new Calculator(Multiplication);
            Console.WriteLine($"Multiplication of two numbers is :{c(num1, num2)}");

            Console.ReadLine();
            

        }
    }
}





