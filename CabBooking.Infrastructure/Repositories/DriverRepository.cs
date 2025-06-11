using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class DriverRepository : BaseRepository<Driver>, IDriverRepository
    {
        public async Task<IEnumerable<Driver>> GetAvailableDriversAsync()
        {
            return await Task.FromResult(_items.OfType<Driver>().Where(d => d.IsAvailable));
        }

        public async Task<bool> UpdateAvailabilityAsync(Guid driverId, bool isAvailable)
        {
            var driver = await GetByIdAsync(driverId);
            if (driver != null)
            {
                driver.IsAvailable = isAvailable;
                await UpdateAsync(driver);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateLocationAsync(Guid driverId, double latitude, double longitude)
        {
            var driver = await GetByIdAsync(driverId);
            if (driver != null)
            {
                driver.CurrentLocation = new Location { Latitude = latitude, Longitude = longitude };
                await UpdateAsync(driver);
                return true;
            }
            return false;
        }
    }
} 