using Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Api.Client
{
    public interface IApiClient
    {
        /// <summary>
        /// Get the latest weather forecast
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<WeatherForecast>> GetWeatherForecast();
    }
}
