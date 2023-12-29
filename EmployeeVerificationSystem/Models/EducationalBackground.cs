using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class EducationalBackground
{
    public int EduId { get; set; }

    public int? EmpId { get; set; }

    public DateTime? FromDate { get; set; }

    public DateTime? ToDate { get; set; }

    public string? Degree { get; set; }

    public bool? IsActive { get; set; }

    public string ApproveStatus { get; set; } = null!;

    public virtual EmployeeInfo? Emp { get; set; }
}
