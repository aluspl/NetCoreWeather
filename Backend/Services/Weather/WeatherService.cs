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
        private readonly IWeatherApi WeatherAPI;
        private const string Url = "https://query.yahooapis.com/v1/public";


        public WeatherService(IWeatherApi weatherApi)
        {
            WeatherAPI = weatherApi;
        }

        public async Task<Weather> GetAsync(string country, string city)
        {
            try
            {
                var query = CreateQuery(country, city);
                var weather = await WeatherAPI.GetWeatherAsync(query);
                return Weather.Get(weather);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
           
        }

        public string CreateQuery(string country, string city)
        {
            return $"q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{country}, {city} \")&format=json";
        }
    }
}
