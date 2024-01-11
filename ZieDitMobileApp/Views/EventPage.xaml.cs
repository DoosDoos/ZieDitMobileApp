using ZieDitMobileApp.Models;

namespace ZieDitMobileApp.Views;

public partial class EventPage : ContentPage
{
	public EventPage(Event selectedEvent)
	{
		InitializeComponent();
        BindingContext = selectedEvent;
	}

    private void OnFrameTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PosterPage());
    }
}