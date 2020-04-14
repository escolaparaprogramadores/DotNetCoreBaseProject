using System;
using System.Linq;
using System.Threading.Tasks;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Domain.Services
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository) : base(repository)
        => _repository = repository;

        public async Task<User> GetUserByEmail(string email)
            => await _repository.GetUserByEmail(email);

        public bool ValidarEmail(string email)
            => _repository.ValidarEmail(email);

        public override async Task Update(User entity)
        {    
           var user =  await _repository.GetById(entity.Id);

           // entity.Phones.ForEach((x) => x.User = entity.Id);
            entity.Phones.Select(x => x.UserId = user.Id).ToList();
            entity.Claims.Select(x => x.UserId = user.Id).ToList();

            user.Id = entity.Id;
            user.Name = entity.Name;
            user.Email = user.Email;
            user.UpdateDate = DateTime.Now.ToLocalTime();
            user.Phones = entity.Phones;
            user.Claims.Select(x => x.UserId = user.Id).ToList();
            user.Claims.Select(x => x.ClaimType = "SFD").ToList();

            await _repository.Update(user);
        } 
    }
}

     