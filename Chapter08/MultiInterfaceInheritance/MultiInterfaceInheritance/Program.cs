﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiInterfaceInheritance
{
    interface IRunnable
    {
        void Run();
    }

    interface IFlyable
    {
        void Run();
    }

    class FlyingCar : IRunnable, IFlyable
    {
        public void Run()
        {
            Console.WriteLine("Run! Run!");
        }

        //public void Fly()
        //{
        //    Console.WriteLine("Fly! Fly!");
        //}
    }

    class MainApp
    {
        static void Main(string[] args)
        {
            FlyingCar car = new FlyingCar();
            car.Run();
            //car.Fly();

            IRunnable runnable = car as IRunnable;
            runnable.Run();

            IFlyable flyable = car as IFlyable;
            //flyable.Fly();
        }
    }
}