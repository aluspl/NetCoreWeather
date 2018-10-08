using RestEase;
using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public interface IWeatherApi
    {
        [Get("yql?q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{country}, {city} \")&format=json")]
        Task<RootData> GetWeatherAsync([Path("country")]string country, [Path("city")]string city);
    }
}