using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class Certification
{
    public int Cid { get; set; }

    public int? EmpId { get; set; }

    public string? Cname { get; set; }

    public bool IsActive { get; set; }

    public virtual EmployeeInfo? Emp { get; set; }
}
