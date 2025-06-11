using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CabBooking.Core.Interfaces;
using CabBooking.Core.Models;

namespace CabBooking.Infrastructure.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public async Task<User> GetByEmailAsync(string email)
        {
            return await Task.FromResult(_items.OfType<User>().FirstOrDefault(u => u.Email == email));
        }
    }
} 