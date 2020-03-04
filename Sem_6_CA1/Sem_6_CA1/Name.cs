using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_6_CA1
{
    public class Name
    {
        public Name()
        {

        }

        public Name(String firstName, String surname)
        {
            FirstName = firstName;
            Surname = surname;
        }

        public String FirstName { get; set; }
        public String Surname { get; set; }

        public override String ToString()
        {
            return FirstName + " " + Surname;
        }
    }
}
