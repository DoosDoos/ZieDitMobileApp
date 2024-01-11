using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;

namespace ZieDitMobileApp.Services
{
    internal class EventService : IEventService
    {
        private readonly HttpClient _httpClient;
        public EventService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Event>> GetEvents()
        {
            var events = await _httpClient.GetAsync("https://145.20.17.210:7054/api/Event");
            var response = await events.Content.ReadFromJsonAsync<List<Event>>();
            return response;
        }
    }
}
