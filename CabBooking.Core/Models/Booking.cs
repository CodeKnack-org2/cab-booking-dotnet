using System;
using CabBooking.Core.Enums;

namespace CabBooking.Core.Models
{
    public class Booking : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public Guid? DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public Guid? CabId { get; set; }
        public virtual Cab Cab { get; set; }
        public double PickupLatitude { get; set; }
        public double PickupLongitude { get; set; }
        public string PickupAddress { get; set; }
        public double DropoffLatitude { get; set; }
        public double DropoffLongitude { get; set; }
        public string DropoffAddress { get; set; }
        public DateTime ScheduledTime { get; set; }
        public DateTime? ActualPickupTime { get; set; }
        public DateTime? ActualDropoffTime { get; set; }
        public double Distance { get; set; }
        public double Duration { get; set; }
        public double Fare { get; set; }
        public BookingStatus Status { get; set; }
        public string CancellationReason { get; set; }
        public virtual Payment Payment { get; set; }
    }
} 