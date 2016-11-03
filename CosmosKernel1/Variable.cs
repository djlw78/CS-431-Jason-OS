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
        public Int32 number;

        public Variable(string name, string value)
        {
            this.name = name;
            this.value = value;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setValue(Int32 number)
        {
            this.number = number;
        }

        public string getName()
        {
            return name;
        }

        public Int32 getValueString()
        {
            return Int32.Parse(value);
        }
    }
}
