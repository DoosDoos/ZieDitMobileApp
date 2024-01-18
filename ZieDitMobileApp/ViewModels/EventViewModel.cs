using CommunityToolkit.Mvvm.ComponentModel;
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
    public partial class EventViewModel : BaseViewModel 
    {
        public ApiService _apiService;
        public ObservableCollection<Poster> Posters { get; } = new();
        public EventViewModel(ApiService apiService)
        {
            _apiService = apiService;
        }
    }
}
