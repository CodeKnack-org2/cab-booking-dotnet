using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface ICabService
    {
        Task<Cab> GetByIdAsync(Guid id);
        Task<IEnumerable<Cab>> GetAllAsync();
        Task<IEnumerable<Cab>> GetAvailableCabsAsync();
        Task<Cab> CreateAsync(Cab cab);
        Task<Cab> UpdateAsync(Cab cab);
        Task DeleteAsync(Guid id);
        Task<bool> UpdateAvailabilityAsync(Guid cabId, bool isAvailable);
        Task<bool> UpdateLocationAsync(Guid cabId, double latitude, double longitude);
        Task<IEnumerable<Cab>> GetNearbyCabsAsync(double latitude, double longitude, double radius);
        Task<bool> AssignDriverAsync(Guid cabId, Guid driverId);
        Task<bool> RemoveDriverAsync(Guid cabId);
    }
} 