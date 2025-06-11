using System;
using CabBooking.Core.Enums;

namespace CabBooking.Core.Models
{
    public class Payment : BaseEntity
    {
        public Guid BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public double Amount { get; set; }
        public string Currency { get; set; }
        public string PaymentMethod { get; set; }
        public string TransactionId { get; set; }
        public PaymentStatus Status { get; set; }
        public DateTime? PaidAt { get; set; }
        public string FailureReason { get; set; }
    }
} 