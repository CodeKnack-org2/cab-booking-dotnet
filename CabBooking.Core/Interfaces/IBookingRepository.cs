using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IBookingRepository
    {
        Task<Booking> GetByIdAsync(Guid id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking> UpdateAsync(Booking booking);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Booking>> GetNearbyBookingsAsync(double latitude, double longitude, double radius);
    }
} 