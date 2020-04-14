using Demo.Domain.Entities;
using Demo.Infrastucture.Data.EntityConfiguration;
using Demo.Domain.Contracts.Repositories;

namespace Demo.Infrastucture.Data.Repositories
{
    public class PhoneRepository : BaseRepository<Phone>, IPhoneRepository
    {
        public PhoneRepository(ApplicationDbContext context) : base(context)
        {
        }

          
    }
}