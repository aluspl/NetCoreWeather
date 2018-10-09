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
                    throw new ConvertException("Missing Weather Data Data");
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
                throw new ConvertException("Missing Weather Data Data",e);

            }
        }
        public static Temperature GetTemperature(Item item)
        {
            if (item.forecast == null || item.forecast.Length == 0)
                throw new ConvertException("Missing Temperature Data");
            return new Temperature
            {
                value = ToCelcius(item.forecast[0].high),
                format = "Celcius"
            };
        }
        public static double ToCelcius(double f)
        {
            double c = 5.0 / 9.0 * (f - 32);

            return (int)c;
        }
    }

    
}