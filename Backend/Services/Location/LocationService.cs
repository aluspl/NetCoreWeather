using Backend.Services.Rest;
using RestEase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Location
{
    public class LocationService : ILocationService
    {
        private readonly ILocationApi Location;
        private const string MapApi = "http://maps.googleapis.com/maps/api/geocode/";

        public LocationService()
        {
            Location = RestClient.For<ILocationApi>(MapApi);
        }
        public async Task<Geometry> GetCoordinatesAsync(string city, string country)
        {
            var location = await Location.GetLocationAsync($"{city},{country}");
            if (location == null || !location.results.Any())
                throw new Exception("Invalid City");
            return location.results.FirstOrDefault().geometry;
        }
        public async Task<string> GetCoordinateString(string city, string country)
        {
            var coordinate = await GetCoordinatesAsync(city, country);

            return $"{coordinate.location?.lat},{coordinate.location?.lng}";
        }
    }
}
