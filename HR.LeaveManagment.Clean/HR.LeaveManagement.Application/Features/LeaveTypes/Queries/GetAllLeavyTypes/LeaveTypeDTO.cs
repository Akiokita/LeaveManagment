namespace HR.LeaveManagement.Application.Features.LeaveTypes.Queries.GetAllLeavyTypes;

public class LeaveTypeDTO
{
    public string? Name { get; set; } = string.Empty;
    public int DefaultDays { get; set; }
}
