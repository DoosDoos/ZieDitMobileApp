using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.Services;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        ApiService _apiService;
        public ObservableCollection<Event> Events { get; } = new();
        public MainViewModel(ApiService apiService)
        {
            _apiService = apiService;
            GetEventsAsync();
        }

        [RelayCommand]
        async Task GoToEventPageAsync(Event evenement)
        {
            if (evenement is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(EventPage)}", true,
                new Dictionary<string, object>
                {
                    {"Event", evenement}
                });
        }

        [RelayCommand]
        async Task GetEventsAsync()
        {
            try
            {
                var events = await _apiService.GetEvents();

                if (Events.Count != 0)
                    Events.Clear();

                foreach (var evenement in events)
                    Events.Add(evenement);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Niet gelukt om evenementen op te halen: {ex.Message}", "OK");
            }
        }
    }
}
