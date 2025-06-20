using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2
{
    class Question2
    {
        public static void numberloop()
        {
            int a;
            Console.WriteLine("Enter a number");
            a = Convert.ToInt32(Console.ReadLine());
            for(int i=1;i<=4;i++)
            {
                if(i%2==0)
                {
                    for(int j=0;j<4;j++)
                    {
                        Console.Write("{0}",a);
                    }
                    Console.WriteLine();
                }
                else
                {
                    for (int j = 0; j < 4; j++)
                    {
                        Console.Write("{0} ", a);

                    }
                    Console.WriteLine();

                }
            }
        }

    }
}
