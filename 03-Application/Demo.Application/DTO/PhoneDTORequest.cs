using Demo.Domain.Entities;

namespace Demo.Application.DTO
{
    public class PhoneDTORequest : BaseDTO 
    {  
        public string PhoneNumber { get;   set; }
        public string Ddd { get;  set; }
        public long UserId { get;  set; }
        public User User { get;  set; }
    }
}