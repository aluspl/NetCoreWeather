using Backend.Services.Weather;
using System;
using Xunit;

namespace Backend.Test
{
    public class ForecastServiceTest
    {
        public ForecastServiceTest()
        {
            weatherService = new WeatherService();
        }
        private readonly IWeatherService weatherService;
        [Fact]
        public void WeatherServiceIsNotNull()
        {
            Assert.NotNull(weatherService);
        }
    }
}
