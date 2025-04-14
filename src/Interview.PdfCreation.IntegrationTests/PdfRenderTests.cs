using Microsoft.AspNetCore.Mvc.Testing;

namespace Interview.PdfCreation.IntegrationTests;

public class PdfRenderTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly WebApplicationFactory<Program> _factory;

    public PdfRenderTests(WebApplicationFactory<Program> factory)
    {
        _factory = factory;
    }

    [Fact]
    public async Task GivenPdfIsRequested_WhenDarmstadtIsSelected_ThenPdfIsCreated()
    {
        // Arrange
        var cityName = "Darmstadt";
        using var client = _factory.CreateClient();

        // Act
        var response = await client.GetAsync(new Uri("/api/render/city?city=" + cityName, UriKind.Relative));

        // Assert
        Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
    }
}