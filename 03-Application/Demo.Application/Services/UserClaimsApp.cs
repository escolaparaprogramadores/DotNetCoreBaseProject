using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Application.Services
{
    public class UserClaimsApp : BaseServiceApp<UserClaims, UserClaimsDTORequest, UserClaimsDTORequest>, IUserClaimsApp
    {
        private readonly IUserClaimsService _service;
        private readonly IMapper _iMapper;

        public UserClaimsApp(IMapper iMapper, IUserClaimsService service)
            : base(iMapper, service)
        {
            _service = service;
            _iMapper = iMapper;
        }

       
        public IEnumerable<UserClaimsDTORequest> GetUserClaims(Guid userId)
        => _iMapper.Map<IEnumerable<UserClaimsDTORequest>>( _service.GetUserClaims(userId));

        public IEnumerable<UserClaimsDTORequest> GetUserClaims(string token)
        =>  _iMapper.Map<IEnumerable<UserClaimsDTORequest>>( _service.GetUserClaims(token));
    }
}