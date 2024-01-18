using Microsoft.Extensions.Logging;
using Plugin.NFC;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.Services;
using ZieDitMobileApp.ViewModels;

namespace ZieDitMobileApp.Views;

[QueryProperty(nameof(Event), "Event")]
public partial class EventPage : ContentPage
{
    EventViewModel eventViewModel { get; set; }

    public EventPage(EventViewModel viewModel)
	{
		InitializeComponent();

        BindingContext = viewModel;
        eventViewModel = viewModel;   
        
        CrossNFC.Current.OnMessageReceived += Current_OnMessageReceived;
        CrossNFC.Current.StartListening();
    }

    public Event Event {  get; set; }

    private void OnFrameTapped(object sender, TappedEventArgs e)
    {
        Navigation.PushAsync(new PosterPage());
    }

    //Show NFC chip message
    public List<string> DownloadedPosterPaths { get; set; } = new List<string>();


    private async void Current_OnMessageReceived(ITagInfo tagInfo)
    {
        if (tagInfo == null)
        {
            return;
        }

        var tagData = tagInfo.Records.FirstOrDefault()?.Message;

        List<Poster> posters = await eventViewModel._apiService.GetPosters(Event.Id);

        if (posters != null && posters.Count > 0)
        {
            Poster matchingPoster = posters.Find(p => p.Id.ToString() == tagData);

            if (matchingPoster != null)
            {
                string posterImagePath = matchingPoster.PosterImagePath;
                posterImagePathImage.Source = ImageSource.FromUri(new Uri(posterImagePath));                

                if (IsUrl(posterImagePath))
                {
                    var imageData = await DownloadImageAsync(posterImagePath);
                    posterImagePath = SaveImageLocally(imageData, matchingPoster.Id.ToString());
                }
                DownloadedPosterPaths.Add(posterImagePath);
            }
            else
            {
                posterImagePathImage.Source = null;
                await DisplayAlert($"Evenement bevat geen posters met ID:", tagData, "OK");
            }
        }
    }

    private string SaveImageLocally(byte[] imageData, string id)
    {
        var uniqueFileName = $"poster_{id}_{DateTime.Now.Ticks}.jpg";
        var localPath = Path.Combine(FileSystem.AppDataDirectory, uniqueFileName);
        File.WriteAllBytes(localPath, imageData);
        return localPath;
    }

    private bool IsUrl(string path)
    {
        return Uri.TryCreate(path, UriKind.Absolute, out Uri uriResult)
               && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
    }

    private async Task<byte[]> DownloadImageAsync(string url)
    {
        using var httpClient = new HttpClient();
        return await httpClient.GetByteArrayAsync(url);
    }

    private void DisplayPosterButtonClicked(object sender, EventArgs e)
    {
        foreach (String poster in DownloadedPosterPaths)
        {
            Console.WriteLine(poster);
        }
        Console.WriteLine(DownloadedPosterPaths);
    }
}