using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class NotificationRepository : BaseRepository<Notification>, INotificationRepository
    {
        public async Task<IEnumerable<Notification>> GetUserNotificationsAsync(Guid userId)
        {
            return await Task.FromResult(_items.OfType<Notification>().Where(n => n.UserId == userId));
        }

        public async Task<bool> MarkAsReadAsync(Guid notificationId)
        {
            var notification = await GetByIdAsync(notificationId);
            if (notification != null)
            {
                notification.IsRead = true;
                await UpdateAsync(notification);
                return true;
            }
            return false;
        }

        public async Task<bool> MarkAllAsReadAsync(Guid userId)
        {
            var notifications = await GetUserNotificationsAsync(userId);
            foreach (var notification in notifications.Where(n => !n.IsRead))
            {
                notification.IsRead = true;
                await UpdateAsync(notification);
            }
            return true;
        }
    }
} 