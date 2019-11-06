using System;
using System.Threading.Tasks;
using Api.Client;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ConsumingClient.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ConsumingController : ControllerBase
    {
        private readonly IApiClient _apiClient;
        private readonly ILogger<ConsumingController> _logger;

        public ConsumingController(IApiClient apiClient, ILogger<ConsumingController> logger)
        {
            _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _apiClient.GetWeatherForecast());
        }
    }
}
