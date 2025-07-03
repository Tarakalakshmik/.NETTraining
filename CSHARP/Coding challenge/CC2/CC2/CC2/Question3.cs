//3.Write a C# program to implement a method that takes an integer as input and throws an exception if the number is negative. Handle the exception in the calling code.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC2
{
    class CheckNumberException : ApplicationException
    {
        public CheckNumberException(string message) : base(message)
        {

        }
        class Question3
        {

            public static void IsPositive(int number)
            {
                if (number > 0)
                {
                    Console.WriteLine("Entered postive value");
                }
                else
                {
                    throw new CheckNumberException("You have entered negative value,enter positive only");
                }
            }
            public static void Main()
            {
                try
                {
                    int number;
                    Console.WriteLine("Enter number");
                    number = Convert.ToInt32(Console.ReadLine());

                    IsPositive(number);


                }

                catch (CheckNumberException exception)
                {
                    Console.WriteLine(exception.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                Console.ReadLine();

            }
        }
    }
}