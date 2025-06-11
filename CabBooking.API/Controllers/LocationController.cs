using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.DTOs;
using CabBooking.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CabBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Location>> GetById(Guid id)
        {
            var location = await _locationService.GetByIdAsync(id);
            if (location == null)
                return NotFound();
            return Ok(location);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Location>>> GetAll()
        {
            var locations = await _locationService.GetAllAsync();
            return Ok(locations);
        }

        [HttpPost]
        public async Task<ActionResult<Location>> Create(Location location)
        {
            var createdLocation = await _locationService.CreateAsync(location);
            return CreatedAtAction(nameof(GetById), new { id = createdLocation.Id }, createdLocation);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Location location)
        {
            if (id != location.Id)
                return BadRequest();

            var updatedLocation = await _locationService.UpdateAsync(location);
            if (updatedLocation == null)
                return NotFound();

            return Ok(updatedLocation);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _locationService.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<IEnumerable<Location>>> GetNearbyLocations(
            [FromQuery] double latitude,
            [FromQuery] double longitude,
            [FromQuery] double radius)
        {
            var locations = await _locationService.GetNearbyLocationsAsync(latitude, longitude, radius);
            return Ok(locations);
        }

        [HttpGet("distance")]
        public async Task<ActionResult<double>> CalculateDistance(
            [FromQuery] Guid location1Id,
            [FromQuery] Guid location2Id)
        {
            try
            {
                var distance = await _locationService.CalculateDistanceAsync(location1Id, location2Id);
                return Ok(distance);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("popular")]
        public async Task<ActionResult<IEnumerable<Location>>> GetPopularLocations([FromQuery] int count = 10)
        {
            var locations = await _locationService.GetPopularLocationsAsync(count);
            return Ok(locations);
        }
    }
} 