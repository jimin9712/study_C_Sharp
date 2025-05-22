using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Methodhiding
{
    class Base
    {
        public void MyMethod()
        {
            Console.WriteLine("Base.MyMethod()");
        }

    }
    class Derived : Base
    {
        public new void MyMethod()
        {
            Console.WriteLine("Derived.MyMethod()");
        }

    }
    internal class MainApp
    {
        static void Main(string[] args)
        {
            Base baseObj = new Base();
            baseObj.MyMethod();

            Derived derivedObj = new Derived();
            derivedObj.MyMethod();

            Base baseOrDerived = new Derived();
            baseOrDerived.MyMethod();
        }
    }
}
