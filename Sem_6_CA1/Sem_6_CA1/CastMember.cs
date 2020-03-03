using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sem_6_CA1
{
    public class CastMember : Person
    {
        public CastMember()
        {
            Name = new Name("Default", "Name");
            DOB = new DateTime();
            Role = new CastRole();
            MiniBio = "";
            StarRating = 0;
            IMDB = "";
            ImageSource = "";
        }

        public CastMember(Name name, DateTime dob, CastRole role, String miniBio, int starRating, String imdb, String imageSource) : base(name, dob)
        {
            Role = role;
            MiniBio = miniBio;
            StarRating = starRating;
            IMDB = imdb;
            ImageSource = imageSource;
        }

        public CastRole Role { get; set; }
        public String MiniBio { get; set; }
        public int StarRating { get; set; }
        public String IMDB { get; set; }
        public String ImageSource { get; set; }

        public override String ToString()
        {
            return Name + ": DOB -> " + DOB + ", Role -> " + Role + ", Mini Bio -> " + MiniBio + 
                ", Star Rating -> " + StarRating + ", IMDB -> " + IMDB;
        }
    }
}
