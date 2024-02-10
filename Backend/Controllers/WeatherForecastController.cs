using Microsoft.AspNetCore.Mvc;

namespace WebApiDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static List<WeatherForecast> _forecasts = new();

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        //[Route("ListWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return _forecasts;
        }

        [HttpPost]
        //[Route("CreateWeatherForecast")]
        public bool Post()
        {
            var list = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    TemperatureC = Random.Shared.Next(-20, 55),
                    Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                })
                .ToList();

            _forecasts.AddRange(list);

             return true;
        }

        [HttpPut]
        //[Route("UpdateWeatherForecast")]
        public WeatherForecast Put()
        {
            var firstElement = _forecasts.FirstOrDefault();
            firstElement.Summary = "Updated Record";
            _forecasts[0] = firstElement;

            return firstElement;
        }

        [HttpDelete]
        //[Route("DeleteWeatherForecast")]
        public List<WeatherForecast> Delete()
        {
            _forecasts.RemoveAt(0);
            return _forecasts;
        }
    }
}
