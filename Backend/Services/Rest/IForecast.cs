using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Rest
{
   public interface IForecast
   {
        [Get("weather?q={city}&appid={API_KEY}")]
        Task<Weather> GetWeatherAsync(string API_KEY, string city);
   }
}
