using System.Diagnostics.Tracing;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.ViewModels;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainPageViewModel mainPageViewModel)
        {
            InitializeComponent();
            BindingContext = mainPageViewModel;
        }

        private void EventFrameTapped(object sender, TappedEventArgs e)
        {
            var selectedEvent = (Event)((Frame)sender).BindingContext;
            App.Current.MainPage = new NavigationPage(new EventPage(selectedEvent));
        }
    }
}