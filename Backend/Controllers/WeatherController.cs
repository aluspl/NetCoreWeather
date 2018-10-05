using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.Services.Weather;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherController : ControllerBase
    {
        public IWeatherService _weatherService { get; private set; }

        public WeatherController(IWeatherService weatherService)
        {
            _weatherService = weatherService; 
        }


        [HttpGet]
        [Route("{country}/{city}")]
        public IActionResult Get(string country, string city)
        {
            return Ok(_weatherService.GetAsync(country, city));
        }
    }
}