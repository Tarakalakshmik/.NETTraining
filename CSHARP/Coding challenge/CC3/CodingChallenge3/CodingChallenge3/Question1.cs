//1.Write a program to find the Sum and the Average points scored by the teams in the IPL. Create a Class called CricketTeam that has a function called Pointscalculation(int no_of_matches) that takes no.of matches as input and accepts that many scores from the user. The function should then return the Count of Matches, Average and Sum of the scores.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge3
{
    class CricketTeam
    {
        public static void Pointscalculation(int no_of_matches)
        {
            int n = no_of_matches;
            int total = 0;
            for(int i=0;i<n;i++)
            {
                Console.WriteLine($"Enter score of {i+1} match:");
                total=total+Convert.ToInt32(Console.ReadLine());

            }
           
            Console.WriteLine($"Total number of matches played is { n }");
            Console.WriteLine($"Total sum of scores of all matches is {total}");
            Console.WriteLine($"Average points is {(float)total/n:F2}");
        }
        static void Main()
        {
            int no_of_matches;
            Console.WriteLine("Enter no of matches");
            no_of_matches = Convert.ToInt32(Console.ReadLine());
            Pointscalculation(no_of_matches);
            Console.WriteLine("Press any key to exit");
            Console.ReadLine();
        }
    }
}
