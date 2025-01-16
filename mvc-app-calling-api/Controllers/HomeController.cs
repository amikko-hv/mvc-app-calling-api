using System.Diagnostics;
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

    public IActionResult Index()
    {
        List<WeatherForecast> weatherForecasts = new List<WeatherForecast>();
        
        // Test code: Weather data
        weatherForecasts.Add(new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 5,
            Summary = "Cloudy"
        });
        weatherForecasts.Add(new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 25,
            Summary = "Sunny"
        });
        weatherForecasts.Add(new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 5,
            Summary = "Cloudy"
        });
        weatherForecasts.Add(new WeatherForecast()
        {
            Date = DateOnly.FromDateTime(DateTime.Now),
            TemperatureC = 25,
            Summary = "Sunny"
        });
        
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