using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question3
    {
        enum day{Monday=1,Tuesday,Wednesday,Thursday,Friday,Saturday,Sunday};
        public static void days()
        {
            int a;
            Console.WriteLine("Enter a number from 1 to 7");
        doagain:
            a = Convert.ToInt32(Console.ReadLine());
            if (a < 0 || a > 7)
            {
                Console.WriteLine("Enter a number from 1 to 7");
                goto doagain;
            }
            else
            {
                Console.WriteLine(Enum.GetName(typeof(day), a)); 
            }
        }
    }
}
