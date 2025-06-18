using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class question
    {
        public static void Main()
        {
            question.Are_equal();
        }
         public static void Are_equal()
        {
            int num1,num2;
            Console.WriteLine("Enter the first number");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second number");
            num2 = Convert.ToInt32(Console.ReadLine());
            if(num1==num2)
                Console.WriteLine("Num1{0} and Num2{1} are equal",num1,num2);
            else
                Console.WriteLine("Num1{0} and Num2{1} are not equal", num1, num2);
            Console.ReadKey();
        }
    }
}
