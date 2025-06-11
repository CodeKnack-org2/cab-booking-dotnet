using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface ICabTypeService
    {
        Task<CabType> GetByIdAsync(Guid id);
        Task<IEnumerable<CabType>> GetAllAsync();
        Task<CabType> CreateAsync(CabType cabType);
        Task<CabType> UpdateAsync(CabType cabType);
        Task DeleteAsync(Guid id);
        Task<bool> UpdatePricingAsync(Guid cabTypeId, decimal basePrice, decimal pricePerKm);
        Task<bool> UpdateAvailabilityAsync(Guid cabTypeId, bool isAvailable);
        Task<IEnumerable<CabType>> GetAvailableCabTypesAsync();
    }
} 