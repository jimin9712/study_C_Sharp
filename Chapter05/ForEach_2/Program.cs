using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEach_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] colors = { "Red", "Green", "Blue" };
            foreach (string color in colors)
            {
                Console.WriteLine(color);
            }
        }
    }
}
