﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace UsingMonitor
{
    class Counter
    {
        const int LOOP_COUNT = 1000;

        readonly object thisLock;

        private int count;
        public int Count
        {
            get { return count; }
        }
        public Counter()
        {
            thisLock = new object();
            count = 0;
        }
        public void Increase()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                //Console.WriteLine("Thread Increase");
                Monitor.Enter(thisLock);
                try
                {
                    count++;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
        public void Decrease()
        {
            int loopCount = LOOP_COUNT;
            while (loopCount-- > 0)
            {
                //Console.WriteLine("Thread Decrease");
                Monitor.Enter(thisLock);
                try
                {
                    count--;
                }
                finally
                {
                    Monitor.Exit(thisLock);
                }
                Thread.Sleep(1);
            }
        }
        internal class MainApp
        {
            static void Main(string[] args)
            {
                Counter counter = new Counter();

                Thread incThread = new Thread(
                    new ThreadStart(counter.Increase));
                Thread decThread = new Thread(
                    new ThreadStart(counter.Decrease));

                incThread.Start();
                decThread.Start();

                incThread.Join();
                decThread.Join();

                Console.WriteLine(counter.Count);
            }
        }
    }
}
