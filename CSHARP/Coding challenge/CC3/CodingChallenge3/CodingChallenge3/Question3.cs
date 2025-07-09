//3.Write a program in C# Sharp to append some text to an existing file. If file is not available, then create one in the same workspace.


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace CodingChallenge3
{
    class Question3
    {
        static void Main()
        {
           

            string filepath = "text.txt";
            Console.WriteLine("Enter the text to append");
            string text = Console.ReadLine();
            try
            {
                StreamWriter wt = new StreamWriter(filepath, true);
                wt.WriteLine(text);
                Console.WriteLine("Text  appended successfully!!!");
                wt.Close(); 
               
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot complete operation " + ex.Message);
            }


            Console.Read();
        }
    }
}




