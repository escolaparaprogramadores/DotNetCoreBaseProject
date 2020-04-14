using System;
using Demo.Domain.Entities;

namespace Demo.Application.DTO
{
    public class UserClaimsDTORequest : BaseDTO
    {  
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid UserId { get;  set; }
        public User User { get;  set; }
    }
}