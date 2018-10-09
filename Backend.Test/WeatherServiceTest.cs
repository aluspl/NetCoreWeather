using Backend.Services.Weather;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Test
{
    public class ForecastServiceTest
    {
        public ForecastServiceTest()
        {
            //var mockup = Substitute.For<IWeatherApi>();
            //mockup.GetWeatherAsync("").Returns(MockData.MockRoot(false, null,null));
            //weatherService = new WeatherService(mockup);
        }

        [Theory]
        [InlineData("Poland", "Wroclaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        public async Task  TestForNotNullData(string country, string city)
        {
            WeatherService weatherService = MockData.GetService(false, country, city);
            var response = await weatherService.GetAsync(country, city);
            Assert.NotNull(response);
        }

        

        [Theory]
        [InlineData("Poland", "Wroclaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        public async Task TestForNullData(string country, string city)
        {
            WeatherService weatherService = MockData.GetService(true, country, city);

            var response = await weatherService.GetAsync(country, city);
            Assert.Null(response);
        }     
    }
}
