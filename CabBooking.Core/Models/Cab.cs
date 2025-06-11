using System;
using CabBooking.Core.Enums;

namespace CabBooking.Core.Models
{
    public class Cab : BaseEntity
    {
        public Guid DriverId { get; set; }
        public virtual Driver Driver { get; set; }
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Color { get; set; }
        public CabType Type { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
        public double BaseFare { get; set; }
        public double PerKmRate { get; set; }
        public double PerMinuteRate { get; set; }
    }
} 