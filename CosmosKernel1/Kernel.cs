using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        public static LinkedList<Variable> variables;
        public static LinkedList<File> file_directory;


        protected override void BeforeRun()
        {
            Console.WriteLine("Cosmos booted successfully.");
            Console.WriteLine("Use the 'echo' command to have a text echoed back to you.");
            Console.WriteLine("For example: 'echo Hello'");
            variables = new LinkedList<Variable>();
            file_directory = new LinkedList<File>();
        }

        protected override void Run()
        {
            string input = Console.ReadLine();

            Commands.interpret(input);


           
        }

    }
}
