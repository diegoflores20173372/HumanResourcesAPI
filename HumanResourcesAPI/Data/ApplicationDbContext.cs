using HumanResourcesAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumanResourcesAPI.Data
{
    public class ApplicationDbContext: DbContext
    {

        public DbSet<EmployeeFamiliar> EmployeeFamiliars { get; set; }
        public DbSet<Employee> Employees { get; set; }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Creación de entidades a tablas
            modelBuilder.Entity<EmployeeFamiliar>().ToTable("employee_familiar");
            modelBuilder.Entity<Employee>().ToTable("employee");

            // Creación PKs
            modelBuilder.Entity<EmployeeFamiliar>().HasKey(ef => ef.Id).HasName("PK_EmployeeFamiliar");
            modelBuilder.Entity<Employee>().HasKey(emp => emp.Id).HasName("PK_Employee");

            // Creación de FKs
            modelBuilder.Entity<EmployeeFamiliar>().HasOne<Employee>().WithMany().HasPrincipalKey(emp => emp.Id).HasForeignKey(ef => ef.IdEmployee)
                .OnDelete(DeleteBehavior.NoAction).HasConstraintName("FK_Employee_EmployeeFamiliar");


        }

    }
}
