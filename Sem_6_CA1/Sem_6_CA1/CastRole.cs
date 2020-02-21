using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_6_CA1
{
    public class CastRole
    {
        public CastRole()
        {
            Description = "";
            ActiveFrom = "";
        }

        public CastRole(String description, String activeFrom)
        {
            Description = description;
            ActiveFrom = activeFrom;
        }

        public String Description { get; set; }
        public String ActiveFrom { get; set; }

        public override String ToString()
        {
            return "Description -> " + Description + ", ActiveFrom -> " + ActiveFrom;
        }
    }
}
