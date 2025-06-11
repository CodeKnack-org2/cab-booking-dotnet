using System;

namespace CabBooking.Core.DTOs
{
    public class NotificationDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
        public bool IsRead { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class CreateNotificationDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string Type { get; set; }
    }

    public class EmailNotificationDto
    {
        public string To { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }

    public class SmsNotificationDto
    {
        public string To { get; set; }
        public string Message { get; set; }
    }

    public class PushNotificationDto
    {
        public string DeviceToken { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public object Data { get; set; }
    }
} 