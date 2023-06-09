using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistence.DataBaseContext.Repositories;

public class LeaveRequestRepository : GanericRepository<LeaveRequest>, ILeaveRequestRepository
{
    public LeaveRequestRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(int id)
    {
        var leaveRequests = await _context.LeaveRequests
            .Include(q => q.LeaveType)
            .ToListAsync();

        return leaveRequests;
    }

    public async Task<List<LeaveRequest>> GetLeaveRequestsWithDetails(string userId)
    {
        var leaveRequestsDetails = await _context.LeaveRequests
            .Where(q => q.RequestingEmployeeId == userId)
            .Include(q => q.LeaveType)  
            .ToListAsync();

        return leaveRequestsDetails;
    }

    public async Task<LeaveRequest> GetLeaveRequestWithDetails(int id)
    {
        var leaveRequestsDetails = await _context.LeaveRequests
            .Where(q => q.Id == id)
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync();

        return leaveRequestsDetails;
    }

}
