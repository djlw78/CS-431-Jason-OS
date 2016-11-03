using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel1
{
    class Commands
    {
        private static LinkedList<File> fileDirectory = new LinkedList<File>();

        public static void interpret(string argument)
        {
            string[] subStrings = argument.Split(' ');
            string firstArg = subStrings[0];

            String temp;
            int size = 0;

            switch (firstArg)
            {
                case "echo":
                    Console.WriteLine(subStrings[1]);
                    break;

                case "create":
                    temp = "";
                    string[] filename = subStrings[1].Split('.');
                    File file = new File(filename[0], filename[1]);
                    while (argument != "save")
                    {
                        argument = Console.ReadLine();
                        if (argument == "save")
                        {
                            file.setData(temp);
                        }
                        temp += "\n" + argument;

                    }
                    Console.WriteLine(temp);
                    Console.WriteLine("***File saved.***");
                    fileDirectory.AddLast(file);
                    size++;

                    break;

                case "dir":
                    LinkedListNode<File> filelist = fileDirectory.First;

                    while (filelist != null)
                    {
                        Console.WriteLine("File name: " + filelist.Value.getName() + "\t File extension: " + filelist.Value.getExtension() + "\t File Size: " + size);
                        filelist = filelist.Next;
                    }
                    break;

                case "set":
                    Variable v1 = new Variable(subStrings[1], subStrings[1]);
                    Variable v2 = new Variable(subStrings[2], subStrings[2]);
                    v1.setName(v2.getName());
                    v1.setValue(v2.getValueString());
                    break;

                case "add":
                    break;

                case "sub":
                    break;

                case "mul":
                    break;

                case "div":
                    break;

                default:
                    Console.WriteLine("Unknown Command");
                    break;
            }
        }
    }
}       
