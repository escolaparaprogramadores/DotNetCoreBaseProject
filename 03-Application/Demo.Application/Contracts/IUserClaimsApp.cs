
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Application.DTO;
using Demo.Domain.Entities;

namespace Demo.Application.Contracts
{
    public interface IUserClaimsApp : IBaseApp<UserClaims, UserClaimsDTORequest, UserClaimsDTORequest>
    {         
        IEnumerable<UserClaimsDTORequest> GetUserClaims(Guid userId);
        IEnumerable<UserClaimsDTORequest> GetUserClaims(string token);
    }
}