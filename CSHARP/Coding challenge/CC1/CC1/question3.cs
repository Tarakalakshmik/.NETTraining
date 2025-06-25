//3.Write a C# Sharp program to check the largest number among three given integers.
 
//Sample Input:
//1,2,3
//1,3,2
//1,1,1
//1,2,2
//Expected Output:
//3
//3
//1
//2
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class question3
    {
        public static void Main(String[] args)
        {

            int t;

            Console.WriteLine("Enter the number of test cases");
            t = Convert.ToInt16(Console.ReadLine());
            while (t > 0)
            {
                int[] a = new int[3];
                Console.WriteLine("Enter the three numbers");
                for (int i = 0; i < 3; i++)
                {
                    a[i] = Convert.ToInt32(Console.ReadLine());
                }
                int max = a.Max();
                Console.WriteLine("The maximum number is {0} ", max);
                t--;
                
                

            }
            Console.Read();
        }
    }
}
