using System;

namespace Backend.Services.Weather
{
    public class Weather
    {
        public Location location { get; set; }
        public Temperature temperature { get; set; }
        public int Humidity { get; set; }
       
        public static Weather Get(Rootobject weather)
        {
            try
            {
                if (weather == null || weather.query == null) throw new Exception("Problem with Weather");
                return new Weather
                {
                    location = weather.query.results.channel.location,
                    Humidity = weather.query.results.channel.atmosphere.humidity,
                    temperature = new Temperature {
                        value = weather.query.results.channel.item.forecast[0].low,
                        format = weather.query.results.channel.units.temperature
                    }
                };
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }

    public class Temperature
    {
        public int value { get;  set; }
        public string format { get;  set; }
    }
}