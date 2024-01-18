using Microsoft.Extensions.Logging;
using System.Net.Http;
using ZieDitMobileApp.Services;
using ZieDitMobileApp.ViewModels;
using ZieDitMobileApp.Views;

namespace ZieDitMobileApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Akira Expanded Demo.otf, Akira");
                });

            builder.Services.AddSingleton<ApiService>();

            builder.Services.AddSingleton<MainViewModel>();
            builder.Services.AddSingleton<EventViewModel>();
            builder.Services.AddTransient<PosterViewModel>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<EventPage>();
            builder.Services.AddTransient<PosterPage>();

            builder.Services.AddTransient<HttpClient>(serviceProvider =>
            {
                var handler = new HttpClientHandler
                {
                    ClientCertificateOptions = ClientCertificateOption.Manual,
                    ServerCertificateCustomValidationCallback =
                    (httpRequestMessage, cert, cetChain, policyErrors) => true
                };

                return new HttpClient(handler);
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}