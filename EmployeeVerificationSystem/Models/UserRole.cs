using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class UserRole
{
    public Guid RoleId { get; set; }

    public string? RoleName { get; set; }

    public virtual ICollection<EmployeeInfo> EmployeeInfos { get; } = new List<EmployeeInfo>();
}
