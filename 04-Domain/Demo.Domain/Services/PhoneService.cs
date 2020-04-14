using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Domain.Services
{
    public class PhoneService : BaseService<Phone>, IPhoneService
    {
        private readonly IPhoneRepository _repository;
        public PhoneService(IPhoneRepository repository) : base(repository)
        => _repository = repository;


    }
}

     