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
        String extension;
        string date;
        int size;
        ArrayList data;

        public File(string name, string extension)
        {
            this.name = name;
            this.extension = extension;
            size = 0;
            data = new ArrayList();
        }

        public void setData(string input)
        {
            data.Add(input);
        }

        public ArrayList getData()
        {
            return data;
        }

        public string getName()
        {
            return name;
        }

        public string getExtension()
        {
            return extension;
        }

        public int getSize()
        {
            return ++size;
        }
    }
}
