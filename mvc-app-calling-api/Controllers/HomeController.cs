using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using mvc_app_calling_api.Models;

namespace mvc_app_calling_api.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        // A list to hold the weather forecast data
        List<WeatherForecast>? weatherForecasts = null;
        
        // A http client to send request with
        var client = new HttpClient();
        
        // Create a http request. Change the URI to match your localhost.
        var request = new HttpRequestMessage
        {
            Method = HttpMethod.Get,
            RequestUri = new Uri("http://localhost:5191/WeatherForecast"),
        };

        try
        {
            // Send request to the API and read the json response to our List
            using (var response = await client.SendAsync(request))
            {
                weatherForecasts = await response.Content.ReadFromJsonAsync<List<WeatherForecast>>();
            }
        }
        catch (Exception e)
        {
            // Errors could happen. For example, API is not available
            _logger.LogError(e.Message);
        }
        
        // Send the result to the View for rendering
        return View(weatherForecasts);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}