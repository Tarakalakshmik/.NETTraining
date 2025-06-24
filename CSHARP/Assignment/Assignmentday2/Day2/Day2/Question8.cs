using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question8
    {
        public static void strrev()
        {
            Console.WriteLine("Enter a string");
            string s = Console.ReadLine();
            char[] CharArray = s.ToCharArray();
            Array.Reverse(CharArray);
            Console.WriteLine("Reversed string is ");
            foreach(char x in CharArray)
            {
                Console.Write(x);
            }
            Console.WriteLine();
        }
    }
}
