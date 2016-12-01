using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmosKernel1
{
    public class Variable
    {
        public string name;
        public string value;
        public int number;

        public Variable(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        

        public void setName(string name)
        {
            this.name = name;
        }

        public void setValue(int number)
        {
            this.number = number;
        }

        public string getName()
        {
            return name;
        }

        public int getValue(string value)
        {
            return int.Parse(value);
        }

        public string getValue()
        {
            return value;
        }

        public int getNumberValue()
        {
            return number;
        }

    }
}
