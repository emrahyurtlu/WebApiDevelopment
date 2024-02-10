using Microsoft.AspNetCore.Mvc;

namespace WebApiDevelopment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastCategoryController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public string[] GetCategories()
        {
            return Summaries;
        }
    }
}
