using Interview.PdfCreation.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Playwright;
using System.Net.Mime;

namespace Interview.PdfCreation.Features.RenderCityMap;

public static class RenderCityMapEndpoint
{
    public static async Task<FileContentHttpResult> Execute(string city, IBrowserWrapper browserWrapper)
    {
        var page = await browserWrapper.GetPage();
        await page.GotoAsync("https://consent.google.com/m?continue=https://www.google.com/maps/place/" + city + "&gl=DE&m=0&pc=m&uxe=eomtm&cm=2&hl=en&src=1");
        await page.GetByRole(AriaRole.Heading, new() { Name = city }).ClickAsync();

        var pdf = await page.PdfAsync(new()
        {
            PrintBackground = true
        });
        await page.CloseAsync();

        return TypedResults.File(pdf, MediaTypeNames.Application.Pdf, city + ".pdf");
    }
}
