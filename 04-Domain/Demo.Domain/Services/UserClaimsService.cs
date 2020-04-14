using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Domain.Services
{
    public class UserClaimsService : BaseService<UserClaims>, IUserClaimsService
    {
        private readonly IUserClaimsRepository _repository;
        public UserClaimsService(IUserClaimsRepository repository) : base(repository)
        => _repository = repository;

         public IEnumerable<UserClaims> GetUserClaims(Guid userId)
        =>  _repository.GetUserClaims(userId);

        public IEnumerable<UserClaims> GetUserClaims(string token)
         =>  _repository.GetUserClaims(token);
    }
}

     