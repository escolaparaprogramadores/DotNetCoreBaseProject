using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Demo.Domain.Entities 
{
    public class User : BaseEntity
    {

        public User() { }

        public User(User user, string encryptedPassword, string token)
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
        public  ICollection<Phone> Phones { get;  set; } =  new Collection<Phone>();
        public  ICollection<UserClaims> Claims { get;  set; } =  new Collection<UserClaims>();
        public string Token { get;  set; }



        public string Validar()
        {
            return null;
        }

    }
}