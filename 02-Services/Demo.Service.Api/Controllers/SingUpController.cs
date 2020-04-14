using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Entities;
using Demo.Infrastructure.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Demo.Service.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class SingUpController : Controller
    {
       private readonly IEnumerable<UserClaimsDTORequest> _claims;
       private readonly IUserApp _userApp;
       
        public SingUpController(IUserApp app, IEnumerable<UserClaimsDTORequest> claims)              
        {
            _userApp = app;
            _claims = claims;
        } 


        [HttpPost("{singup}"), AllowAnonymous]
        public async Task<ActionResult> Post(
        [FromServices]TokenConfiguration tokenConfig,
        [FromServices] SigningConfig signingConfig,
        UserDTORequest user)
        {
           
            var iSExist = _userApp.ValidarEmail(user.Email);
            if (!iSExist)
            {
                var obj = new UserDTORequest(user, new Hash(new SHA512Managed())
                .CriptografarSenha(user.Password), TokenGenerator
                .GetToken(user, tokenConfig, signingConfig, _claims));

                await _userApp.Add(obj);

                return CreatedAtAction("Post",new 
                {
                    StatusCode = 201,
                    Success = true,
                    Message = "Salvo com sucesso"
                });
            }
            else
                return BadRequest(new 
                {
                    StatusCode = 400,
                    Success = false,
                    Message = "E-mail já Cadastrado"
                });
        }
    }
}