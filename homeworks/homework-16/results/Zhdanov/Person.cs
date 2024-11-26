using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zhdanov_hw_16
{
    internal class Person
    {
        public string Name { get; set; }
        public int ProcessingTime { get; set; }

        public Person(string name, int processingTime)
        {
            Name = name;
            ProcessingTime = processingTime;
        }
    }
}
