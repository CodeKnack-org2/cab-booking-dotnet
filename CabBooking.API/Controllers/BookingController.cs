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
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetById(Guid id)
        {
            var booking = await _bookingService.GetByIdAsync(id);
            if (booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetAll()
        {
            var bookings = await _bookingService.GetAllAsync();
            return Ok(bookings);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetUserBookings(Guid userId)
        {
            var bookings = await _bookingService.GetUserBookingsAsync(userId);
            return Ok(bookings);
        }

        [HttpPost]
        public async Task<ActionResult<Booking>> Create(Booking booking)
        {
            var createdBooking = await _bookingService.CreateAsync(booking);
            return CreatedAtAction(nameof(GetById), new { id = createdBooking.Id }, createdBooking);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Booking booking)
        {
            if (id != booking.Id)
                return BadRequest();
            var updatedBooking = await _bookingService.UpdateAsync(booking);
            if (updatedBooking == null)
                return NotFound();
            return Ok(updatedBooking);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _bookingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/cancel")]
        public async Task<IActionResult> CancelBooking(Guid id, [FromBody] CancelBookingDto dto)
        {
            var result = await _bookingService.CancelBookingAsync(id, dto.Reason);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpGet("estimate-fare")]
        public async Task<ActionResult<double>> EstimateFare([FromQuery] double pickupLat, [FromQuery] double pickupLng, [FromQuery] double dropoffLat, [FromQuery] double dropoffLng, [FromQuery] string cabType)
        {
            var fare = await _bookingService.EstimateFareAsync(pickupLat, pickupLng, dropoffLat, dropoffLng, cabType);
            return Ok(fare);
        }

        [HttpPost("{id}/track")]
        public async Task<IActionResult> TrackBooking(Guid id, [FromBody] LocationUpdateDto location)
        {
            var result = await _bookingService.TrackBookingAsync(id, location.Latitude, location.Longitude);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<IEnumerable<Booking>>> GetNearbyBookings([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double radius)
        {
            var bookings = await _bookingService.GetNearbyBookingsAsync(latitude, longitude, radius);
            return Ok(bookings);
        }
    }

    public class CancelBookingDto
    {
        public string Reason { get; set; }
    }
    public class LocationUpdateDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
} 