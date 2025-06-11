using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class CabRepository : BaseRepository<Cab>, ICabRepository
    {
        public async Task<IEnumerable<Cab>> GetAvailableCabsAsync()
        {
            return await Task.FromResult(_items.OfType<Cab>().Where(c => c.IsAvailable));
        }

        public async Task<bool> UpdateAvailabilityAsync(Guid cabId, bool isAvailable)
        {
            var cab = await GetByIdAsync(cabId);
            if (cab != null)
            {
                cab.IsAvailable = isAvailable;
                await UpdateAsync(cab);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateLocationAsync(Guid cabId, double latitude, double longitude)
        {
            var cab = await GetByIdAsync(cabId);
            if (cab != null)
            {
                cab.CurrentLocation = new Location { Latitude = latitude, Longitude = longitude };
                await UpdateAsync(cab);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<Cab>> GetNearbyCabsAsync(double latitude, double longitude, double radius)
        {
            return await Task.FromResult(_items.OfType<Cab>()
                .Where(c => CalculateDistance(
                    c.CurrentLocation.Latitude,
                    c.CurrentLocation.Longitude,
                    latitude,
                    longitude) <= radius));
        }

        public async Task<bool> AssignDriverAsync(Guid cabId, Guid driverId)
        {
            var cab = await GetByIdAsync(cabId);
            if (cab != null)
            {
                cab.DriverId = driverId;
                await UpdateAsync(cab);
                return true;
            }
            return false;
        }

        public async Task<bool> RemoveDriverAsync(Guid cabId)
        {
            var cab = await GetByIdAsync(cabId);
            if (cab != null)
            {
                cab.DriverId = null;
                await UpdateAsync(cab);
                return true;
            }
            return false;
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            // Simple Euclidean distance for demonstration
            // In production, use proper geospatial calculations
            return Math.Sqrt(Math.Pow(lat2 - lat1, 2) + Math.Pow(lon2 - lon1, 2));
        }
    }
} 