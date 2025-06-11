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
    public class CabTypeController : ControllerBase
    {
        private readonly ICabTypeService _cabTypeService;

        public CabTypeController(ICabTypeService cabTypeService)
        {
            _cabTypeService = cabTypeService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CabType>> GetById(Guid id)
        {
            var cabType = await _cabTypeService.GetByIdAsync(id);
            if (cabType == null)
                return NotFound();
            return Ok(cabType);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CabType>>> GetAll()
        {
            var cabTypes = await _cabTypeService.GetAllAsync();
            return Ok(cabTypes);
        }

        [HttpGet("available")]
        public async Task<ActionResult<IEnumerable<CabType>>> GetAvailableTypes()
        {
            var cabTypes = await _cabTypeService.GetAvailableTypesAsync();
            return Ok(cabTypes);
        }

        [HttpPost]
        public async Task<ActionResult<CabType>> Create(CabType cabType)
        {
            var createdCabType = await _cabTypeService.CreateAsync(cabType);
            return CreatedAtAction(nameof(GetById), new { id = createdCabType.Id }, createdCabType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, CabType cabType)
        {
            if (id != cabType.Id)
                return BadRequest();

            var updatedCabType = await _cabTypeService.UpdateAsync(cabType);
            if (updatedCabType == null)
                return NotFound();

            return Ok(updatedCabType);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await _cabTypeService.DeleteAsync(id);
                return NoContent();
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}/pricing")]
        public async Task<IActionResult> UpdatePricing(Guid id, [FromBody] PricingUpdateDto pricing)
        {
            var result = await _cabTypeService.UpdatePricingAsync(id, pricing.BasePrice, pricing.PricePerKm);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPut("{id}/availability")]
        public async Task<IActionResult> UpdateAvailability(Guid id, [FromBody] bool isAvailable)
        {
            var result = await _cabTypeService.UpdateAvailabilityAsync(id, isAvailable);
            if (!result)
                return NotFound();
            return Ok();
        }
    }

    public class PricingUpdateDto
    {
        public decimal BasePrice { get; set; }
        public decimal PricePerKm { get; set; }
    }
} 