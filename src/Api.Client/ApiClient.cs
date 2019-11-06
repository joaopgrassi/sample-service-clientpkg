using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Contracts;

namespace Api.Client
{
    public sealed class ApiClient : IApiClient
    {
        private readonly HttpClient _client;

        public ApiClient(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<IEnumerable<WeatherForecast>> GetWeatherForecast()
        {
            // request data from our Protected API
            var response = await _client.GetAsync("/api/weather");

            if (!response.IsSuccessStatusCode)
            {
                Console.WriteLine(response.StatusCode);
                throw new Exception("Failed to get resources");
            }

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync<IEnumerable<WeatherForecast>>(responseStream);
        }
    }
}
