using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    class outmethod
    {
        public static int calculate(int n1,int n2,out int sum,out int diff,out int product)
        {
            sum = n1 + n2;
            diff = n1 - n2;
            product = n1 * n2;
            return n1 / n2;
        }
        public static int AddElements(params int[] arr)
        {
            int sum = 0;
            foreach(int n in arr)
            {
                sum += n;
            }
            return sum;
        }
        public static void ParamsMethod(params int[] number)
        {
            Console.WriteLine("there are {0} elements",number.Length);
            
          }

    }
}
