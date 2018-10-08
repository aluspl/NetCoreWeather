using Backend.Services.Location;
using Backend.Services.Rest;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestEase;
using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private readonly IYahooAPI Forecast;
        private readonly ILocationService _location;


        //public static string Url = "https://api.openweathermap.org/data/2.5/";
        //private const string Url = "https://api.darksky.net/";
        private const string Url = "https://query.yahooapis.com/v1/public";

        private string KEY;

        public WeatherService(IConfiguration configuration, ILocationService location)
        {
            KEY = configuration.GetValue<string>("DarkSkyKey");
            //Forecast = RestClient.For<IOpenWeatherMap>(Url);
            Forecast = RestClient.For<IYahooAPI>(Url);
            _location = location;

        }

        public async Task<Weather> GetAsync(string country, string city)
        {
            try
            {
                var query = CreateQuery(country, city);
                var weather = await Forecast.GetWeatherAsync(query);
                return Weather.Get(weather);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
           
        }

        private string CreateQuery(string country, string city)
        {
            return $"q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{country}, {city} \")&format=json";
        }
    }
}
