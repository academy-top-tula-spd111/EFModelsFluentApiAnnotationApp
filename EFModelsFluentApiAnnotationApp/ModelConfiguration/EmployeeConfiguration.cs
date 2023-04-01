using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFModelsFluentApiAnnotationApp.ModelConfiguration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name)
                   .IsRequired();
            builder.HasIndex(e => new { e.Name, e.Age })
                   .HasDatabaseName("NameAgeMyIndex");
            builder.HasCheckConstraint("Age", "Age > 0 AND Age < 65");
        }
    }

}
