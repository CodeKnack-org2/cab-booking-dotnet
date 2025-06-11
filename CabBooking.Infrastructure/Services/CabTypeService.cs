using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.DTOs;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Services
{
    public class CabTypeService : ICabTypeService
    {
        private readonly ICabTypeRepository _cabTypeRepository;
        private readonly ICabRepository _cabRepository;

        public CabTypeService(
            ICabTypeRepository cabTypeRepository,
            ICabRepository cabRepository)
        {
            _cabTypeRepository = cabTypeRepository;
            _cabRepository = cabRepository;
        }

        public async Task<CabType> GetByIdAsync(Guid id)
        {
            return await _cabTypeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<CabType>> GetAllAsync()
        {
            return await _cabTypeRepository.GetAllAsync();
        }

        public async Task<CabType> CreateAsync(CabType cabType)
        {
            // In a real application, you would:
            // 1. Validate cab type details
            // 2. Check for duplicate type names
            // 3. Validate pricing structure
            return await _cabTypeRepository.CreateAsync(cabType);
        }

        public async Task<CabType> UpdateAsync(CabType cabType)
        {
            // In a real application, you would:
            // 1. Validate the update
            // 2. Check if the update affects existing cabs
            // 3. Handle price changes appropriately
            return await _cabTypeRepository.UpdateAsync(cabType);
        }

        public async Task DeleteAsync(Guid id)
        {
            // Check if there are any cabs of this type
            var cabs = await _cabRepository.GetByTypeAsync(id);
            if (cabs.Any())
            {
                throw new InvalidOperationException("Cannot delete cab type that is in use by existing cabs.");
            }

            await _cabTypeRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<CabType>> GetAvailableTypesAsync()
        {
            return await _cabTypeRepository.GetAvailableTypesAsync();
        }

        public async Task<bool> UpdatePricingAsync(Guid id, decimal basePrice, decimal pricePerKm)
        {
            var cabType = await _cabTypeRepository.GetByIdAsync(id);
            if (cabType == null)
            {
                return false;
            }

            cabType.BasePrice = basePrice;
            cabType.PricePerKm = pricePerKm;
            
            await _cabTypeRepository.UpdateAsync(cabType);
            return true;
        }

        public async Task<bool> UpdateAvailabilityAsync(Guid id, bool isAvailable)
        {
            return await _cabTypeRepository.UpdateAvailabilityAsync(id, isAvailable);
        }
    }
} 