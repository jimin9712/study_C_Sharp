using System;
namespace OptionalPrarmeter
{
    internal class MainApp
    {
        static void PrintProfile(string name, string phone = "")
        {
            Console.WriteLine($"name : {name}, phone: {phone}");
        }
        static void Main(string[] args)
        {
            PrintProfile("지민");
            PrintProfile("이지민","110-5392-9712");
            PrintProfile(name: "자민");
            PrintProfile(name: "재민", phone: "310-5392-9712");
        }
    }
}

