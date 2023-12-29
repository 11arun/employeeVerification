using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class Document
{
    public int Did { get; set; }

    public int? EmpId { get; set; }

    public string? Dname { get; set; }

    public string? Documnet { get; set; }

    public bool? IsActive { get; set; }

    public virtual EmployeeInfo? Emp { get; set; }
}
