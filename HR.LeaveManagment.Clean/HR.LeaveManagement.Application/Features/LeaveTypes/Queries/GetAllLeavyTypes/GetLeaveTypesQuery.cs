using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeavyTypes;
public class GetLeaveTypesQuery : IRequest<List<LeaveTypeDTO>>
{
}
