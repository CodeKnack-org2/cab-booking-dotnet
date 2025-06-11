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
    public class RatingController : ControllerBase
    {
        private readonly IRatingService _ratingService;

        public RatingController(IRatingService ratingService)
        {
            _ratingService = ratingService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Rating>> GetById(Guid id)
        {
            var rating = await _ratingService.GetByIdAsync(id);
            if (rating == null)
                return NotFound();
            return Ok(rating);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rating>>> GetAll()
        {
            var ratings = await _ratingService.GetAllAsync();
            return Ok(ratings);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetUserRatings(Guid userId)
        {
            var ratings = await _ratingService.GetUserRatingsAsync(userId);
            return Ok(ratings);
        }

        [HttpGet("driver/{driverId}")]
        public async Task<ActionResult<IEnumerable<Rating>>> GetDriverRatings(Guid driverId)
        {
            var ratings = await _ratingService.GetDriverRatingsAsync(driverId);
            return Ok(ratings);
        }

        [HttpPost]
        public async Task<ActionResult<Rating>> Create(Rating rating)
        {
            var createdRating = await _ratingService.CreateAsync(rating);
            return CreatedAtAction(nameof(GetById), new { id = createdRating.Id }, createdRating);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Rating rating)
        {
            if (id != rating.Id)
                return BadRequest();
            var updatedRating = await _ratingService.UpdateAsync(rating);
            if (updatedRating == null)
                return NotFound();
            return Ok(updatedRating);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _ratingService.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("driver/{driverId}/average")]
        public async Task<ActionResult<double>> GetAverageDriverRating(Guid driverId)
        {
            var avg = await _ratingService.GetAverageDriverRatingAsync(driverId);
            return Ok(avg);
        }

        [HttpGet("user/{userId}/average")]
        public async Task<ActionResult<double>> GetAverageUserRating(Guid userId)
        {
            var avg = await _ratingService.GetAverageUserRatingAsync(userId);
            return Ok(avg);
        }

        [HttpGet("user/{userId}/booking/{bookingId}/has-rated")]
        public async Task<ActionResult<bool>> HasUserRatedBooking(Guid userId, Guid bookingId)
        {
            var hasRated = await _ratingService.HasUserRatedBookingAsync(userId, bookingId);
            return Ok(hasRated);
        }
    }
} 