﻿using System;
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
        private List<CastMember> castMembers = new List<CastMember>();

        public TV_Show()
        {
        }

        public TV_Show(String title, String showImageString, String yearOfShow, String genre, 
            String channel, String screeningTime, String synopsis, int showRating, String trailerLink, List<CastMember> castList)
        {
            castMembers = castList;
            Title = title;
            ShowImageString = showImageString;
            Genre = genre;
            YearOfShow = yearOfShow;
            Channel = channel;
            ScreeningTime = screeningTime;
            Synopsis = synopsis;
            ShowRating = showRating;
            TrailerLink = trailerLink;
        }

        public String Title { get; set; }
        public String ShowImageString { get; set; }
        public String Genre { get; set; }
        public String TrailerLink { get; set; }
        public String YearOfShow { get; set; }
        public String Channel { get; set; }
        public String ScreeningTime { get; set; }
        public String Synopsis { get; set; }
        public int ShowRating { get; set; }

        public List<CastMember> GetCastMembers() {
            return castMembers;
        }

        public void SetCastMembers(List<CastMember> castList)
        {
            castMembers = castList;
        }

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
