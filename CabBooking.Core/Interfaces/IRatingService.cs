using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IRatingService
    {
        Task<Rating> GetByIdAsync(Guid id);
        Task<IEnumerable<Rating>> GetAllAsync();
        Task<IEnumerable<Rating>> GetUserRatingsAsync(Guid userId);
        Task<IEnumerable<Rating>> GetDriverRatingsAsync(Guid driverId);
        Task<Rating> CreateAsync(Rating rating);
        Task<Rating> UpdateAsync(Rating rating);
        Task DeleteAsync(Guid id);
        Task<double> GetAverageDriverRatingAsync(Guid driverId);
        Task<double> GetAverageUserRatingAsync(Guid userId);
        Task<bool> HasUserRatedBookingAsync(Guid userId, Guid bookingId);
    }
} 