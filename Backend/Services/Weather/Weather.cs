using System;
using Backend.Services.Rest;

namespace Backend.Services.Weather
{
    public class Weather
    {
        public Location location { get; set; }
        public Temperature temperature { get; set; }
        public int Humidity { get; set; }

        public static Weather Get(Rest.Weather weather)
        {
            if (weather == null) return null;
            return new Weather
            {

            };
        }
    }
}