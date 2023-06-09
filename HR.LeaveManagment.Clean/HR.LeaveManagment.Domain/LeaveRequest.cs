using HR.LeaveManagment.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace HR.LeaveManagment.Domain;

public class LeaveRequest : BaseEntity
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public LeaveType? LeaveType{ get; set; }
    [ForeignKey("LeaveTypeId")]
    public int LeaveTypeId { get; set; }
    public DateTime DateRequested { get; set; }
    public string? RequestComments { get; set; }
    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }
    public string RequestingEmployeeId { get; set; } = string.Empty;
}