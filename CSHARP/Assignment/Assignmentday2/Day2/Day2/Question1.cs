using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question1
    {
        public static void swap()
        {
            int a, b;
            Console.WriteLine("Enter the first integer");
            a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the second integer");
            b = Convert.ToInt32(Console.ReadLine());
            int c;
            c = a;
            a = b;
            b = c;
            Console.WriteLine("After swapping the numbers are {0} and {1}",a,b);
        }
    }
}
