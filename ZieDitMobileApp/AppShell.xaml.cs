using System.Diagnostics.Tracing;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(EventPage), typeof(EventPage));
        }
    }
}