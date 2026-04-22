using Soenneker.Asana.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Asana.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class AsanaOpenApiHttpClientTests : HostedUnitTest
{
    private readonly IAsanaOpenApiHttpClient _httpclient;

    public AsanaOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<IAsanaOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
