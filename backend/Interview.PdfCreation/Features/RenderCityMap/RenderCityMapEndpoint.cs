using Interview.PdfCreation.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.Playwright;
using System.Net.Mime;

namespace Interview.PdfCreation.Features.RenderCityMap;

public static class RenderCityMapEndpoint
{
    public static async Task<FileContentHttpResult> Execute(string name, IBrowserWrapper browserWrapper)
    {
        var cityEncoded = name.Replace(" ", "%2B");
        var page = await browserWrapper.GetPage();
        await page.GotoAsync("https://consent.google.com/m?continue=https://www.google.com/maps/place/" + cityEncoded + "&gl=DE&m=0&pc=m&uxe=eomtm&cm=2&hl=en&src=1");

        if (!page.Url.StartsWith("https://www.google.com/maps/place"))
            await page.GetByRole(AriaRole.Button, new() { Name = "Reject all" }).ClickAsync();

        var searchInboxLocator = page.Locator("#searchboxinput");
        await Assertions.Expect(searchInboxLocator).ToBeVisibleAsync(new() { Timeout = 10000 });

        var pdf = await page.PdfAsync(new()
        {
            PrintBackground = true
        });

        return TypedResults.File(pdf, MediaTypeNames.Application.Pdf, name + ".pdf");
    }
}
