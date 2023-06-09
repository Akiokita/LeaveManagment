using HR.LeaveManagment.Domain;

namespace HR.LeaveManagement.Application.Contracts.Persistence
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequest> GetLeaveRequestWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(int id);
        Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId);
    }
}
