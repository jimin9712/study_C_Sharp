﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Enum2
{
    class MainApp
    {
        enum DialogResult { YES, NO, CANCEL, CONFIRM, OK }

        static void Main(string[] args)
        {
            DialogResult result = DialogResult.YES;

            Console.WriteLine(result == DialogResult.YES);
            Console.WriteLine(result == DialogResult.NO);
            Console.WriteLine(result == DialogResult.CANCEL);
            Console.WriteLine(result == DialogResult.CONFIRM);
            Console.WriteLine(result == DialogResult.OK);
        }
    }
}