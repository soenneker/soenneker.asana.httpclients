using Soenneker.Asana.HttpClients.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Asana.HttpClients.Tests;

[Collection("Collection")]
public sealed class AsanaOpenApiHttpClientTests : FixturedUnitTest
{
    private readonly IAsanaOpenApiHttpClient _httpclient;

    public AsanaOpenApiHttpClientTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _httpclient = Resolve<IAsanaOpenApiHttpClient>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
