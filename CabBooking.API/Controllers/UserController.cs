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
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetById(Guid id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet("email/{email}")]
        public async Task<ActionResult<User>> GetByEmail(string email)
        {
            var user = await _userService.GetByEmailAsync(email);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetAll()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create(User user)
        {
            var createdUser = await _userService.CreateAsync(user);
            return CreatedAtAction(nameof(GetById), new { id = createdUser.Id }, createdUser);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, User user)
        {
            if (id != user.Id)
                return BadRequest();
            var updatedUser = await _userService.UpdateAsync(user);
            if (updatedUser == null)
                return NotFound();
            return Ok(updatedUser);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _userService.DeleteAsync(id);
            return NoContent();
        }

        [HttpPost("verify-email")]
        public async Task<ActionResult<bool>> VerifyEmail([FromBody] EmailVerificationDto dto)
        {
            var result = await _userService.VerifyEmailAsync(dto.Email, dto.Token);
            return Ok(result);
        }

        [HttpPost("verify-phone")]
        public async Task<ActionResult<bool>> VerifyPhone([FromBody] PhoneVerificationDto dto)
        {
            var result = await _userService.VerifyPhoneAsync(dto.PhoneNumber, dto.Code);
            return Ok(result);
        }

        [HttpPost("change-password")]
        public async Task<ActionResult<bool>> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            var result = await _userService.ChangePasswordAsync(dto.UserId, dto.CurrentPassword, dto.NewPassword);
            return Ok(result);
        }

        [HttpPost("reset-password")]
        public async Task<ActionResult<bool>> ResetPassword([FromBody] ResetPasswordDto dto)
        {
            var result = await _userService.ResetPasswordAsync(dto.Email, dto.Token, dto.NewPassword);
            return Ok(result);
        }

        [HttpPost("generate-reset-token")]
        public async Task<ActionResult<string>> GeneratePasswordResetToken([FromBody] string email)
        {
            var token = await _userService.GeneratePasswordResetTokenAsync(email);
            return Ok(token);
        }
    }

    public class EmailVerificationDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
    public class PhoneVerificationDto
    {
        public string PhoneNumber { get; set; }
        public string Code { get; set; }
    }
    public class ChangePasswordDto
    {
        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
    }
    public class ResetPasswordDto
    {
        public string Email { get; set; }
        public string Token { get; set; }
        public string NewPassword { get; set; }
    }
} 