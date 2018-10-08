using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.Services.Location
{
    public interface ILocationService
    {
        Task<Geometry> GetCoordinatesAsync(string city, string country);
        Task<string> GetCoordinateString(string city, string country);
    }
}
