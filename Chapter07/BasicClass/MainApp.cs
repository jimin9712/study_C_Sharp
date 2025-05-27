using System;
namespace BasicClass
{
    class Cat
    {
        public string name;
        public int Color;

        public void Meow()
        {
            Console.WriteLine($"{name} : 야옹");
        }
    }
    class MainApp
    {
        static void Main(string[] args)
        {
            Cat kitty = new Cat();
            kitty.Color = "";
            kitty.name = "고양이";
            kitty.Meow();
            Console.WriteLine($"{kitty.name} : ");
        }
    }
}