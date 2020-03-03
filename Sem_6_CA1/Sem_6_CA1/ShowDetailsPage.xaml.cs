using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
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
    public sealed partial class ShowDetailsPage : Page
    {
        TV_Show selectedShow;

        public ShowDetailsPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            selectedShow = (TV_Show)e.Parameter; // get parameter
            showTitle.Text = selectedShow.Title;
            channel.Text = selectedShow.Channel;
            screeningTime.Text = selectedShow.ScreeningTime;
            synopsis.Text = selectedShow.Synopsis;
            Image img = (Image)this.FindName("showImage");
            img.Source = new BitmapImage(new Uri(selectedShow.ShowImageString));
        }
        public async void playButton_Click(object sender, RoutedEventArgs e)
        {
            if(selectedShow != null)
            {
                // The URI to launch
                var trailer = new Uri(selectedShow.TrailerLink);

                // Launch the URI
                var success = await Launcher.LaunchUriAsync(trailer);
            }
            else
            {
                Debug.WriteLine("Show is null");
            }
        }
    }
}
