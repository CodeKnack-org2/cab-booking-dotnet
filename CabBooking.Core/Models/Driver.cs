using System;
using System.Collections.Generic;
using CabBooking.Core.Enums;

namespace CabBooking.Core.Models
{
    public class Driver : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime LicenseExpiryDate { get; set; }
        public bool IsAvailable { get; set; }
        public double CurrentLatitude { get; set; }
        public double CurrentLongitude { get; set; }
        public double Rating { get; set; }
        public int TotalRides { get; set; }
        public virtual ICollection<Cab> Cabs { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
    }
} 