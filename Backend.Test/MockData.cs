using Backend.Services.Weather;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class MockData
    {
        public static Task<RootData> MockRoot(bool NullData, string country, string city)
        {
            return new Task<RootData>(() => new RootData
            {
                query = new Query
                {
                    results = new Results
                    {
                        channel = new Channel
                        {
                            atmosphere = NullData ? null : new Atmosphere { humidity = 66 },
                            item = NullData ? null : new Item { condition = new Condition { } },
                            location = NullData ? null : new Location {  city= city, country = country }
                            
                        }
                    }
                }
            });
        }
        public static string CreateQuery(string country, string city)
        {
            return $"q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{country}, {city} \")&format=json";
        }
    }
}