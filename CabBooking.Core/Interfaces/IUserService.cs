using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IUserService
    {
        Task<User> GetByIdAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task DeleteAsync(Guid id);
        Task<bool> VerifyEmailAsync(string email, string token);
        Task<bool> VerifyPhoneAsync(string phoneNumber, string code);
        Task<bool> ChangePasswordAsync(Guid userId, string currentPassword, string newPassword);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
        Task<string> GeneratePasswordResetTokenAsync(string email);
    }
} 