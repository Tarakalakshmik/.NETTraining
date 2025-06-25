//2.Write a C# Sharp program to exchange the first and last characters in a given string and return the new string.
 
//Sample Input:
//"abcd"
//"a"
//"xy"
//Expected Output:
 
//dbca
//a
//yx
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class Question2
    {
        static void Main(String[] args)
        {
            int t;

            Console.WriteLine("Enter the number of test cases");
            t = Convert.ToInt16(Console.ReadLine());
            while (t > 0)
            {
                Console.WriteLine("Enter the string");
                StringBuilder s=new StringBuilder(Console.ReadLine());
                char temp;
                temp = s[0];
                s[0] = s[s.Length-1];
                s[s.Length - 1] = temp;
                Console.WriteLine("String is {0}",s);
                
                
                
                t--;

            }
            Console.Read();
        }
    }
}
