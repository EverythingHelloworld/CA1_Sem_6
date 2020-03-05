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
            RoleBio = "";
            NotableSceneSource = "";
            SceneDesc = "";
        }

        public CastRole(String description, String activeFrom, String roleBio, String notableSceneSource, String sceneDesc)
        {
            Description = description;
            ActiveFrom = activeFrom;
            RoleBio = roleBio;
            NotableSceneSource = notableSceneSource;
            SceneDesc = sceneDesc;
        }

        public String Description { get; set; }
        public String NotableSceneSource { get; set; }
        public String ActiveFrom { get; set; }
        public String RoleBio { get; set; }
        public String SceneDesc { get; set; }

        public override String ToString()
        {
            return "Description -> " + Description + ", ActiveFrom -> " + ActiveFrom +  ", Role Bio -> " + RoleBio +  ", Notable Scene Source -> " + NotableSceneSource;
        }
    }
}
