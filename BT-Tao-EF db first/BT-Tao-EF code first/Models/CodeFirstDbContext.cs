using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BT_Tao_EF_code_first.Models
{
    public class CodeFirstDbContext : DbContext
    {
        public CodeFirstDbContext(DbContextOptions options) : base(options)
        {
        }
        public virtual DbSet<Company> Companies { get; set; }

        public virtual DbSet<Department> Departments { get; set; }

        public virtual DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=PHUOC_HUAN;Initial Catalog=BT_Tao_EF_Code_F;Integrated Security=True;Trust Server Certificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Company__3213E83FA892E438");

                entity.ToTable("Company");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.Address)
                    .HasColumnType("text")
                    .HasColumnName("address");
                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Departme__3213E83F41D3CB4F");

                entity.ToTable("Department");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.CompanyId).HasColumnName("companyId");
                entity.Property(e => e.Description)
                    .HasColumnType("text")
                    .HasColumnName("description");
                entity.Property(e => e.Name)
                    .HasMaxLength(250)
                    .HasColumnName("name");
                entity.Property(e => e.StaffCount).HasColumnName("staffCount");

                entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__Departmen__compa__267ABA7A");
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Employee__3213E83F5308DE42");

                entity.ToTable("Employee");

                entity.Property(e => e.Id).HasColumnName("id");
                entity.Property(e => e.DateOfBirth).HasColumnName("dateOfBirth");
                entity.Property(e => e.DepartmentId).HasColumnName("departmentId");
                entity.Property(e => e.Fullname)
                    .HasMaxLength(250)
                    .HasColumnName("fullname");

                entity.HasOne(d => d.Department).WithMany(p => p.Employees)
                    .HasForeignKey(d => d.DepartmentId)
                    .HasConstraintName("FK__Employee__depart__29572725");
            });

        }

    }
}
