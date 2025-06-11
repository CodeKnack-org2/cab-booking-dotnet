using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IPaymentService
    {
        Task<Payment> GetByIdAsync(Guid id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetUserPaymentsAsync(Guid userId);
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment> UpdateAsync(Payment payment);
        Task DeleteAsync(Guid id);
        Task<bool> ProcessPaymentAsync(Guid paymentId);
        Task<bool> RefundPaymentAsync(Guid paymentId, string reason);
        Task<string> GeneratePaymentTokenAsync(string cardNumber, string expiryMonth, string expiryYear, string cvv);
        Task<bool> ValidatePaymentAsync(string paymentToken);
    }
} 