using AutoMapper;
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Application.Services
{
    public class PhoneApp : BaseServiceApp<Phone, PhoneDTORequest, PhoneDTOResponse>, IPhoneApp
    {
        private readonly IPhoneService _service;
        private readonly IMapper _iMapper;
        public PhoneApp(IMapper iMapper, IPhoneService service)
            : base(iMapper, service)
        {
            _service = service;
            _iMapper = iMapper;
        }

       
    }
}