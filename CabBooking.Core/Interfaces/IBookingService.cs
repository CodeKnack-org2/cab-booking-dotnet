using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IBookingService
    {
        Task<Booking> GetByIdAsync(Guid id);
        Task<IEnumerable<Booking>> GetAllAsync();
        Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId);
        Task<Booking> CreateAsync(Booking booking);
        Task<Booking> UpdateAsync(Booking booking);
        Task DeleteAsync(Guid id);
        Task<bool> CancelBookingAsync(Guid bookingId, string reason);
        Task<double> EstimateFareAsync(double pickupLat, double pickupLng, double dropoffLat, double dropoffLng, string cabType);
        Task<bool> TrackBookingAsync(Guid bookingId, double latitude, double longitude);
        Task<IEnumerable<Booking>> GetNearbyBookingsAsync(double latitude, double longitude, double radius);
    }
} 