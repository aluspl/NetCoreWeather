using System;
using System.Diagnostics;

namespace Backend.Services.Weather
{
    public class Weather
    {
        public Location location { get; set; }
        public Temperature temperature { get; set; }
        public int humidity { get; set; }
       
        public static Weather Get(RootData weather)
        {
            try
            {
                if (weather == null || weather.query == null || weather.query.results == null)
                    return null;
                var returnWeather = new Weather();
                if (weather.query.results.channel.location!=null)
                {
                    returnWeather.location = weather.query.results.channel.location;
                }
                if (weather.query.results.channel.atmosphere!=null)
                {
                    returnWeather.humidity = weather.query.results.channel.atmosphere.humidity;
                }

                if (weather.query.results.channel.item != null )
                {
                    returnWeather.temperature = GetTemperature(weather.query.results.channel.item);
                }
                return returnWeather;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
        private static Temperature GetTemperature(Item item)
        {
            if (item.forecast == null || item.forecast.Length == 0) return null;
            return new Temperature
            {
                value = ToCelcius(item.forecast[0].high),
                format = "Celcius"
            };
        }
        private static double ToCelcius(double f)
        {
            double c = 5.0 / 9.0 * (f - 32);

            return (int)c;
        }
    }

    
}