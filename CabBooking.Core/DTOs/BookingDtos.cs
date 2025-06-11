using System;

namespace CabBooking.Core.DTOs
{
    public class BookingDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid? DriverId { get; set; }
        public Guid CabId { get; set; }
        public LocationDto PickupLocation { get; set; }
        public LocationDto DropoffLocation { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime? PickupTime { get; set; }
        public DateTime? DropoffTime { get; set; }
        public decimal Fare { get; set; }
        public BookingStatus Status { get; set; }
        public string PaymentStatus { get; set; }
    }

    public class CreateBookingDto
    {
        public Guid UserId { get; set; }
        public Guid CabTypeId { get; set; }
        public LocationDto PickupLocation { get; set; }
        public LocationDto DropoffLocation { get; set; }
        public DateTime BookingTime { get; set; }
    }

    public class UpdateBookingStatusDto
    {
        public BookingStatus Status { get; set; }
    }

    public class CancelBookingDto
    {
        public string Reason { get; set; }
    }

    public class FareEstimateDto
    {
        public decimal BasePrice { get; set; }
        public decimal PricePerKm { get; set; }
        public double Distance { get; set; }
        public decimal TotalFare { get; set; }
    }
} 