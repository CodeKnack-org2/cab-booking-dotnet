using System;
using System.Collections.Generic;
using CabBooking.Core.Enums;

namespace CabBooking.Core.Models
{
    public class User : BaseEntity
    {
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public UserRole Role { get; set; }
        public bool IsEmailVerified { get; set; }
        public bool IsPhoneVerified { get; set; }
        public string ProfilePictureUrl { get; set; }
        public double Rating { get; set; }
        public int TotalRides { get; set; }
        public virtual ICollection<Booking> Bookings { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
} 