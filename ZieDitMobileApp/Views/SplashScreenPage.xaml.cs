namespace ZieDitMobileApp.Views;

public partial class SplashScreenPage : ContentPage
{
	public SplashScreenPage()
	{
		InitializeComponent();
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        // Scale the logo
        await logoImage.ScaleTo(1.5, 2000); // Adjust scale factor and duration as needed

        // Navigate to MainPage
        //Application.Current.MainPage = new MainPage();
    }
}