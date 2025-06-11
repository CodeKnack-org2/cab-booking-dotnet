using System;

namespace CabBooking.Core.DTOs
{
    public class CabDto
    {
        public Guid Id { get; set; }
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Guid CabTypeId { get; set; }
        public Guid? DriverId { get; set; }
        public bool IsAvailable { get; set; }
        public LocationDto CurrentLocation { get; set; }
    }

    public class CreateCabDto
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public Guid CabTypeId { get; set; }
    }

    public class UpdateCabDto
    {
        public string RegistrationNumber { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
    }

    public class UpdateCabLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class UpdateCabAvailabilityDto
    {
        public bool IsAvailable { get; set; }
    }

    public class AssignDriverDto
    {
        public Guid DriverId { get; set; }
    }
} 