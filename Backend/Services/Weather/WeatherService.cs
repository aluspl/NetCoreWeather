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
                var weather = await WeatherAPI.GetWeatherAsync(country, city);
                return Weather.Get(weather);
            }
            catch (System.Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
           
        }

       
    }
}
