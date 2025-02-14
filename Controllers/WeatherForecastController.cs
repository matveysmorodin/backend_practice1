using Microsoft.AspNetCore.Mvc;
using web_1try.Services;

namespace web_1try.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly TimeClientNow _timeClientNow;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, TimeClientNow timeClientNow)
        {
            _logger = logger;
            _timeClientNow = timeClientNow;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
        
        [HttpGet]
        public string ClientTime()
        {
            _logger.LogInformation("ClientTime вызван");
            return _timeClientNow.PrintTime();
        }
    }
}
