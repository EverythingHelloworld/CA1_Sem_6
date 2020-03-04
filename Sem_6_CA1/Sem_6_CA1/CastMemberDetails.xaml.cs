using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Media.Core;
using Windows.Media.Playback;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem_6_CA1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class CastMemberDetails : Page
    {
        CastMember selectedCastMem;

        public CastMemberDetails()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedCastMem = (CastMember)e.Parameter; // get parameter
            Image img = (Image)this.FindName("castMemberImage");
            img.Source = new BitmapImage(new Uri(selectedCastMem.ImageSource));
            CastMemberName.Text = selectedCastMem.Name.ToString();
            String dob = selectedCastMem.DOB.ToString();
            dob = dob.Substring(0, 8);
            CastMemberDOB.Text = "Born: " + dob;
            CastMemberBio.Text = selectedCastMem.MiniBio;
            CastMemberRole.Text = " As: " + selectedCastMem.Role.Description;
            CastMemActiveFrom.Text = "Active From: " + selectedCastMem.Role.ActiveFrom;
            CastMemRoleBio.Text = selectedCastMem.Role.RoleBio;
            Uri filePath = new Uri("ms-appx:///videos/fitz.mp4");
            NotableSceneVid.Source = MediaSource.CreateFromUri(filePath);

            //showTitle.Text = selectedShow.Title;
            //channel.Text = selectedShow.Channel;
            //screeningTime.Text = selectedShow.ScreeningTime;
            //synopsis.Text = selectedShow.Synopsis;
            //Image img = (Image)this.FindName("showImage");
            //img.Source = new BitmapImage(new Uri(selectedShow.ShowImageString));
            //List<CastMember> castList = new List<CastMember>();
            //castList = selectedShow.GetCastMembers();
            //castGrid.ItemsSource = castList;
        }

        private void On_BackRequested(NavigationView nav, NavigationViewBackRequestedEventArgs e)
        {
            NotableSceneVid.MediaPlayer.Pause();
            this.Frame.GoBack();
        }

        public async void IMDBButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedCastMem != null)
            {
                // The URI to launch
                var imdb = new Uri(selectedCastMem.IMDB);

                // Launch the URI
                var success = await Launcher.LaunchUriAsync(imdb);
            }
        }
    }
}
