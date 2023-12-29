using System;
using System.Collections.Generic;

namespace EmployeeVerificationSystem.Models;

public partial class EmployeeInfo
{
    public int EmpId { get; set; }

    public string? Name { get; set; }

    public string? MobNo { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public bool? IsActive { get; set; }

    public Guid? RoleId { get; set; }

    public virtual ICollection<Certification> Certifications { get; } = new List<Certification>();

    public virtual ICollection<Document> Documents { get; } = new List<Document>();

    public virtual ICollection<EducationalBackground> EducationalBackgrounds { get; } = new List<EducationalBackground>();

    public virtual UserRole? Role { get; set; }

    public virtual ICollection<WorkExperience> WorkExperiences { get; } = new List<WorkExperience>();
}
