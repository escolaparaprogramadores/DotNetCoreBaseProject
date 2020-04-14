
using Demo.Application.DTO;
using Demo.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Ioc
{
    public static class TokenGenerator
    {
        static List<Claim> claimList = new List<Claim>();
        public static string GetToken(UserDTORequest user, TokenConfiguration tokenConfigurations,  dynamic signingConfigurations, IEnumerable<UserClaimsDTORequest> claims)
        {
            foreach (var claim in claims) claimList.Add(new Claim(claim.ClaimType, claim.ClaimValue));
            var identity = new ClaimsIdentity(claimList);
                
            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao + TimeSpan.FromSeconds(tokenConfigurations.Seconds);
                

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = tokenConfigurations.Issuer,
                Audience = tokenConfigurations.Audience,
                SigningCredentials = signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return token;

        }      
    }
}
