using System.Linq;
using System.Security.Claims;
using Demo.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Demo.Service.Api.Controllers
{
    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        
        private readonly Claim _claim;
        private readonly IUserClaimsApp _userClaimsApp;

        public RequisitoClaimFilter(Claim claim, IUserClaimsApp userClaimsApp)
        {
            _claim = claim;
            _userClaimsApp = userClaimsApp;
        }

        public void OnAuthorization(AuthorizationFilterContext httpContext)
        {
            string token = string.Empty;

            foreach (var item in httpContext.HttpContext.Request.Headers)
            if (item.Key == "Authorization") token = item.Value.ToString().Replace("Bearer", "").Trim();

            var claims = _userClaimsApp.GetUserClaims(token);
            var result = claims.Any(c => c.ClaimType.Trim() == _claim.Type && c.ClaimValue.Split(";").Contains(_claim.Value));
            if (!result)
            {
                httpContext.Result = new StatusCodeResult(403);
            }
                
            
        }
    }
}