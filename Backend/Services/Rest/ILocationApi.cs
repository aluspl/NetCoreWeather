using Backend.Services.Location;
using RestEase;
using System.Threading.Tasks;

namespace Backend.Services.Rest
{
    public interface ILocationApi
    {
        [Get("json")]
        Task<MapResult> GetLocationAsync([Query("address")]string City);
    }
}