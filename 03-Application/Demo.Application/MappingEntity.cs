using AutoMapper;
using Demo.Application.DTO;
using Demo.Domain.Entities;

namespace Demo.Aplication
{
    public class MappingEntity : Profile
    {
        public MappingEntity()
        {
            CreateMap<User, UserDTOResponse>().ReverseMap();

            CreateMap<User , UserDTORequest>().ReverseMap();

            CreateMap<UserClaims, UserClaimsDTORequest>().ReverseMap();

            CreateMap<UserClaims, UserClaimsDTOResponse>().ReverseMap();

            CreateMap<Phone, PhoneDTOResponse>().ReverseMap();

            CreateMap<Phone, PhoneDTORequest>().ReverseMap();
        }
        
    }
}