namespace Backend.Services.Weather
{
    public interface IWeatherService
    {
        Weather Get(string country, string city);
    }
}