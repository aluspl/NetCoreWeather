using Backend.Services.Rest;
using Microsoft.Extensions.Configuration;
using RestEase;
using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public class WeatherService : IWeatherService
    {
        private IForecast Forecast;
        public static string Url = "https://samples.openweathermap.org/data/2.5/";
        private string KEY;

        public WeatherService(IConfiguration configuration)
        {
            KEY = configuration.GetValue<string>("WeatherKey");
            Forecast = RestClient.For<IForecast>(Url);
        }


        public async Task<Weather> GetAsync(string country, string city)
        {
            var weather = await Forecast.GetWeatherAsync(KEY, city);
                if (weather!=null)
            return Weather.Get(weather);
            return null;
        }
    }
}
