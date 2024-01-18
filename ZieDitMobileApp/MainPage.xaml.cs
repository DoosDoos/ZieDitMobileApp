using System.Diagnostics.Tracing;
using ZieDitMobileApp.Models;
using ZieDitMobileApp.ViewModels;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }               
    }
}