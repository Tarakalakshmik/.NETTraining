using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question6
    {
        public static void copy_array()
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
            int n1 = arr.Length;
            
            int[] arr1 = new int[n1];
            for (int i = 0; i < n; i++)
            {
                arr1[i] = arr[i];

            }
            Console.WriteLine("Copied array");
            foreach(int i in arr1)
            {
                Console.Write(i+" ");
            }
            Console.WriteLine();
            Console.WriteLine("The original array adress location is {0}",arr.GetHashCode());
            Console.WriteLine("The copied array adress location is {0}", arr1.GetHashCode());
        }
    }
}
