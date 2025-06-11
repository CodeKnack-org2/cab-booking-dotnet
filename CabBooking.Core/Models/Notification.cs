using System;

namespace CabBooking.Core.Models
{
    public class Notification : BaseEntity
    {
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime? ReadAt { get; set; }
        public string Data { get; set; }
    }
} 