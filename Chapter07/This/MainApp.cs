using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace This
{
    class Employee
    {
        private string Name;
        private string Position;

        public void SetName(string name)
        {
            this.Name = name;
        }
        public String GetName()
        {
            return Name;
        }
        public void SetPosition(string position)
        {
            this.Position = position;
        }
        public string GetPosition()
        {
            return Position;
        }
        internal class MainApp
        {
            static void Main(string[] args)
            {
                Employee pooh = new Employee();
                pooh.SetName("이지민");
                pooh.SetPosition("연구원");
                Console.WriteLine($"{pooh.GetName()} {pooh.GetPosition()}");

                Employee poo = new Employee();
                poo.SetName("이지");
                poo.SetPosition("연구");
                Console.WriteLine($"{poo.GetName()} {poo.GetPosition()}");

            }
        }
    }
}
