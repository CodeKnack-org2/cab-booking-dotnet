using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class PaymentRepository : BaseRepository<Payment>, IPaymentRepository
    {
        public async Task<IEnumerable<Payment>> GetUserPaymentsAsync(Guid userId)
        {
            return await Task.FromResult(_items.OfType<Payment>().Where(p => p.UserId == userId));
        }
    }
} 