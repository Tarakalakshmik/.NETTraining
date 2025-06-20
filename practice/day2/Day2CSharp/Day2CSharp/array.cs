using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    class Arrayeg
    {
        public static void signledimension()
            {
            int[] arr = new int[] { 42, 6, 8, 35, 3 };
            Console.WriteLine((arr.Rank));
            foreach(int n in arr)
            {
                Console.WriteLine(n);
            }
            }
        public static void twodimension()
        {
            int[,] arr = new int[2, 3] { { 1, 2, 3 },{ 4, 5, 6 } };
            Console.WriteLine(arr[1,1]);
            for(int i=0;i<arr.GetLength(0);i++)
            {
                for(int j=0;j<arr.GetLength(1);j++)
                {
                    Console.Write(arr[i,j]+"  ");
                    
                }
                Console.WriteLine();
            }

        }
        public static void jaggedarr()
        {
            int[][] jagr =
            {
                new int[]{5,10,15,20},
                new int[]{ 25, 30 },
                new int[]{35,40,45},
            };
            for(int i=0;i<jagr.Length;i++)
            {
                Console.WriteLine();
                for(int j=0;j<jagr[i].Length;j++)
                {
                    Console.WriteLine(jagr[i][j]);
                }
            }
            
        }
        public static void dynamicinput()
        {
           
            int r = Convert.ToInt32(Console.ReadLine());
            int c = Convert.ToInt32(Console.ReadLine());
            int[,] arr = new int[r,c];
            for (int i=0;i<r;i++)
            {
                for(int j=0;j<c;j++)
                {
                    arr[i,j]= Convert.ToInt32(Console.ReadLine());
                }
            }
        }

    }
    class array
    {
        static void Main(string[] args)
        {
            Arrayeg.signledimension();
            Console.WriteLine("******");
            Arrayeg.twodimension();
            Console.WriteLine("******");
            Arrayeg.jaggedarr();
            stringeg.str();
            Console.WriteLine("******");
            string_builder.sb();
            Console.WriteLine("******");
            int div=outmethod.calculate(10,5,out int sum,out int diff,out int product);
            Console.WriteLine("sum is {0}",sum);
            Console.WriteLine("sum is {0}", diff);
            Console.WriteLine("sum is {0}", product);
            Console.WriteLine("sum is {0}", div);
            Console.WriteLine("******");
            Console.WriteLine(outmethod.AddElements());
            Console.WriteLine(outmethod.AddElements(5,6,2));
            int[] num = new int[3];
            num[0] = 10;
            num[1] = 20;
            num[2] = 30;
            outmethod.ParamsMethod();
            outmethod.ParamsMethod(num);
            Console.Read();
        }
    }
}
