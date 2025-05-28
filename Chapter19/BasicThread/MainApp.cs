using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BasicThread
{
    internal class MainApp
    {
        static void DoSomething()
        {
            for (int i =0; i < 5; i++) 
                Thread.Sleep(10);
        }
        static void Main(string[] args)
        {
            Thread t1 = new Thread(new ThreadStart(DoSomething));

            Console.WriteLine("Starting thread...");
            t1.Start();

            for(int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main : {i}");
                Thread.Sleep(10);

            }
            Console.WriteLine("Waiting until thread stop...");
            t1.Join();

            Console.WriteLine("Finshed!");
        }
    }
}
