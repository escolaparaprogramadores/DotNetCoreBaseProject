using System;

namespace Demo.Domain.Entities
{
    public class Phone : BaseEntity
    {
        public Phone() { }

        public Phone(string phoneNumber, string ddd, Guid userId)
        {
            UserId = userId;
            PhoneNumber = phoneNumber;
            Ddd = ddd;
        }

        public string PhoneNumber { get;   set; }
        public string Ddd { get;  set; }
        public Guid UserId { get;  set; }
        public User User { get;  set; }

    }
}