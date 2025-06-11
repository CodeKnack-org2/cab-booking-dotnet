using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.DTOs;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Services
{
    public class LocationService : ILocationService
    {
        private readonly ILocationRepository _locationRepository;
        private readonly ICabRepository _cabRepository;
        private readonly IBookingRepository _bookingRepository;

        public LocationService(
            ILocationRepository locationRepository,
            ICabRepository cabRepository,
            IBookingRepository bookingRepository)
        {
            _locationRepository = locationRepository;
            _cabRepository = cabRepository;
            _bookingRepository = bookingRepository;
        }

        public async Task<Location> GetByIdAsync(Guid id)
        {
            return await _locationRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Location>> GetAllAsync()
        {
            return await _locationRepository.GetAllAsync();
        }

        public async Task<Location> CreateAsync(Location location)
        {
            // In a real application, you would:
            // 1. Validate coordinates
            // 2. Check for duplicate locations
            // 3. Validate address format
            return await _locationRepository.CreateAsync(location);
        }

        public async Task<Location> UpdateAsync(Location location)
        {
            return await _locationRepository.UpdateAsync(location);
        }

        public async Task DeleteAsync(Guid id)
        {
            // Check if location is used in any bookings
            var bookings = await _bookingRepository.GetByLocationAsync(id);
            if (bookings.Any())
            {
                throw new InvalidOperationException("Cannot delete location that is used in existing bookings.");
            }

            await _locationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Location>> GetNearbyLocationsAsync(double latitude, double longitude, double radius)
        {
            return await _locationRepository.GetNearbyLocationsAsync(latitude, longitude, radius);
        }

        public async Task<double> CalculateDistanceAsync(Guid location1Id, Guid location2Id)
        {
            var location1 = await _locationRepository.GetByIdAsync(location1Id);
            var location2 = await _locationRepository.GetByIdAsync(location2Id);

            if (location1 == null || location2 == null)
            {
                throw new ArgumentException("One or both locations not found.");
            }

            return CalculateDistance(
                location1.Latitude, location1.Longitude,
                location2.Latitude, location2.Longitude);
        }

        public async Task<IEnumerable<Location>> GetPopularLocationsAsync(int count)
        {
            return await _locationRepository.GetPopularLocationsAsync(count);
        }

        private double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double EarthRadiusKm = 6371;

            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return EarthRadiusKm * c;
        }

        private double ToRadians(double degrees)
        {
            return degrees * Math.PI / 180;
        }
    }
} 