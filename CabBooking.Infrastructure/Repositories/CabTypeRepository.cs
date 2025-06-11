using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class CabTypeRepository : BaseRepository<CabType>, ICabTypeRepository
    {
        public async Task<bool> UpdatePricingAsync(Guid cabTypeId, decimal basePrice, decimal pricePerKm)
        {
            var cabType = await GetByIdAsync(cabTypeId);
            if (cabType != null)
            {
                cabType.BasePrice = basePrice;
                cabType.PricePerKm = pricePerKm;
                await UpdateAsync(cabType);
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateAvailabilityAsync(Guid cabTypeId, bool isAvailable)
        {
            var cabType = await GetByIdAsync(cabTypeId);
            if (cabType != null)
            {
                cabType.IsAvailable = isAvailable;
                await UpdateAsync(cabType);
                return true;
            }
            return false;
        }

        public async Task<IEnumerable<CabType>> GetAvailableCabTypesAsync()
        {
            return await Task.FromResult(_items.OfType<CabType>().Where(ct => ct.IsAvailable));
        }
    }
} 