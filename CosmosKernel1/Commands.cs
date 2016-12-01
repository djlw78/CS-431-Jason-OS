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

        private static int a, b;
        private static Variable v1, v2, v3;


        public static void interpret(string argument)
        {
            string[] subStrings = argument.Split(' ');
            string firstArg = subStrings[0];

            Boolean found;

            v1 = new Variable(subStrings[1], subStrings[1]);
            v2 = new Variable(subStrings[2], subStrings[2]);
            v3 = new Variable(subStrings[3], subStrings[3]);

            LinkedListNode<Variable> node;
            LinkedListNode<File> filelist;

            String temp;

            switch (firstArg)
            {
                case "echo":

                    node = Kernel.variables.First;
                    found = false;
                    while (node != null)
                    {
                        if (node.Value.name == subStrings[1])
                        {
                            Console.WriteLine("Value = " + node.Value.getNumberValue());
                            found = true;
                        }
                        node = node.Next;
                    }

                    if (!found)
                    {
                        Console.WriteLine(subStrings[1]);
                    }
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
                    Kernel.file_directory.AddLast(file);

                    break;

                case "dir":
                    filelist = Kernel.file_directory.First;

                    while (filelist != null)
                    {
                        Console.WriteLine("File name: " + filelist.Value.getName() + "\t File extension: " + filelist.Value.getExtension() + "\t File Size: " + filelist.Value.getSize());
                        filelist = filelist.Next;
                    }
                    break;

                case "set":

                    int n;

                    node = Kernel.variables.First;

                    found = false;

                    try
                    {
                        n = int.Parse(subStrings[2]);
                        int value = v2.getValue(subStrings[2]);
                        v1.setValue(value);
                    }
                    catch
                    {
                        v1 = v2;
                    }

                    while (node != null)
                    {
                        if (node.Value.name == v1.getName())
                        {
                            node.Value.setValue(v1.getNumberValue());
                            found = true;
                            break;
                        } else
                        {
                            node = node.Next;
                        }
                    }
                    if(!found)
                    {
                        Kernel.variables.AddLast(v1);
                    }

                    break;

                case "add":

                    node = Kernel.variables.First;

                    while (node != null)
                    {
                        if (node.Value.name == v1.getName())
                        {
                            a = node.Value.getNumberValue();
                        }
                        else if (node.Value.name == v2.getName())
                        {
                            b = node.Value.getNumberValue();
                        }
                        node = node.Next;
                    }

                    try
                    {
                        a = int.Parse(subStrings[1]);
                    }
                    catch
                    {
                        v1 = new Variable(subStrings[1], subStrings[1]);
                    }
                    try
                    {
                        b = int.Parse(subStrings[2]);
                    }
                    catch
                    {
                        v2 = new Variable(subStrings[2], subStrings[2]);
                    }

                    v3.setValue(a + b);
                    Kernel.variables.AddLast(v3);
                    Console.WriteLine(v3.getName() + " value = " + v3.getNumberValue());
                    break;

                case "sub":
                    node = Kernel.variables.First;

                    while (node != null)
                    {
                        if (node.Value.name == v1.getName())
                        {
                            a = node.Value.getNumberValue();
                        }
                        else if (node.Value.name == v2.getName())
                        {
                            b = node.Value.getNumberValue();
                        }
                        node = node.Next;
                    }

                    try
                    {
                        a = int.Parse(subStrings[1]);
                    }
                    catch
                    {
                        v1 = new Variable(subStrings[1], subStrings[1]);
                    }
                    try
                    {
                        b = int.Parse(subStrings[2]);
                    }
                    catch
                    {
                        v2 = new Variable(subStrings[2], subStrings[2]);
                    }

                    v3.setValue(a - b);
                    Kernel.variables.AddLast(v3);
                    Console.WriteLine(v3.getName() + " value = " + v3.getNumberValue());
                    break;

                case "mul":
                    node = Kernel.variables.First;

                    while (node != null)
                    {
                        if (node.Value.name == v1.getName())
                        {
                            a = node.Value.getNumberValue();
                        }
                        else if (node.Value.name == v2.getName())
                        {
                            b = node.Value.getNumberValue();
                        }
                        node = node.Next;
                    }

                    try
                    {
                        a = int.Parse(subStrings[1]);
                    }
                    catch
                    {
                        v1 = new Variable(subStrings[1], subStrings[1]);
                    }
                    try
                    {
                        b = int.Parse(subStrings[2]);
                    }
                    catch
                    {
                        v2 = new Variable(subStrings[2], subStrings[2]);
                    }

                    v3.setValue(a * b);
                    Kernel.variables.AddLast(v3);
                    Console.WriteLine(v3.getName() + " value = " + v3.getNumberValue());
                    break;

                case "div":
                    node = Kernel.variables.First;

                    while (node != null)
                    {
                        if (node.Value.name == v1.getName())
                        {
                            a = node.Value.getNumberValue();
                        }
                        else if (node.Value.name == v2.getName())
                        {
                            b = node.Value.getNumberValue();
                        }
                        node = node.Next;
                    }

                    try
                    {
                        a = int.Parse(subStrings[1]);
                    }
                    catch
                    {
                        v1 = new Variable(subStrings[1], subStrings[1]);
                    }
                    try
                    {
                        b = int.Parse(subStrings[2]);
                    }
                    catch
                    {
                        v2 = new Variable(subStrings[2], subStrings[2]);
                    }

                    v3.setValue(a / b);
                    Kernel.variables.AddLast(v3);
                    Console.WriteLine(v3.getName() + " value = " + v3.getNumberValue());
                    break;

                case "run":
                    int numTimes = int.Parse(subStrings[1]);
                    break;

                case "runall":
                    break;

                default:
                    Console.WriteLine("Unknown Command");
                    break;
            }
        }
    }
}       
