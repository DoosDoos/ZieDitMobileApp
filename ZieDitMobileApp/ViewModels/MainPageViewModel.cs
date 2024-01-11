using MvvmHelpers;
using System.Net.WebSockets;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.Services;

namespace ZieDitMobileApp.ViewModels
{
    public partial class MainPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableRangeCollection<Event> Events { get; set; } = new();
        private readonly IEventService _eventService;

        public MainPageViewModel(IEventService eventService)
        {
            _eventService = eventService;
            GetEventFromApi();
        }

        private async void GetEventFromApi()
        {
            var events = await _eventService.GetEvents();

            if (Events.Count > 0)
                Events.Clear();

            if (events != null)
                Events.AddRange(events);
        }
    }
}
