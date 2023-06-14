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
                                  && q.EmployeeId == userId
                                  && q.Period == period);
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        return await _context.LeaveAllocations
                            .Include(q => q.LeaveType)
                            .FirstOrDefaultAsync(q => q.Id == id);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails()
    {
        return await _context.LeaveAllocations
                        .Include(q => q.LeaveType)
                        .ToListAsync();
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationWithDetails(string userId)
    {
        return await _context.LeaveAllocations
                    .Where(q => q.EmployeeId == userId)
                    .Include(q => q.LeaveType)
                    .ToListAsync();
    }

    public Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return _context.LeaveAllocations
                .Where(q => q.EmployeeId == userId && q.LeaveTypeId == leaveTypeId)
                .Include(q => q.LeaveType)
                .FirstOrDefaultAsync();
    }
}
