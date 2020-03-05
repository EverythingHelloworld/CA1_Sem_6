using System;
using System.Collections.Generic;
using System.Diagnostics;
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
            NotableVidDesc.Text = selectedCastMem.Role.SceneDesc;
            Uri filePath = new Uri(selectedCastMem.Role.NotableSceneSource);
            NotableSceneVid.Source = MediaSource.CreateFromUri(filePath);
            SetStars();
        }


        private void SetStars()
        {
            stars.FontFamily = new FontFamily("Segoe MDL2 Assets");
            for (int i=0; i < selectedCastMem.StarRating; i++)
            {
                stars.Text += "\uE735";
            }
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            // find NavigationViewItem with Content that equals InvokedItem
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            Debug.WriteLine("We are here -> " + item);
            NavView_Navigate(item as NavigationViewItem);
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
            Debug.WriteLine("Item -> " + item);
            switch (item.Tag)
            {
                case "Home":
                    this.Frame.Navigate(typeof(MainPage));
                    break;

                case "Channels":
                    this.Frame.Navigate(typeof(Channels));
                    break;
            }
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
