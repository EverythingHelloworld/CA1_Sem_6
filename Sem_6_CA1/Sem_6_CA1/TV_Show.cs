using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media.Imaging;

namespace Sem_6_CA1
{
    public class TV_Show
    {
        private List<CastMember> castMembers;

        public TV_Show()
        {
            CastList = new List<CastMember>();
        }

        public TV_Show(String title, BitmapImage showImage, String yearOfShow, String genre, 
            String channel, String screeningTime, String synopsis)
        {
            castMembers = new List<CastMember>();
            Title = title;
            ShowImage = showImage;
            Genre = genre;
            YearOfShow = yearOfShow;
            Channel = channel;
            ScreeningTime = screeningTime;
            Synopsis = synopsis;
        }

        public String Title { get; set; }
        public BitmapImage ShowImage { get; set; }
        public String Genre { get; set; }
        public String YearOfShow { get; set; }
        public String Channel { get; set; }
        public String ScreeningTime { get; set; }
        public String Synopsis { get; set; }
        public List<CastMember> CastList { get; set; }

        public void AddCastMember(CastMember castMem)
        {
            castMembers.Add(castMem);
        }

        public override String ToString(){
            return Title + ": Genre -> " + Genre + ", Year -> " + YearOfShow + ", Channel -> " + Channel +
                ", Screening Time -> " + ScreeningTime + ", Synopsis -> " + Synopsis;
        }
    }
}
