using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Contracts.Services;
using Demo.Domain.Entities;

namespace Demo.Application.Services
{
    public class BaseServiceApp<TEntity, TEntityDTORequest, TEntityDTOResponse> : IBaseApp<TEntity, TEntityDTORequest, TEntityDTOResponse>
        where TEntity : BaseEntity
        where TEntityDTORequest : BaseDTO
        where TEntityDTOResponse : BaseDTO
    {

        private readonly IBaseService<TEntity> _service;
        private readonly IMapper _iMapper;

        public BaseServiceApp(IMapper iMapper, IBaseService<TEntity> service)
            : base()
        {
            this._iMapper = iMapper;
            this._service = service;
        }

        public virtual async Task Add(TEntityDTORequest obj)
            => await _service.Add(_iMapper.Map<TEntity>(obj));
      

        public virtual async Task<IEnumerable<TEntityDTOResponse>> GetAll()
            => _iMapper.Map<IEnumerable<TEntityDTOResponse>>(await _service.GetAll());


        public virtual async Task<TEntityDTOResponse> GetById(Guid id)
            => _iMapper.Map<TEntityDTOResponse>(await _service.GetById(id));


        public virtual async Task Remove(TEntityDTORequest obj)
            => await _service.Remove(_iMapper.Map<TEntity>(obj));


        public virtual async Task Update(TEntityDTORequest obj)
            => await _service.Update(_iMapper.Map<TEntity>(obj));

       
    }
}