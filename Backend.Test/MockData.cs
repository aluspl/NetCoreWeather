using Backend.Services.Weather;
using NSubstitute;
using RestEase;
using System.Threading.Tasks;

namespace Backend.Test
{
    public class MockData
    {
        public static Task<RootData> MockRoot(bool NullData, string country, string city)
        {
            return new Task<RootData>(() => CreatedMockRoot(NullData, country, city));
        }

        private static RootData CreatedMockRoot(bool NullData, string country, string city)
        {
            return new RootData
            {
                query = new Query
                {
                    results = new Results
                    {
                        channel = new Channel
                        {
                            atmosphere = NullData ? null : new Atmosphere { humidity = 66 },
                            item = NullData ? null : new Item { condition = new Condition { } },
                            location = NullData ? null : new Location { city = city, country = country }

                        }
                    }
                }
            };
        }

        public static string CreateQuery(string country, string city)
        {
            return $"q=select * from weather.forecast where woeid in (select woeid from geo.places(1) where text=\"{country}, {city} \")&format=json";
        }
        public static WeatherService GetService(bool IsNull, string country, string city)
        {
            var mockup = Substitute.For<IWeatherApi>();

            mockup.GetWeatherAsync(country, city).Returns(CreatedMockRoot(IsNull, country, city));
            var weatherService = new WeatherService(mockup);
            return weatherService;
        }
    }

    public class MockWeatherApi : IWeatherApi
    {
        private bool isNull;
        private string country;
        private string city;

        public MockWeatherApi(bool isNull, string country, string city)
        {
            this.isNull = isNull;
            this.country = country;
            this.city = city;
        }

        public Task<RootData> GetWeatherAsync([RawQueryString] string query)
        {
            return MockData.MockRoot(isNull, country, city);
        }

        public Task<RootData> GetWeatherAsync([Query] string country, [Query] string city)
        {
            return MockData.MockRoot(isNull, country, city);
        }
    }
}