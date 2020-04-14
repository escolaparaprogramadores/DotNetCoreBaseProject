
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Application.DTO;
using Demo.Domain.Entities;

namespace Demo.Application.Contracts
{
    public interface IUserApp : IBaseApp<User, UserDTORequest, UserDTOResponse>
    {
         Task<UserDTORequest> GetUserByEmail(string email);
         bool ValidarEmail(string email);        
    }
}