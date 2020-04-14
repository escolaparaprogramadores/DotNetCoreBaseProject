using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Demo.Application.DTO;
using Demo.Domain.Entities;

namespace Demo.Application.Contracts
{
    public interface IBaseApp<TEntity, TEntityDTORequest, TEntityDTOResponse> 
    where TEntity : BaseEntity
    where TEntityDTORequest : BaseDTO
    where TEntityDTOResponse : BaseDTO
    {
        Task Add(TEntityDTORequest obj);
        Task<TEntityDTOResponse> GetById(Guid id);
        Task<IEnumerable<TEntityDTOResponse>> GetAll();
        Task Update(TEntityDTORequest obj);
        Task Remove(TEntityDTORequest obj);
    }
}