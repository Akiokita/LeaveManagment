using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeavyTypes;
using HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypesDetails;
using HR.LeaveManagment.Domain;

namespace HR.LeaveManagement.Application.MappingProfiles
{
    public class LeaveTypeProfile : Profile
    {
        public LeaveTypeProfile()
        {
            CreateMap<LeaveTypeDTO, LeaveType>().ReverseMap();
            CreateMap<LeaveType, LeaveTypeDetailsDTO>();
            CreateMap<LeaveType, LeaveTypeDetailsDTO>();
        }
    }
}
