# Strongly typed API Client 

Demonstrates a simple way to a client for consuming an API and share it as a NuGet package.
  
The idea is also to make it super simple for consuming clients to use the client. For this, the client "package" exposes an extension method on `IServiceCollection`.

1. Contracts - Simple classlib to hold classes used by the API
2. Api - The "target" API which the client is for
3. Api.Client - Where the actual client lives
4. An example "consumer" App which uses the client package

### How to install and use the client:

1. Install the package (in this code it's a project reference, but the idea is to provide it as a NuGet package)
#### ConfigureServices:

```
using Api.Client;
...

public void ConfigureServices(IServiceCollection services) 
{
    // Registers the API Client in the DI using the extension method
    // This will use a client managed by the HttpClientFactory
    services.AddApiClient(Configuration.GetValue<string>("ExternalApiBaseAddress"));
    ...
}
```

#### Using the client

```  
public class ConsumingController : ControllerBase
{
    private readonly IApiClient _apiClient;

    public ConsumingController(IApiClient apiClient)
    {
    	_apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
    	return Ok(await _apiClient.GetWeatherForecast());
    }
}  
```  

### More things

More things can be done in the client. For instance configuring authentication, adding correlation ids, registering custom message handlers and so on.