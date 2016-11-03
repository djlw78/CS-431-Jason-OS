using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {


        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully.");
            Console.WriteLine("Use the 'echo' command to have a text echoed back to you.");
            Console.WriteLine("For example: 'echo Hello'");
        }

        protected override void Run()
        {
            string input = Console.ReadLine();

            Commands.interpret(input);


           
        }

    }
}
