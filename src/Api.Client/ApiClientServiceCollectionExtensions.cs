using System;
using Microsoft.Extensions.DependencyInjection;

namespace Api.Client
{
    public static class ApiClientServiceCollectionExtensions
    {
        public static IServiceCollection AddApiClient(this IServiceCollection services, string serviceBaseUrl)
        {
            services.AddHttpClient<IApiClient, ApiClient>(client =>
            {
                client.BaseAddress = new Uri(serviceBaseUrl);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
            });

            return services;
        }
    }
}
