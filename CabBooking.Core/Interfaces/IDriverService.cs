using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IDriverService
    {
        Task<Driver> GetByIdAsync(Guid id);
        Task<IEnumerable<Driver>> GetAllAsync();
        Task<IEnumerable<Driver>> GetAvailableDriversAsync();
        Task<Driver> CreateAsync(Driver driver);
        Task<Driver> UpdateAsync(Driver driver);
        Task DeleteAsync(Guid id);
        Task<bool> UpdateAvailabilityAsync(Guid driverId, bool isAvailable);
        Task<bool> UpdateLocationAsync(Guid driverId, double latitude, double longitude);
        Task<IEnumerable<Booking>> GetDriverBookingsAsync(Guid driverId);
        Task<bool> AcceptBookingAsync(Guid driverId, Guid bookingId);
        Task<bool> RejectBookingAsync(Guid driverId, Guid bookingId);
        Task<bool> CompleteBookingAsync(Guid driverId, Guid bookingId);
    }
} 