using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class WorkExperience
{
    public int Cid { get; set; }

    public int? EmpId { get; set; }

    public string? CompanyName { get; set; }

    public string? Technology { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Designation { get; set; }

    public bool? IsActive { get; set; }

    public string ApproveStatus { get; set; } = null!;

    public virtual EmployeeInfo? Emp { get; set; }
}
