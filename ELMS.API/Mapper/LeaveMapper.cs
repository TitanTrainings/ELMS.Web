using AutoMapper;
using ELMS.API.DTO;
using ELMS.API.Models;

namespace ELMS.API.Mapper
{
    public class LeaveRequestMapper : Profile
    {
        public LeaveRequestMapper()
        {
            // Mapping between User and UserDTO
            CreateMap<LeaveRequest, LeaveRequestDTO>()
                .ForMember(dest => dest.LeaveRequestId, opt => opt.MapFrom(src => src.LeaveRequestId))

                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.UserId))

                .ForMember(dest => dest.LeaveType, opt => opt.MapFrom(src => src.LeaveType))

                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))

                .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))

                .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))

                .ForMember(dest => dest.ManagerComments, opt => opt.MapFrom(src => src.ManagerComments));
        }
    }
}
