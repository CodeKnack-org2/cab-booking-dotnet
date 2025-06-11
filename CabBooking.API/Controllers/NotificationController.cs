using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;
using CabBooking.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CabBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificationController : ControllerBase
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Notification>> GetById(Guid id)
        {
            var notification = await _notificationService.GetByIdAsync(id);
            if (notification == null)
                return NotFound();
            return Ok(notification);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Notification>>> GetAll()
        {
            var notifications = await _notificationService.GetAllAsync();
            return Ok(notifications);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Notification>>> GetUserNotifications(Guid userId)
        {
            var notifications = await _notificationService.GetUserNotificationsAsync(userId);
            return Ok(notifications);
        }

        [HttpPost]
        public async Task<ActionResult<Notification>> Create(Notification notification)
        {
            var createdNotification = await _notificationService.CreateAsync(notification);
            return CreatedAtAction(nameof(GetById), new { id = createdNotification.Id }, createdNotification);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Notification notification)
        {
            if (id != notification.Id)
                return BadRequest();
            var updatedNotification = await _notificationService.UpdateAsync(notification);
            if (updatedNotification == null)
                return NotFound();
            return Ok(updatedNotification);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _notificationService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/mark-as-read")]
        public async Task<IActionResult> MarkAsRead(Guid id)
        {
            var result = await _notificationService.MarkAsReadAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPost("user/{userId}/mark-all-as-read")]
        public async Task<IActionResult> MarkAllAsRead(Guid userId)
        {
            var result = await _notificationService.MarkAllAsReadAsync(userId);
            if (!result)
                return NotFound();
            return Ok();
        }
    }
} 