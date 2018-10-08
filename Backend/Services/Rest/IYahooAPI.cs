using RestEase;
using System.Threading.Tasks;

namespace Backend.Services.Weather
{
    public interface IYahooAPI
    {
        [Get("yql")]
        Task<Rootobject> GetWeatherAsync([RawQueryString]string query);
    }
}