using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Asana.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Asana.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class AsanaOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="IAsanaOpenApiHttpClient"/> as a singleton service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddAsanaOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<IAsanaOpenApiHttpClient, AsanaOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IAsanaOpenApiHttpClient"/> as a scoped service backed by the singleton HTTP-client cache.
    /// </summary>
    public static IServiceCollection AddAsanaOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<IAsanaOpenApiHttpClient, AsanaOpenApiHttpClient>();

        return services;
    }
}
