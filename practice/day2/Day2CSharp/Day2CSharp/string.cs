using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    class stringeg
    {
        public static void str()
           {
        string s = "I am string";
        string s1 = "I am string";
        string s2 = s1;
            string s3 = "i am not a string";
            Console.WriteLine("reference value of s is {0}",s.GetHashCode());
            Console.WriteLine("reference value of s is {0}", s1.GetHashCode());
            Console.WriteLine("reference value of s is {0}", s2.GetHashCode());
            Console.WriteLine("reference value of s is {0}", s3.GetHashCode());
            if(s1==s2)
            {
                Console.WriteLine("yes");
            }
            if (s1 == s)
            {
                Console.WriteLine("yes");
            }
            

        }

    }
}
