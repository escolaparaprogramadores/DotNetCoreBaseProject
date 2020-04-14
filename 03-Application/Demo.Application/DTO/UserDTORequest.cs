using System;
using System.Collections.Generic;
using Demo.Domain.Entities;

namespace Demo.Application.DTO
{
    public class UserDTORequest : BaseDTO
    {
      public UserDTORequest (){}
      public UserDTORequest(UserDTORequest user, string encryptedPassword, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Password = encryptedPassword;
            Email = user.Email;
            Token = token;
            CriationDate = DateTime.Now.ToLocalTime();
            UpdateDate = DateTime.Now.ToLocalTime();
            LastLoginDate = DateTime.Now.ToLocalTime();
            Phones = user.Phones;
            Claims = user.Claims;
        }

        public string Name { get;  set; }
        public string Password { get;  set; }
        public string Email { get;  set; }
        public DateTime CriationDate { get;  set; }
        public DateTime UpdateDate { get;  set; }
        public DateTime LastLoginDate { get;  set; }
        public ICollection<Phone> Phones { get;  set; }
        public ICollection<UserClaims> Claims { get;  set; }
        public string Token { get;  set; }
 
     
    }
}