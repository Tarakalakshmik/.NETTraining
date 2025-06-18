using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1
{
    class question5
    {
        public static void main()
        {
            int n1, n2;
            int res;
            Console.WriteLine("Enter first number");
            n1 = Convert.ToInt32(Console.ReadLine());
            
            Console.WriteLine("Enter second number");
            n2 = Convert.ToInt32(Console.ReadLine());
            if(n1==n2)
            {
                res = (n1 + n2) * 3;
                Console.WriteLine("The result is {0}",res);
            }
            else
            {
                res = (n1 + n2);
                Console.WriteLine("The result is {0}", res);
            }
        }
}
