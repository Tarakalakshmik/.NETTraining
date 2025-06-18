using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1
{
    class question3
    {
        public static void main()
        {
            int n1, n2;
            int  res;
            Console.WriteLine("Enter first number");
            n1 = Convert.ToInt32(Console.ReadLine());
            string op = Console.ReadLine();
            Console.WriteLine("Enter second number");
            n2 = Convert.ToInt32(Console.ReadLine());
            switch (op)
            {
                case "+":
                    res = n1 + n2;
                    Console.WriteLine("The result is {0}", res);
                    break;
                case "-":
                    res = n1 - n2;
                    Console.WriteLine("The result is {0}", res);
                    break;
                case "*":
                    res = n1 * n2;
                    Console.WriteLine("The result is {0}", res);
                    break;
                case "/":
                    res = n1 / n2;
                    Console.WriteLine("The result is {0}", res);
                    break;
                default:
                    break;
            }
            
        }
    }
}
