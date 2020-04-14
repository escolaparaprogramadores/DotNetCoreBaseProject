using System;
using System.Collections.Generic;
using Demo.Domain.Entities;

namespace Demo.Application.DTO
{
    public class UserDTOResponse : BaseDTO
    {
    
        public UserDTOResponse(){}

        public string Name { get;  set; }
        public string Email { get;  set; }
        public DateTime LastLoginDate { get;  set; }
        public virtual ICollection<PhoneDTOResponse> Phones { get;  set; }
        public virtual ICollection<UserClaimsDTOResponse> Claims { get;  set; }
    }
}