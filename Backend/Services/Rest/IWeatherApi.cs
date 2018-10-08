using RestEase;
using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public interface IWeatherApi
    {
        [Get("yql")]
        Task<RootData> GetWeatherAsync([RawQueryString]string query);
    }
}