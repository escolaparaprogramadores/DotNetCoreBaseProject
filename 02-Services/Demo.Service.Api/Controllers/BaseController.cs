
using Demo.Application.DTO;
using Demo.Application.Contracts;
using Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace Demo.Service.Api.Controllers
{  
    
    [Route("v1/api/[controller]")]
    [ApiController]
    //[Authorize]
    [Produces("application/json")]
    public class BaseController<TEntity, TEntityDTORequest, TEntityDTOResponse> : ControllerBase
    where TEntity : BaseEntity
    where TEntityDTORequest : BaseDTO
    where TEntityDTOResponse : BaseDTO
    {
        private readonly IBaseApp<TEntity, TEntityDTORequest, TEntityDTOResponse> _app;

        public BaseController(IBaseApp<TEntity, TEntityDTORequest, TEntityDTOResponse> app) 
        => _app = app;
   

        [HttpGet]
        //[ClaimsAuthorize("User","list")]
        public virtual async Task<ActionResult> GetAll()
        {
            try
            {
                var obj = await _app.GetAll();
                return Ok(obj);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[ClaimsAuthorize("User","list")]
        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(Guid id)
        {
            try
            {
                var obj = await _app.GetById(id);
                if(obj == null) 
                return NotFound(new 
                { 
                     StatusCode = 404,
                     Success = false,
                     Data = "Não encontrado"
                } );

                return Ok(new 
                { 
                     StatusCode = 200,
                     Success = true,
                     Data = obj
                } );
            }
            
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[ClaimsAuthorize("User","create")]
        [HttpPost]
        public async Task<ActionResult> Add(TEntityDTORequest data)
        {
            try
            {
                await _app.Add(data);
                return  CreatedAtAction("Post", new 
                { 
                     StatusCode = 200,
                     Success = true,
                     Data = "Criado com sucesso"
                } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[ClaimsAuthorize("User","update")]
        [HttpPut]
        public virtual async Task<ActionResult> Update(TEntityDTORequest data)
        {
            try
            {                
                await _app.Update(data);
                return Ok(new 
                { 
                     StatusCode = 200,
                     Success = true,
                     Data = "Atualizado com sucesso"
                } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        //[ClaimsAuthorize("User","delete")]
        [HttpDelete]
        public async Task<ActionResult> Remove(TEntityDTORequest data)
        {
            try
            {
                await _app.Remove(data);
                return Ok(new 
                { 
                     StatusCode = 200,
                     Success = true,
                     Data = "Excluido com sucesso"
                } );
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}