using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel1
{
    public class File
    {
        string name;
        string filename;
        string content = "";
        String extension;
        int size;
        int line;
        ArrayList data;
        private int lineCount;

        public File(string name, string extension)
        {
            this.name = name;
            this.extension = extension;
            size = 0;
            line = 0;
            data = new ArrayList();
        }

        public File(File f)
        {
            name = f.name;
            extension = f.extension;
            size = f.size;
            line = 0;
            data = f.data;
            filename = f.filename;
        }

        public void setContent(string newContent)
        {
            content = newContent;
            size += newContent.Length;
        }

        public string getContent()
        {
            return content;
        }

        public void setData(string input)
        {
            data.Add(input);
            size += input.Length;
        }

        public void setFileName(string filename)
        {
            this.filename = filename;
        }

        public string getFileName()
        {
            return filename;
        }

        public void setLineCount(int n)
        {
            lineCount = n;
        }

        public ArrayList getData()
        {
            return data;
        }

        public string getName()
        {
            return filename;
        }

        public string getExtension()
        {
            return extension;
        }

        public int getSize()
        {
            return ++size;
        }

        public int getLine()
        {
            return line;
        }

        public void incrementLine()
        {
            line++;
        }
    }
}
