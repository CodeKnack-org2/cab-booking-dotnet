using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface ILocationService
    {
        Task<Location> GetByIdAsync(Guid id);
        Task<IEnumerable<Location>> GetAllAsync();
        Task<IEnumerable<Location>> GetUserLocationsAsync(Guid userId);
        Task<Location> CreateAsync(Location location);
        Task<Location> UpdateAsync(Location location);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Location>> GetNearbyLocationsAsync(double latitude, double longitude, double radius);
        Task<double> CalculateDistanceAsync(double startLat, double startLng, double endLat, double endLng);
        Task<string> GetAddressFromCoordinatesAsync(double latitude, double longitude);
        Task<(double Latitude, double Longitude)> GetCoordinatesFromAddressAsync(string address);
    }
} 