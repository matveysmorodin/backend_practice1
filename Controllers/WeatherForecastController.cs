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
        private readonly EnumerationOfDisceplines _disceplinesEnum;
        private readonly HelloWorld _helloWorld;
        public WeatherForecastController(ILogger<WeatherForecastController> logger, TimeClientNow timeClientNow, EnumerationOfDisceplines disceplinesEnum, HelloWorld helloWorld)
        {
            _logger = logger;
            _timeClientNow = timeClientNow;
            _disceplinesEnum = disceplinesEnum;
            _helloWorld = helloWorld;
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

        [HttpGet]
        public string Disceplines()
        {
            _logger.LogInformation("EnumerationOfDisceplines вызван");
            return _disceplinesEnum.DisceplinesEnumerate();
        }
        
        [HttpGet]
        public string HelloWorld()
        {
            _logger.LogInformation("HelloWorld вызван");
            return _helloWorld.SayHello();
        }
    }
}
