using Backend.Services.Weather;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using RestEase;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using WeatherOSApp;
using Xunit;

namespace Backend.Test
{
    public interface IWeatherApi
    {
        [Get("/api/Weather/")]
        Task<Weather> GetWeather([Path] string Country, [Path] string City);
    }
    public class WeatherApiTest
    {
        [Theory]
        [InlineData("Poland","Wroclaw")]
        [InlineData("Poland", "Gdansk'")]
        [InlineData("Germany", "Berlin’")]
        public async void TestForCountryAndCity(string country, string city)
        {
            var response = await weatherApi.GetWeather(country, city);
            Assert.NotNull(response);            
        }
        private readonly IWeatherApi weatherApi;
        private readonly TestServer _testServer;

        public WeatherApiTest()
        {
            var webHostBuilder = new WebHostBuilder().UseStartup<Startup>();

            _testServer = new TestServer(webHostBuilder);
            weatherApi = RestClient.For<IWeatherApi>(_testServer.CreateClient());
        }
    }
}
