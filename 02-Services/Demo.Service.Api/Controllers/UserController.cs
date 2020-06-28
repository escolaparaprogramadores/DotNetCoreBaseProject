using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Entities;
using Demo.Infrastructure.Ioc;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Service.Api.Controllers
{

    public class UserController : BaseController<User, UserDTORequest, UserDTOResponse>
    {
        private readonly IUserApp _userApp;
        private readonly TokenConfiguration _tokenConfig;
        private readonly SigningConfig _signingConfig;
        private readonly IEnumerable<UserClaimsDTORequest> _claims;
        public UserController(IUserApp app, TokenConfiguration tokenConfig, SigningConfig signingConfig, IEnumerable<UserClaimsDTORequest> claims) : base(app)
        {
            _userApp = app;
            _tokenConfig = tokenConfig;
            _signingConfig = signingConfig;
            _claims = claims;
        }

      //[ClaimsAuthorize("User","list")]
      [HttpGet]
      [Produces("application/json")]
        public override async Task<ActionResult> GetAll()
        {
            try
            {
                var obj = await _userApp.GetAll();
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

        //[ClaimsAuthorize("User","update")]
        //[HttpPut]
        public override async Task<ActionResult> Update(UserDTORequest obj)
        {
            try
             {  
                await _userApp.Update(obj);
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

    }
}