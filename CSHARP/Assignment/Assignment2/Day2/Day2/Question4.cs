using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question4
    {
        public static void avg_min_max()
        {
            int n, sum = 0, max = 0, s;
            Console.WriteLine("Enter the number of elements in array");
            n = Convert.ToInt32(Console.ReadLine());
            int[] arr = new int[n];
            Console.WriteLine("Enter array elements");
            for (int i = 0; i < n; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
                sum = sum + arr[i];
                if (arr[i] > max)
                {
                    max = arr[i];
                }
            }
            for(int j=n;j>0;j--)
            { 
            for (int i = 0; i < j; i++)
            {
                max = arr[0];
                if (arr[i] > max)
                {

                    max = arr[i];

                }
            }
                s = max;
                max = arr[j-1 ];
                arr[j -1] = max;
                
            }
            
        
    
                foreach (int i in arr)
            {
                Console.Write(i+" ");
            }

            int min = arr[0];
            for(int i=1;i<n;i++)
            {
                if(arr[i]<min)
                {
                    min = arr[i];
                }
            }
            Console.WriteLine("Average is {0} ",sum/n);
            Console.WriteLine("Maximum number is {0}",max);
            Console.WriteLine("Minimum number is {0}", min);

        }
    }
}
