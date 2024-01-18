using CommunityToolkit.Mvvm.ComponentModel;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.Services;

namespace ZieDitMobileApp.ViewModels
{
    [QueryProperty(nameof(EventId), nameof(EventId))]
    public partial class EventPageViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        int eventId;
        public int EventId
        {
            get => eventId;
            set
            {
                eventId = value;
                OnPropertyChanged();
            }
        }

        public ObservableRangeCollection<Poster> Posters { get; set; } = new();
        private readonly IPosterService _posterService;

        public EventPageViewModel(IPosterService posterService)
        {
            _posterService = posterService;
            GetPosterFromApi();
        }

        private async void GetPosterFromApi()
        {
            var posters = await _posterService.GetPosters(EventId);

            if (Posters.Count > 0)
                Posters.Clear();

            if (posters != null)
                Posters.AddRange(posters);
        }
    }
}
