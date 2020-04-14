using System;
using System.Text.Json.Serialization;

namespace Demo.Domain.Entities
{
    public class UserClaims : BaseEntity
    {
        public UserClaims (){}

        public UserClaims(string claimType, string claimValue, Guid userId)
        {
            ClaimType = claimType;
            ClaimValue = claimValue;
            UserId = userId;
        }
        public string ClaimType { get; set; }
        public string ClaimValue { get; set; }
        public Guid UserId { get;  set; }
        public User User { get;  set; }
        
    }
}