[![](https://img.shields.io/nuget/v/soenneker.asana.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.asana.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.asana.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.asana.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.asana.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.asana.httpclients/actions/workflows/codeql.yml)

# Soenneker.Asana.HttpClients

Provides a cached, authenticated `HttpClient` for the Asana OpenAPI client.

## Installation

```bash
dotnet add package Soenneker.Asana.HttpClients
```

## Configuration

```json
{
  "Asana": {
    "ApiKey": "your-personal-access-token"
  }
}
```

`Asana:ApiKey` is required. The client uses `https://app.asana.com/api/1.0` and `Authorization: Bearer {token}` by default. These optional settings override that behavior:

```json
{
  "Asana": {
    "ClientBaseUrl": "https://proxy.example.com/asana/",
    "AuthHeaderName": "Authorization",
    "AuthHeaderValueTemplate": "Bearer {token}"
  }
}
```

## Registration

```csharp
using Soenneker.Asana.HttpClients.Registrars;

services.AddAsanaOpenApiHttpClientAsSingleton();
```

`AddAsanaOpenApiHttpClientAsScoped()` is also available. Both registrations reuse the singleton HTTP-client cache.

## Usage

```csharp
using Soenneker.Asana.HttpClients.Abstract;

public sealed class AsanaTransport
{
    private readonly IAsanaOpenApiHttpClient _clientProvider;

    public AsanaTransport(IAsanaOpenApiHttpClient clientProvider)
    {
        _clientProvider = clientProvider;
    }

    public async Task<HttpResponseMessage> Send(HttpRequestMessage request, CancellationToken cancellationToken = default)
    {
        HttpClient client = await _clientProvider.Get(cancellationToken);
        return await client.SendAsync(request, cancellationToken);
    }
}
```

`Get()` creates the named client on first use and returns it afterward. Configuration changes do not rebuild an existing client. Do not dispose the returned `HttpClient` per request. Disposing the provider removes and disposes its named client from the shared cache.
