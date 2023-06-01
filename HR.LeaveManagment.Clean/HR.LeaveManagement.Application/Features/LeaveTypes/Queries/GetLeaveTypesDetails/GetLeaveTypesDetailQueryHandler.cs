using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagment.Domain;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetLeaveTypesDetails
{
    public class GetLeaveTypesDetailQueryHandler : IRequestHandler<GetLeaveTypesDetailQuery, LeaveTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        public GetLeaveTypesDetailQueryHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
        }
        public async Task<LeaveTypeDetailsDTO> Handle(GetLeaveTypesDetailQuery request, CancellationToken cancellationToken)
        {
            var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            var data = _mapper.Map<LeaveTypeDetailsDTO>(leaveType);

            return data;
        }
    }
}
