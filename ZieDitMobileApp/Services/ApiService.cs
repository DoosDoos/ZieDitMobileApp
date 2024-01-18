using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;

namespace ZieDitMobileApp.Services
{
    public class ApiService
    {
        HttpClient httpClient;

        String ipAdress = "https://145.20.17.210:7054";

        public ApiService()
        {
            // Create a custom HttpClientHandler to ignore invalid certificates
            var handler = new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => true
            };

            // Use the custom handler with HttpClient
            httpClient = new HttpClient(handler);
        }

        List<Event> eventList = new();

        public async Task<List<Event>> GetEvents()
        {
            if (eventList?.Count > 0)
                return eventList;

            var url = $"{ipAdress}/api/Event/";

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                eventList = await response.Content.ReadFromJsonAsync<List<Event>>();
            }

            return eventList;
        }

        List<Poster> posterList = new();
        public async Task<List<Poster>> GetPosters(int eventId)
        {
            if (posterList?.Count > 0)
                return posterList;

            String url = $"{ipAdress}/api/Event/{eventId}/poster";

            Console.WriteLine(url);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                posterList = await response.Content.ReadFromJsonAsync<List<Poster>>();
            }

            return posterList;            
        }
    }
}
