using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public async Task<IEnumerable<Booking>> GetUserBookingsAsync(Guid userId)
        {
            return await Task.FromResult(_items.OfType<Booking>().Where(b => b.UserId == userId));
        }

        public async Task<IEnumerable<Booking>> GetNearbyBookingsAsync(double latitude, double longitude, double radius)
        {
            return await Task.FromResult(_items.OfType<Booking>()
                .Where(b => CalculateDistance(
                    b.PickupLocation.Latitude,
                    b.PickupLocation.Longitude,
                    latitude,
                    longitude) <= radius));
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Simple Euclidean distance for demonstration
            // In production, use proper geospatial calculations
            return Math.Sqrt(Math.Pow(lat2 - lat1, 2) + Math.Pow(lon2 - lon1, 2));
        }
    }
} 