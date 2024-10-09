using Microsoft.AspNetCore.Mvc;

namespace resto.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly WeatherForecastService _weatherForecastService;
     
    public WeatherForecastController(ILogger<WeatherForecastController> logger,
        WeatherForecastService weatherForecastService)
    {
        _logger = logger;
        _weatherForecastService = weatherForecastService;
    }

    // [HttpGet]
    // [Route("{take}/example")]
    // public IEnumerable<WeatherForecast> Get([FromQuery]int max, [FromRoute]int take)
    // {
    //     var result = _weatherForecastService.Get();
    //     return result;
    // }

    [HttpGet]
    [Route("{take}/example")]
    public ObjectResult Get([FromQuery]int max, [FromRoute]int take)
    {
        var result = _weatherForecastService.Get().First();
        return StatusCode(400, result);
    }

    [HttpPost]
     public string Hello([FromBody] string name)
    {
        return $"Hello {name}";
    }
}




