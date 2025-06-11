using System;

namespace CabBooking.Core.DTOs
{
    public class CabTypeDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal PricePerKm { get; set; }
        public int Capacity { get; set; }
        public bool IsAvailable { get; set; }
    }

    public class CreateCabTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal BasePrice { get; set; }
        public decimal PricePerKm { get; set; }
        public int Capacity { get; set; }
    }

    public class UpdateCabTypeDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int Capacity { get; set; }
    }

    public class UpdateCabTypePricingDto
    {
        public decimal BasePrice { get; set; }
        public decimal PricePerKm { get; set; }
    }

    public class UpdateCabTypeAvailabilityDto
    {
        public bool IsAvailable { get; set; }
    }
} 