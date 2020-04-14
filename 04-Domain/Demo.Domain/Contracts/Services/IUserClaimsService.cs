using System;
using Demo.Domain.Entities;
using System.Collections.Generic;


namespace Demo.Domain.Contracts.Services
{
    public interface IUserClaimsService: IBaseService<UserClaims> 
    {
        IEnumerable<UserClaims> GetUserClaims(Guid userId);
        IEnumerable<UserClaims> GetUserClaims(string token);
    }
}