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
    public class CabController : ControllerBase
    {
        private readonly ICabService _cabService;

        public CabController(ICabService cabService)
        {
            _cabService = cabService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cab>> GetById(Guid id)
        {
            var cab = await _cabService.GetByIdAsync(id);
            if (cab == null)
                return NotFound();
            return Ok(cab);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cab>>> GetAll()
        {
            var cabs = await _cabService.GetAllAsync();
            return Ok(cabs);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<Cab>>> GetAvailableCabs()
        {
            var cabs = await _cabService.GetAvailableCabsAsync();
            return Ok(cabs);
        }

        [HttpPost]
        public async Task<ActionResult<Cab>> Create(Cab cab)
        {
            var createdCab = await _cabService.CreateAsync(cab);
            return CreatedAtAction(nameof(GetById), new { id = createdCab.Id }, createdCab);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Cab cab)
        {
            if (id != cab.Id)
                return BadRequest();

            var updatedCab = await _cabService.UpdateAsync(cab);
            if (updatedCab == null)
                return NotFound();

            return Ok(updatedCab);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _cabService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPut("{id}/availability")]
        public async Task<IActionResult> UpdateAvailability(Guid id, [FromBody] bool isAvailable)
        {
            var result = await _cabService.UpdateAvailabilityAsync(id, isAvailable);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("{id}/location")]
        public async Task<IActionResult> UpdateLocation(Guid id, [FromBody] LocationUpdateDto location)
        {
            var result = await _cabService.UpdateLocationAsync(id, location.Latitude, location.Longitude);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpGet("nearby")]
        public async Task<ActionResult<IEnumerable<Cab>>> GetNearbyCabs([FromQuery] double latitude, [FromQuery] double longitude, [FromQuery] double radius)
        {
            var cabs = await _cabService.GetNearbyCabsAsync(latitude, longitude, radius);
            return Ok(cabs);
        }

        [HttpPut("{id}/driver")]
        public async Task<IActionResult> AssignDriver(Guid id, [FromBody] Guid driverId)
        {
            var result = await _cabService.AssignDriverAsync(id, driverId);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpDelete("{id}/driver")]
        public async Task<IActionResult> RemoveDriver(Guid id)
        {
            var result = await _cabService.RemoveDriverAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }
    }

    public class LocationUpdateDto
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
} 