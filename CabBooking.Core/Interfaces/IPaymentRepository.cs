using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CabBooking.Core.Models;

namespace CabBooking.Core.Interfaces
{
    public interface IPaymentRepository
    {
        Task<Payment> GetByIdAsync(Guid id);
        Task<IEnumerable<Payment>> GetAllAsync();
        Task<IEnumerable<Payment>> GetUserPaymentsAsync(Guid userId);
        Task<Payment> CreateAsync(Payment payment);
        Task<Payment> UpdateAsync(Payment payment);
        Task DeleteAsync(Guid id);
    }
} 