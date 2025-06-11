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
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetById(Guid id)
        {
            var payment = await _paymentService.GetByIdAsync(id);
            if (payment == null)
                return NotFound();
            return Ok(payment);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetAll()
        {
            var payments = await _paymentService.GetAllAsync();
            return Ok(payments);
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<IEnumerable<Payment>>> GetUserPayments(Guid userId)
        {
            var payments = await _paymentService.GetUserPaymentsAsync(userId);
            return Ok(payments);
        }

        [HttpPost]
        public async Task<ActionResult<Payment>> Create(Payment payment)
        {
            var createdPayment = await _paymentService.CreateAsync(payment);
            return CreatedAtAction(nameof(GetById), new { id = createdPayment.Id }, createdPayment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Payment payment)
        {
            if (id != payment.Id)
                return BadRequest();

            var updatedPayment = await _paymentService.UpdateAsync(payment);
            if (updatedPayment == null)
                return NotFound();

            return Ok(updatedPayment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _paymentService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("{id}/process")]
        public async Task<IActionResult> ProcessPayment(Guid id)
        {
            var result = await _paymentService.ProcessPaymentAsync(id);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPost("{id}/refund")]
        public async Task<IActionResult> RefundPayment(Guid id, [FromBody] RefundRequestDto request)
        {
            var result = await _paymentService.RefundPaymentAsync(id, request.Reason);
            if (!result)
                return NotFound();
            return Ok();
        }

        [HttpPost("token")]
        public async Task<ActionResult<string>> GeneratePaymentToken([FromBody] PaymentTokenRequestDto request)
        {
            var token = await _paymentService.GeneratePaymentTokenAsync(
                request.CardNumber,
                request.ExpiryMonth,
                request.ExpiryYear,
                request.Cvv);
            return Ok(token);
        }

        [HttpPost("validate")]
        public async Task<ActionResult<bool>> ValidatePayment([FromBody] string paymentToken)
        {
            var isValid = await _paymentService.ValidatePaymentAsync(paymentToken);
            return Ok(isValid);
        }
    }

    public class RefundRequestDto
    {
        public string Reason { get; set; }
    }

    public class PaymentTokenRequestDto
    {
        public string CardNumber { get; set; }
        public string ExpiryMonth { get; set; }
        public string ExpiryYear { get; set; }
        public string Cvv { get; set; }
    }
} 