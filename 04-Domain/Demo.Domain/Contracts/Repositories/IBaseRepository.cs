using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Domain.Entities;

namespace Demo.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> Add(TEntity obj);
        Task<TEntity>  GetById(Guid id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Update(TEntity obj);
        Task Remove(TEntity obj);
        
    }
}