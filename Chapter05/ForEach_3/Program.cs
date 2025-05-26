using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForEach_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> scores = new Dictionary<string, int>()
            {
                ["지민"] = 90,
                ["세찬"] = 85,
                ["호중"] = 95
            };
            foreach (KeyValuePair<string, int> pair in scores)
            {
                Console.WriteLine($"{pair.Key} : {pair.Value}");
            }
        }
    }
}
