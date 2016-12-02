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
                    bool end = false;
                    int lineNum = 0;
                    string buffer = "";
                    string[] filename = subStrings[1].Split('.');
                    File file = new File(filename[0], filename[1]);

                    while (!end)
                    {
                        Console.Write(lineNum + ": ");
                        string read = Console.ReadLine();
                        if (read == "save")
                        {
                            break;
                        }
                        buffer += read + '\n';
                        lineNum++;
                    }

                    file.setContent(buffer);
                    file.setLineCount(lineNum);

                    Console.WriteLine("***File saved.***");
                    file.setFileName(filename[0] + "." + filename[1]);
                    Kernel.file_directory.AddLast(file);

                    break;

                case "dir":
                    filelist = Kernel.file_directory.First;

                    while (filelist != null)
                    {
                        Console.WriteLine("File name: " + filelist.Value.getName() + "\t File extension: " + filelist.Value.getExtension() + "\t File Size: " + filelist.Value.getSize() + " bytes");
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
                        }
                        else
                        {
                            node = node.Next;
                        }
                    }
                    if (!found)
                    {
                        Kernel.variables.AddLast(v1);
                    }
                    Console.WriteLine(subStrings[1] + " = " + v2.getValue(subStrings[2]));
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
                    string content = "";
                    int numTimes = int.Parse(subStrings[1]);
                    string[] bat = subStrings[2].Split('.');
                    if (!(bat[1] == "bat"))
                    {
                        Console.WriteLine("Invalid file type. Only '.bat' file extensions can be used with the run command.");
                    }
                    else if (checkFileExists(subStrings[2]) == null)
                    {
                        Console.WriteLine(subStrings[2] + " does not exist.");
                        return;
                    }
                    else
                    {

                        LinkedListNode<File> ll = Kernel.file_directory.First;
                        while (ll != null)
                        {
                            if (ll.Value.getFileName() == subStrings[2])
                            {
                                content = ll.Value.getContent();
                            }
                            ll = ll.Next;
                        }

                        
                        for (int i = 0; i < numTimes; i++)
                        {
                            int index = 0;
                            while (true)
                            {
                                string line = "";

                                while (content[index] != '\n')
                                {
                                    line += content[index];
                                    index++;
                                }
                                if (index >= content.Length)
                                {
                                    break;
                                }
                                index++;
                                interpret(line);
                            }
                        }
                    }
                    break;

                case "runall":
                    string[] fileNames = new string[subStrings.Length - 2];
                    int num = int.Parse(subStrings[1]);
                    int counter = 0;
                    string[] contents = new string[subStrings.Length - 2];
                    for (int i = 2; i < subStrings.Length; i++)
                    {
                        fileNames[counter] = subStrings[i];
                        counter++;
                    }

                    for (int j = 0; j < num; j++)
                    {
                        for (int i = 0; i < fileNames.Length; i++)
                    {
                        string[] batch = fileNames[i].Split('.');
                            if (!(batch[1] == "bat"))
                            {
                                Console.WriteLine("Invalid file type. Only '.bat' file extensions can be used with the run command.");
                            }
                            else if (checkFileExists(fileNames[i]) == null)
                            {
                                Console.WriteLine(fileNames[i] + " does not exist.");
                                return;
                            }
                            else
                            {

                                LinkedListNode<File> ll = Kernel.file_directory.First;
                                while (ll != null)
                                {
                                    if (ll.Value.getFileName() == fileNames[i])
                                    {
                                        contents[i] = ll.Value.getContent();
                                    }
                                    ll = ll.Next;
                                }

                                int index = 0;
                                while (true)
                                {
                                    string line = "";
                                    string con = "";
                                    con = contents[i];
                                    while (con[index] != '\n')
                                    {
                                        line += con[index];
                                        index++;
                                    }
                                    if (index >= con.Length)
                                    {
                                        break;
                                    }
                                    index++;
                                    interpret(line);
                                }
                            }
                        }
                    }


                    break;

                default:
                    Console.WriteLine("Unknown Command. Please try again.");
                    break;
            }
        }

        // Checks if the given File exists.
        public static File checkFileExists(String name)
        {
            LinkedListNode<File> temp = Kernel.file_directory.First;
            while (temp != null)
            {
                if (temp.Value.getName() == name)
                    return temp.Value;
                temp = temp.Next;
            }
            return null;
        }

    }
}       
