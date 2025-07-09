//2.Write a class Box that has Length and breadth as its members. Write a function that adds 2 box objects and stores in the 3rd. Display the 3rd object details. Create a Test class to execute the above.
 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge3
{
    class Box
    {
        public int length;
        public int breadth;
        public static Box operator + (Box Box1, Box Box2)
        {
            Box tem = new Box();
            tem.length = Box1.length + Box2.length;
            tem.breadth = Box1.breadth + Box2.breadth;
            return tem;
        }
    }
    class Test
    {
        static void Main(string[] args)
        {
            Box b1 = new Box();
            Console.WriteLine("Enter the length of box1");
            b1.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of box1");
            b1.breadth = Convert.ToInt32(Console.ReadLine());
             Box b2 = new Box();
            Console.WriteLine("Enter the length of box2");
            b2.length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the breadth of box2");
            b2.breadth = Convert.ToInt32(Console.ReadLine());
            Box b3 = b1 + b2;  
            Console.WriteLine($"The  Length of Box 3 is {b3.length} ");
            Console.WriteLine($"The  breadth of Box 3  is { b3.breadth }");
            
            Console.Read();
        }
    }
}

﻿
  