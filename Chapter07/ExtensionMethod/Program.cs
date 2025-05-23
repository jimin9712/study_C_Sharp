using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ExtensionMethod
{
    public static class IntergerExtension
    {
        public static int Square(this int myInt)
        {
            return myInt * myInt;
        }

        public static int Power(this int myInt, int exponent)
        {
            int result = myInt;
            for (int i = 0; i < exponent; i++)
                result = result * myInt;

            return result;
           
    }
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
