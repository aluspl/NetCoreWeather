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
        [InlineData(null, null)]

        public async void TestForNotNullData(string country, string city)
        {
            WeatherService weatherService = GetService(false, country, city);
            var response = await weatherService.GetAsync(country, city);
            Assert.NotNull(response);
        }

        private static WeatherService GetService(bool IsNull, string country, string city)
        {
            var mockup = Substitute.For<IWeatherApi>();
            mockup.GetWeatherAsync(MockData.CreateQuery(country, city)).Returns(MockData.MockRoot(IsNull, country, city));
            var weatherService = new WeatherService(mockup);
            return weatherService;
        }

        [Theory]
        [InlineData("Poland", "Wroclaw")]
        [InlineData("Poland", "Gdansk")]
        [InlineData("Germany", "Berlin")]
        [InlineData(null, null)]

        public async void TestForNullData(string country, string city)
        {
            WeatherService weatherService = GetService(true, country, city);

            var response = await weatherService.GetAsync(country, city);
            Assert.Null(response);
        }
    }
}
