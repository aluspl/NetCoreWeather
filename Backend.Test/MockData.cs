using Backend.Services.Weather;
using NSubstitute;
using RestEase;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Backend.Test
{
    public class MockData
    {


        public static Task<RootData> MockRoot(bool NullData, string country, string city)
        {
            return new Task<RootData>(() => CreatedMockRoot(NullData, country, city));
        }
      

        public static RootData CreatedMockRoot(bool NullData, string country, string city)
        {
            return new RootData
            {
                query = new Query
                {
                    results =NullData? null:  new Results
                    {
                        channel = new Channel
                        {
                            atmosphere = NullData ? null : new Atmosphere { humidity = 66 },
                            item = NullData ? null : new Item { condition = new Condition { }, forecast = new Forecast[] { new Forecast { low = 0 } } },
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
    public class TodoTheoryData<T> : TheoryData<T>
    {
        public TodoTheoryData(IEnumerable<T> data)
        {
            foreach (T t1 in data)
            {
                Add(t1);
            }
        }
    }
    public class FToCTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { 50, 10};
            yield return new object[] { 45, 7};
            yield return new object[] { 40, 4};
            yield return new object[] { 35, 1};
            yield return new object[] { 30, -1 };
            yield return new object[] { 25, -3 };
            yield return new object[] { 20, -6 };
            yield return new object[] { 15, -9 };
            yield return new object[] { 10, -12 };
            yield return new object[] { 5, -15 };
            yield return new object[] { 0, -17 };

        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}