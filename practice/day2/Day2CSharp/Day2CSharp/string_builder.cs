using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day2CSharp
{
    class string_builder
    {
       public static void sb()
        {
            StringBuilder s = new StringBuilder("Hello");
            s.Append("world");
            Console.WriteLine(s);
        }
    }
}
