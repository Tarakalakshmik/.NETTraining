//3. Write a program in C# Sharp to count the number of lines in a file.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace Assignment6
{
    class Question3
    {
        static void Main()
        {
            string filepath = "C:\\Users\\tarakal\\Documents\\.NetTraining\\CSHARP\\Assignment\\Ass6q4.txt";
            //string fp = "C:\\Users\\tarakal\\Documents\\.NetTraining\\CSHARP\\Assignment\\Ass6q3.txt";

            try
            {
                string[] lines = File.ReadAllLines(filepath);
                //string[] l = File.ReadAllLines(fp);
                int count = lines.Length;
                //int c = l.Length;
                Console.WriteLine($"Number of lines in the file {filepath} are: {count}");
                //Console.WriteLine($"Number of lines in the file {fp} are: {c}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: File not present at the given path");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error in reading the file", e.Message);
            }

            Console.Read();
        }
    }
}



