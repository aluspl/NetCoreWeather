namespace Backend.Services.Weather
{
    public class Weather
    {
        public Location location { get; set; }
        public Temperature temperature { get; set; }
        public int Humidity { get; set; }
    }
}