using Backend.Services.Weather;
using Xunit;

namespace Backend.Test
{
    public class WeatherConventerTest
    {
        private static Item[] Items = new Item[]
        {
                new Item { title = "Weather Item", forecast = new Forecast[] { new Forecast { high=50, low=40 }, new Forecast { high = 40, low = 30 } } },
                new Item { title = "Weather Item2", forecast = new Forecast[] { new Forecast { high=50, low=40 }, new Forecast { high = 40, low = 30 } } }
        };
        private static RootData[] RootDatas = new RootData[]
        {

            MockData.CreatedMockRoot(false, "Poland","Gdansk"),
            MockData.CreatedMockRoot(false, "Poland","Wroclaw"),
            MockData.CreatedMockRoot(false, "Poland","Rzeszow"),
        };
        private static RootData[] RootDatasWithNull = new RootData[]
        {
              MockData.CreatedMockRoot(true, null,null),
              MockData.CreatedMockRoot(true, "Poland","Gdansk"),
              MockData.CreatedMockRoot(true, "Poland","Wroclaw"),
              MockData.CreatedMockRoot(true, "Poland","Rzeszow"),

        };
        public static TodoTheoryData<Item> ItemsData { get; } = new TodoTheoryData<Item>(Items);
        public static TodoTheoryData<RootData> RootObjectItems { get; } = new TodoTheoryData<RootData>(RootDatas);
        public static TodoTheoryData<RootData> RootObjectItemsWithNull { get; } = new TodoTheoryData<RootData>(RootDatasWithNull);

        [Theory]
        [InlineData(50, 10)]
        [InlineData(45, 7)]
        [InlineData(40, 4)]
        [InlineData(35, 1)]
        public void FahrenheitToCelciusTest(double f, double expected)
        {
            Assert.Equal(expected, (int)Weather.ToCelcius(f));
        }
        [Theory]
        [ClassData(typeof(FToCTestData))]    
        public void FahrenheitToCelciusTestOnClassData(double f, double expected)
        {
            Assert.Equal(expected, (int)Weather.ToCelcius(f));
        }
        [Theory]
        [MemberData(nameof(ItemsData))]
        public void ItemToTemperature(Item f)
        {
            Assert.NotNull(Weather.GetTemperature(f));
        }
        [Theory]
        [MemberData(nameof(RootObjectItems))]
        public void QueryToWeather(RootData f)
        {
            Assert.NotNull(Weather.Get(f));
        }
        [Theory]
        [MemberData(nameof(RootObjectItemsWithNull))]
        public void QueryToWeatherThrows(RootData f)
        {
            Assert.Throws<ConvertException>(() => Weather.Get(f));
        }

    }
}
