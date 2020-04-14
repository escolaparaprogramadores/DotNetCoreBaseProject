using Demo.Application.DTO;
using Demo.Domain.Entities;

namespace Demo.Application.Contracts
{
    public interface IPhoneApp : IBaseApp<Phone, PhoneDTORequest, PhoneDTOResponse>
    {         
       
    }
}