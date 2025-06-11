using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.DTOs;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly INotificationService _notificationService;

        public DriverService(
            IDriverRepository driverRepository,
            IBookingRepository bookingRepository,
            INotificationService notificationService)
        {
            _driverRepository = driverRepository;
            _bookingRepository = bookingRepository;
            _notificationService = notificationService;
        }

        public async Task<Driver> GetByIdAsync(Guid id)
        {
            return await _driverRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Driver>> GetAllAsync()
        {
            return await _driverRepository.GetAllAsync();
        }

        public async Task<IEnumerable<Driver>> GetAvailableDriversAsync()
        {
            return await _driverRepository.GetAvailableDriversAsync();
        }

        public async Task<Driver> CreateAsync(Driver driver)
        {
            // In a real application, you would:
            // 1. Validate driver information
            // 2. Check license validity
            // 3. Send welcome notification
            return await _driverRepository.CreateAsync(driver);
        }

        public async Task<Driver> UpdateAsync(Driver driver)
        {
            return await _driverRepository.UpdateAsync(driver);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _driverRepository.DeleteAsync(id);
        }

        public async Task<bool> UpdateAvailabilityAsync(Guid driverId, bool isAvailable)
        {
            return await _driverRepository.UpdateAvailabilityAsync(driverId, isAvailable);
        }

        public async Task<bool> UpdateLocationAsync(Guid driverId, double latitude, double longitude)
        {
            return await _driverRepository.UpdateLocationAsync(driverId, latitude, longitude);
        }

        public async Task<IEnumerable<Booking>> GetDriverBookingsAsync(Guid driverId)
        {
            var bookings = await _bookingRepository.GetAllAsync();
            return bookings.Where(b => b.DriverId == driverId);
        }

        public async Task<bool> AcceptBookingAsync(Guid driverId, Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null || booking.DriverId != driverId) return false;

            booking.Status = BookingStatus.Accepted;
            await _bookingRepository.UpdateAsync(booking);

            // Notify user about booking acceptance
            await _notificationService.CreateAsync(new Notification
            {
                UserId = booking.UserId,
                Title = "Booking Accepted",
                Message = "Your booking has been accepted by the driver.",
                Type = "BookingUpdate"
            });

            return true;
        }

        public async Task<bool> RejectBookingAsync(Guid driverId, Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null || booking.DriverId != driverId) return false;

            booking.Status = BookingStatus.Rejected;
            await _bookingRepository.UpdateAsync(booking);

            // Notify user about booking rejection
            await _notificationService.CreateAsync(new Notification
            {
                UserId = booking.UserId,
                Title = "Booking Rejected",
                Message = "Your booking has been rejected by the driver.",
                Type = "BookingUpdate"
            });

            return true;
        }

        public async Task<bool> CompleteBookingAsync(Guid driverId, Guid bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking == null || booking.DriverId != driverId) return false;

            booking.Status = BookingStatus.Completed;
            booking.DropoffTime = DateTime.UtcNow;
            await _bookingRepository.UpdateAsync(booking);

            // Notify user about booking completion
            await _notificationService.CreateAsync(new Notification
            {
                UserId = booking.UserId,
                Title = "Trip Completed",
                Message = "Your trip has been completed. Please rate your experience.",
                Type = "BookingUpdate"
            });

            return true;
        }
    }
} 