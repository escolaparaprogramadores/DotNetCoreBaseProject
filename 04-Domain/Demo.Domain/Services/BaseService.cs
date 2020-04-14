using Demo.Domain.Entities;
using Demo.Domain.Contracts.Repositories;
using Demo.Domain.Contracts.Services;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;

namespace Demo.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
    private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        =>  _repository = repository;
        
        public virtual async Task Update(TEntity entity) 
        => await _repository.Update(entity);
            
        public virtual async Task Remove(TEntity entidade)
            => await _repository.Remove(entidade);
        
        public  virtual async Task<TEntity> Add(TEntity entidade)
            => await _repository.Add(entidade);
        

        public virtual async Task<TEntity>  GetById(Guid id)
            => await _repository.GetById(id);
        

        public virtual async Task<IEnumerable<TEntity>> GetAll()
             => await _repository.GetAll();
        
    }
}