using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question9
    {
        public static void strcmpr()
        {
            Console.WriteLine("Enter first string");
            string str1 = Console.ReadLine();
            Console.WriteLine("Enter second string");
            string str2 = Console.ReadLine();
            bool b = Convert.ToBoolean(str1.CompareTo(str2)) ? true : false;
            if(b==false)
            Console.WriteLine("Both strings are same");
            else
                Console.WriteLine("Both strings are not same");
        }
    }
}
