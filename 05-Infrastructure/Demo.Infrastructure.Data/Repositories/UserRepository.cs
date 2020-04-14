using System.Collections.Generic;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Entities;
using Demo.Infrastucture.Data.EntityConfiguration;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Demo.Infrastucture.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }

          public override async Task<IEnumerable<User>> GetAll()
          => await _context.User
          .AsNoTracking()
          .Include(c => c.Claims)
          .Include(p => p.Phones)
          .Select(x => x).ToListAsync();

          public bool ValidarEmail(string email)
          => (from u in _context.User
          .AsNoTracking()
          select new { u })
          .Where(x => x.u.Email == email)
          .Select(x => x.u != null ? true : false)
          .FirstOrDefault();

          public async Task<User> GetUserByEmail(string email)
          => await (from u in _context.User
          .AsNoTracking()
          select new { u })
          .Where(x => x.u.Email == email)
          .Select(x => x.u)
          .FirstOrDefaultAsync();

          public async Task<IEnumerable<UserClaims>> GetUserClaims(User user)
          => await (from c in _context.UserClaims
          .AsNoTracking()
          select new { c })
          .Where(x => x.c.UserId == user.Id)
          .Select(x => x.c)
          .ToListAsync();

         public override async Task<User> GetById(Guid id)
         => await _context.User
          .AsNoTracking()
          .Include(c => c.Claims)
          .Include(p => p.Phones)
          .Select(x => x).FirstOrDefaultAsync();
    }
}