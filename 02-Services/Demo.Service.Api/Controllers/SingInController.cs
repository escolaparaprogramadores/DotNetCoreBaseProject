
using Demo.Application.Contracts;
using Demo.Application.DTO;
using Demo.Domain.Entities;
using Demo.Infrastructure.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;
using System.Threading.Tasks;


namespace Demo.Service.Api.Controllers
{
    [Route("v1/api/[controller]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class SingInController : Controller
    {
        private readonly IUserApp _userApp;
        private readonly IUserClaimsApp _userClaimsApp;
       
        public SingInController(IUserApp app, IUserClaimsApp userClaimsApp)               
        {
            _userApp = app;
            _userClaimsApp = userClaimsApp;
        } 


        [HttpPost(), AllowAnonymous]
        public async Task<ActionResult> Post([FromServices]TokenConfiguration tokenConfiguration,
        [FromServices] SigningConfig signingConfig,
        UserDTORequest user)
        {
            UserDTORequest userBase;

            if (!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password))
            {
                var senhaCriptografada = string.Empty;
                senhaCriptografada = new Hash(new SHA512Managed()).CriptografarSenha(user.Password);
                user.Password = senhaCriptografada;

                userBase = await _userApp.GetUserByEmail(user.Email);
                if (userBase == null)
                    return  BadRequest(new 
                    {
                        StatusCode = 400,
                        Success = false,
                        Message = "Usuário e/ou senha inválidos"
                    });
                
            }
            else
                return  BadRequest(new 
                    {
                        StatusCode = 400,
                        Success = false,
                        Message = "Por favor, preencha todos os campos"
                    });

            var claims = _userClaimsApp.GetUserClaims(userBase.Id);
            userBase.Token = TokenGenerator.GetToken(userBase, tokenConfiguration, signingConfig, claims);
            userBase.LastLoginDate = DateTime.Now.ToLocalTime();
            await _userApp.Update(userBase);
            return Ok(new 
                    {
                        StatusCode = 200,
                        Success = true,
                        Data = userBase.Token
                    });
        }
    }
}