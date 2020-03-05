using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Sem_6_CA1
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Channels : Page
    {
        List<TV_Show> showsSortedByYear = new List<TV_Show>();
        List<TV_Show> showsSortedByRating = new List<TV_Show>();
        List<TV_Show> showsToDisplay = new List<TV_Show>();

        public Channels()
        {
            this.InitializeComponent();
            showsToDisplay = MainPage.shows;
            showsGrid.ItemsSource = showsToDisplay;
            SortListByYear();
            SortListByRating();
            if(channelTitle != null)
                channelTitle.Text = "All";
        }

        private void NavView_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            // find NavigationViewItem with Content that equals InvokedItem
            var item = sender.MenuItems.OfType<NavigationViewItem>().First(x => (string)x.Content == (string)args.InvokedItem);
            NavView_Navigate(item as NavigationViewItem);
        }

        private void NavView_Navigate(NavigationViewItem item)
        {
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

        private void rbSortByYear_Checked(object sender, RoutedEventArgs e)
        {
            SortListByYear();
            showsToDisplay = showsSortedByYear;
            showsGrid.ItemsSource = showsToDisplay;
        }

        private void rbSortByRating_Checked(object sender, RoutedEventArgs e)
        {
            SortListByRating();
            showsToDisplay = showsSortedByRating;
            showsGrid.ItemsSource = showsToDisplay;
        }

        public void SortListByYear()
        {
            showsSortedByYear = showsToDisplay.OrderByDescending(s => s.YearOfShow).ToList();
        }

        public void SortListByRating()
        {
            showsSortedByRating = showsToDisplay.OrderByDescending(s => s.ShowRating).ToList();
        }

        private void CbFilterByChannel_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            String selected = cbFilterByChannel.SelectedValue.ToString();
            if (!selected.Equals(""))
            {
                if (channelTitle != null)
                    channelTitle.Text = selected;
            }    

            List<TV_Show> filteredList = new List<TV_Show>();
            if (selected.Equals("All"))
            {
                if (showsGrid != null)
                {
                    showsToDisplay = MainPage.shows;
                    showsGrid.ItemsSource = showsToDisplay;
                }
            }
            else if (!selected.Equals(""))
            {
                showsToDisplay = GetFilteredList(selected);
                showsGrid.ItemsSource = showsToDisplay;
            }
        }

        private List<TV_Show> GetFilteredList(String selected)
        {
            List<TV_Show> filteredList = new List<TV_Show>();
            foreach (TV_Show show in MainPage.shows)
            {
                if (show.Channel.Equals(selected))
                {
                    filteredList.Add(show);
                }
            }
            foreach (TV_Show s in filteredList)
                Debug.WriteLine("5 Filtered List:" + showsToDisplay);
            return filteredList;
        }

        private void ShowsGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            TV_Show selected = (TV_Show)showsGrid.SelectedItem;
            this.Frame.Navigate(typeof(ShowDetailsPage), selected);
        }
    }
}
