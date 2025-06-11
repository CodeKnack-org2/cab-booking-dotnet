using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface ILocationRepository
    {
        Task<Location> GetByIdAsync(Guid id);
        Task<IEnumerable<Location>> GetAllAsync();
        Task<IEnumerable<Location>> GetUserLocationsAsync(Guid userId);
        Task<Location> CreateAsync(Location location);
        Task<Location> UpdateAsync(Location location);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Location>> GetNearbyLocationsAsync(double latitude, double longitude, double radius);
    }
} 