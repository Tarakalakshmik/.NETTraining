//1.Write a C# Sharp program to remove the character at a given position in the string. The given position will be in the range 0..(string length -1) inclusive.
 
//Sample Input:
//"Python", 1
//"Python", 0
//"Python", 4
//Expected Output:
//Pthon
//ython
//Pythn
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC1
{
    class Question1
    {
        static void Main(string[] args)
        {
            int t;
           
            Console.WriteLine("Enter the number of test cases");
            t = Convert.ToInt16(Console.ReadLine());
            while (t>0)
            {
                string s;
                Console.WriteLine("Enter the string");
                s = Console.ReadLine();
                string s1 = " ";
                Console.WriteLine("Enter the position");
               
                int pos= Convert.ToInt32(Console.ReadLine());
                
                    char[] Chararray = s.ToCharArray();
                    for (int i = 0; i < s.Length; i++)
                    {
                        if (i != pos)
                        {
                            s1 = s1 + (Chararray[i]);
                        }

                    }
                    Console.WriteLine("String is {0}", s1);
                t--;
                }

            Console.Read();

        }
        
        }
    }

