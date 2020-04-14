using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Application.Services
{
    public class UserApp : BaseServiceApp<User, UserDTORequest, UserDTOResponse>, IUserApp
    {
        private readonly IUserService _service;
        private readonly IMapper _iMapper;
        public UserApp(IMapper iMapper, IUserService service)
            : base(iMapper, service)
        {
            _service = service;
            _iMapper = iMapper;
        }
        
        public async Task<UserDTORequest> GetUserByEmail(string email)
            => _iMapper.Map<UserDTORequest>(await _service.GetUserByEmail(email));

        public bool ValidarEmail(string email)
            => _service.ValidarEmail(email);
    }
}