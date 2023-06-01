using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypesDetails
{
    public record GetLeaveTypesDetailQuery(int Id) : IRequest<LeaveTypeDetailsDTO>
    {
    }
}
