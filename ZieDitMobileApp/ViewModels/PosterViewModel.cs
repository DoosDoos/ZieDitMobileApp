using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.Services;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp.ViewModels
{
    [QueryProperty("Poster", "Poster")]
    public partial class PosterViewModel : BaseViewModel
    {
        public PosterViewModel() 
        { 
            
        }

        [ObservableProperty]
        Poster _poster;
    }
}
