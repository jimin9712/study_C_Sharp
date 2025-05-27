using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Microsoft.Scripting;
using Microsoft.Scripting.Hosting;
using IronPython.Hosting;

namespace WithPython
{
    class MainApp
    {
        static void Main(string[] args)
        {
            ScriptEngine engine = Python.CreateEngine();
            ScriptScope scope = engine.CreateScope();
            scope.SetVariable("n", "이지민");
            scope.SetVariable("p", "010-1234-5678");

            ScriptSource source = engine.CreateScriptSourceFromString(
                @"
class NameCard:
    def __init__(self, name, phone):
        self.name = name
        self.phone = phone

    def printNameCard(self):
        print(self.name + ', ' + self.phone)

card = NameCard(n, p)
card
");
            dynamic result = source.Execute(scope);
            result.printNameCard();

            Console.WriteLine("{0}, {1}", result.name, result.phone);
        }
    }
}