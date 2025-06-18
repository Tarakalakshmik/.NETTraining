using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignement1
{
    class question4
    {
        public static void main()
        {
            int num;
            Console.WriteLine("Enter a number");
            num = Convert.ToInt32(Console.ReadLine());
            int product;
            for(int i=0;i<=10;i++)
            {
                product = num * i;
                Console.WriteLine("{0} * {1} = {2}",num,i,product);
            }
            Console.Read();
        }
    }
}
