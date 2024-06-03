using FAIS.ApplicationCore.Entities.Structure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace FAIS.ApplicationCore.Configuration
{
    public class EmployeeEntityConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            if (builder == null)
                throw new ArgumentNullException(nameof(builder));

            builder.ToView("FAIS_EMPLOYEE_VIEW");

            builder.HasNoKey();

            builder.Property(e => e.EmployeeNumber)
                .HasColumnName("EMPNO");

            builder.Property(e => e.FirstName)
                .HasColumnName("FIRSTNAME");

            builder.Property(e => e.MiddleName)
                .HasColumnName("MIDDLENAME");

            builder.Property(e => e.LastName)
                .HasColumnName("LASTNAME");

            builder.Property(e => e.Position)
                .HasColumnName("POSITION");

            builder.Property(e => e.Jg)
                .HasColumnName("JG");

            builder.Property(e => e.ChargingMC)
                .HasColumnName("CHARGING_MC");

            builder.Property(e => e.EmailAddress)
                .HasColumnName("TRANSCO_EMAILADD");

            builder.Property(e => e.MobileNumber)
                .HasColumnName("CELLNO");

            builder.Property(e => e.EmployeeStatus)
                .HasColumnName("EMPSTATUS");

            builder.Property(e => e.ApplicationStatus)
                .HasColumnName("APPSTATUS");
        }
    }
}
