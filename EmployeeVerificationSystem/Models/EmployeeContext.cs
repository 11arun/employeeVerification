using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EmployeeVerificationSystem.Models;

public partial class EmployeeContext : DbContext
{
    public EmployeeContext()
    {
    }

    public EmployeeContext(DbContextOptions<EmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Certification> Certifications { get; set; }

    public virtual DbSet<Document> Documents { get; set; }

    public virtual DbSet<EducationalBackground> EducationalBackgrounds { get; set; }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    public virtual DbSet<WorkExperience> WorkExperiences { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\ProjectModels;Initial Catalog=Employee;Trusted_Connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Certification>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Certific__C1F8DC398D64D06D");

            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.Cname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CName");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Emp).WithMany(p => p.Certifications)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Certifica__EmpId__2F10007B");
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Did).HasName("PK__Document__C03656501623D0E2");

            entity.ToTable("Document");

            entity.Property(e => e.Did).HasColumnName("DId");
            entity.Property(e => e.Dname)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DName");
            entity.Property(e => e.Documnet)
                .HasMaxLength(1000)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");

            entity.HasOne(d => d.Emp).WithMany(p => p.Documents)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Document__EmpId__32E0915F");
        });

        modelBuilder.Entity<EducationalBackground>(entity =>
        {
            entity.HasKey(e => e.EduId).HasName("PK__Educatio__1FD9490EA77C1C4D");

            entity.ToTable("Educational_Background");

            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('pending')");
            entity.Property(e => e.Degree)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.EducationalBackgrounds)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Education__EmpId__276EDEB3");
        });

        modelBuilder.Entity<EmployeeInfo>(entity =>
        {
            entity.HasKey(e => e.EmpId).HasName("PK__Employee__AF2DBB999AF706FC");

            entity.ToTable("Employee_Info");

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.MobNo)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.Role).WithMany(p => p.EmployeeInfos)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Employee___RoleI__3E52440B");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__UserRole__8AFACE1A871455A0");

            entity.ToTable("UserRole");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<WorkExperience>(entity =>
        {
            entity.HasKey(e => e.Cid).HasName("PK__Work_Exp__C1F8DC39337AE378");

            entity.ToTable("Work_Experience");

            entity.Property(e => e.Cid).HasColumnName("CId");
            entity.Property(e => e.ApproveStatus)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasDefaultValueSql("('pending')");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Designation)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.FromDate).HasColumnType("datetime");
            entity.Property(e => e.IsActive)
                .IsRequired()
                .HasDefaultValueSql("((1))");
            entity.Property(e => e.Technology)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ToDate).HasColumnType("datetime");

            entity.HasOne(d => d.Emp).WithMany(p => p.WorkExperiences)
                .HasForeignKey(d => d.EmpId)
                .HasConstraintName("FK__Work_Expe__EmpId__2B3F6F97");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
