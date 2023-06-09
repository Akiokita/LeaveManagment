using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagment.Domain;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagment.Persistence.DataBaseContext.Repositories;

public class LeaveAllocationRepository : GanericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(HrDatabaseContext context) : base(context)
    {
    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _context.AddRangeAsync(allocations);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _context.LeaveAllocations
            .AnyAsync(q => q.LeaveTypeId == leaveTypeId
                        && q.)
    }

    public Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        throw new NotImplementedException();
    }

    public Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        throw new NotImplementedException();
    }

    public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        throw new NotImplementedException();
    }
}
