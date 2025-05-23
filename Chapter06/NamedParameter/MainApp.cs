using System;
namespace NamedParameter
{
    internal class MainApp
    {
        static void PrintProfile(string name, string phone)
        {
            Console.WriteLine($"name : {name}, phone: {phone}");
        }
        static void Main(string[] args)
        {
            PrintProfile(name: "이지민", phone: "010-5392-9712");
            PrintProfile(name: "이지민1", phone: "110-5392-9712");
            PrintProfile(name: "이지민2", phone: "210-5392-9712");
            PrintProfile(name: "이지민3", phone: "310-5392-9712");
        }
    }
}
