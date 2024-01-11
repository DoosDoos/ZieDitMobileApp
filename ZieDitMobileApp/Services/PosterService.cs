using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using ZieDitMobileApp.Models;

namespace ZieDitMobileApp.Services
{
    internal class PosterService : IPosterService
    {
        private readonly HttpClient _httpClient;
        public PosterService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Poster>> GetPosters()
        {
            var events = await _httpClient.GetAsync($"https://145.20.17.210:7054/api/Event/poster");
            var response = await events.Content.ReadFromJsonAsync<List<Poster>>();
            return response;
        }
    }
}
