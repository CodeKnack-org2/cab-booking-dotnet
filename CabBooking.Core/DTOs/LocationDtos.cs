using System;

namespace CabBooking.Core.DTOs
{
    public class LocationDto
    {
        public Guid Id { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public Guid? UserId { get; set; }
    }

    public class CreateLocationDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
        public Guid? UserId { get; set; }
    }

    public class UpdateLocationDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }

    public class CoordinatesDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }

    public class AddressDto
    {
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string PostalCode { get; set; }
    }
} 