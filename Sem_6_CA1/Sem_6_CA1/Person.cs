using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_6_CA1
{
    public abstract class Person
    {
        public Person()
        {
            Name = new Name("Default","Name");
            DOB = new DateTime();
        }

        public Person(Name name, DateTime dob)
        {
            Name = name;
            DOB = dob;
        }

        public Name Name { get; set; }
        public DateTime DOB { get; set; }

        public override String ToString()
        {
            return Name + ": DOB -> " + DOB;
        }
    }
}
