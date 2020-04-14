using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Contracts.Repositories
{
    
    public interface IUserRepository: IBaseRepository<User> 
    {
        Task<User> GetUserByEmail(string email);
        Task<IEnumerable<UserClaims>> GetUserClaims(User user);
        bool ValidarEmail(string email);
    }
}