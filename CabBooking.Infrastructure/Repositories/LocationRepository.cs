using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class LocationRepository : BaseRepository<Location>, ILocationRepository
    {
        public async Task<IEnumerable<Location>> GetUserLocationsAsync(Guid userId)
        {
            return await Task.FromResult(_items.OfType<Location>().Where(l => l.UserId == userId));
        }

        public async Task<IEnumerable<Location>> GetNearbyLocationsAsync(double latitude, double longitude, double radius)
        {
            return await Task.FromResult(_items.OfType<Location>()
                .Where(l => CalculateDistance(
                    l.Latitude,
                    l.Longitude,
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