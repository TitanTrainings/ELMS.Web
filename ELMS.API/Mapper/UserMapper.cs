using AutoMapper;
using ELMS.API.DTO;
using ELMS.API.Models;

namespace ELMS.API.Mapper
{
    public class UserMapper : Profile
    {
        public UserMapper() 
        {
            CreateMap<User, UserDTO>()
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))

                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))

                .ForMember(dest => dest.Role, opt => opt.MapFrom(src => src.Role))

                .ForMember(dest => dest.LeaveBalance, opt => opt.MapFrom(src => src.LeaveBalance));

        }
    }
}
