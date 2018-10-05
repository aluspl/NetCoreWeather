using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public interface IWeatherService
    {
        Task<Weather> GetAsync(string country, string city);
    }
}