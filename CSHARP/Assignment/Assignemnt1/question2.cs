using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1
{
    
    class question2
    {
        
        public static void is_positive()
        {
            Console.WriteLine("Enter a Number");
            int num = int.Parse(Console.ReadLine());
            if(num>=0)
            {
                Console.WriteLine("Number {0} is positive number",num);
            }
            else
            {
                Console.WriteLine("Number {0} is negative number", num);
            }
        }

    }
}
