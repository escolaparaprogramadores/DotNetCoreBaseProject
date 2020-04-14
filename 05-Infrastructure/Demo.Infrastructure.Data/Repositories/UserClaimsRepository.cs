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
    public class UserClaimsRepository : BaseRepository<UserClaims>, IUserClaimsRepository
    {
        public UserClaimsRepository(ApplicationDbContext context) : base(context)
        {
        }
          public IEnumerable<UserClaims> GetUserClaims(Guid userId)
          =>  (from c in _context.UserClaims
          .AsNoTracking()
          select new { c }).Where(x => x.c.UserId == userId).Select(x => x.c).ToList();

        public IEnumerable<UserClaims> GetUserClaims(string token)
        => (from u in _context.User join c in _context.UserClaims
         on u.Id equals c.UserId
         select new { c,u }).Where(x => x.u.Token == token).Select(x => x.c).ToList();
    }
}