using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Contracts.Repositories
{
    
    public interface IUserClaimsRepository: IBaseRepository<UserClaims> 
    {
          IEnumerable<UserClaims> GetUserClaims(Guid userId);
          IEnumerable<UserClaims> GetUserClaims(string token);
    }
}