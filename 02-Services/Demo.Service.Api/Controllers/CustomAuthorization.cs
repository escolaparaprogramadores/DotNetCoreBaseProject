using System;
using System.Linq;
using Demo.Application.Contracts;
using Demo.Infrastucture.Data.EntityConfiguration;
using Demo.Infrastucture.Data.Repositories;
using Microsoft.AspNetCore.Http;

namespace Demo.Service.Api.Controllers
{
    public class CustomAuthorization 
    {
        public static bool ValidarClaimsUsuario(HttpContext httpContext, string claimType, string claimValue)
        {

            // string token = string.Empty;

            // foreach (var item in httpContext.Request.Headers)
            // if (item.Key == "Authorization") token = item.Value.ToString().Replace("Bearer", "").Trim();

            // using (var _userClaimsApp = new UserClaimsRepository(new ApplicationDbContext))
            // {
            // var claims = _userClaimsApp.GetUserClaims(token);
            // }
            
           
            // return claims.Any(c => c.ClaimType == claimType && c.ClaimValue.Split(";").Contains(claimValue));
                   
return true;
                //    return context.User.Identity.IsAuthenticated &&
                //    context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }

    }
}