using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface INotificationRepository
    {
        Task<Notification> GetByIdAsync(Guid id);
        Task<IEnumerable<Notification>> GetAllAsync();
        Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId);
        Task<Notification> CreateAsync(Notification notification);
        Task<Notification> UpdateAsync(Notification notification);
        Task DeleteAsync(Guid id);
        Task<bool> MarkAsReadAsync(Guid notificationId);
        Task<bool> MarkAllAsReadAsync(Guid userId);
    }
} 