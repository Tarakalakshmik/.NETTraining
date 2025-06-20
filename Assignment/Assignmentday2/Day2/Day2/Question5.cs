using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question5
    {
        public static void array_operations()
        {
            int n;
            Console.WriteLine("Enter the number of elements in array");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Enter array elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());

            }

            Console.WriteLine("Total is {0} ", arr.Sum());
            Console.WriteLine("Average is {0} ", arr.Average());
            Console.WriteLine("Maximum number is {0}", arr.Max());
            Console.WriteLine("Minimum number is {0}", arr.Min());
            Array.Sort(arr);
            Console.WriteLine("Ascending order");
            foreach(int x in arr)
            {
                Console.Write(x+" ");
            }
            Array.Reverse(arr);
            Console.WriteLine();
            foreach (int x in arr)
            {
                Console.Write(x + " ");
            }
        }
    }
}
