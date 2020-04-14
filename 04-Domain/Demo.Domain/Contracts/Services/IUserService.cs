using System;
using Demo.Domain.Entities;
using Demo.Domain.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Demo.Domain.Contracts.Services
{
    public interface IUserService: IBaseService<User> 
    {
        Task<User> GetUserByEmail(string email);
        bool ValidarEmail(string email);
    }
}