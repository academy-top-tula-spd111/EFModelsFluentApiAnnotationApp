using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFModelsFluentApiAnnotationApp.ModelConfiguration;

namespace EFModelsFluentApiAnnotationApp
{
    internal class ApplicationContext : DbContext
    {
        //public DbSet<Employee> Employees { get; set; } = null!;
        public DbSet<Employee> Employees => Set<Employee>();
        public DbSet<Company> Companies => Set<Company>();

        public DbSet<User> Users => Set<User>();
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { 

        }

        [Obsolete]
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<Company>();
            //modelBuilder.Ignore<Company>();

            //modelBuilder.Entity<Employee>().Ignore(e => e.BankAccount);
            //modelBuilder.Entity<Employee>().Property(e => e.Name).HasColumnName("BigName");

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());


            modelBuilder.Entity<Company>().HasData(
                new Company("Yandex"),
                new Company("Mail Group"),
                new Company("Ozon"),
                new Company("Avito"));



            modelBuilder.Entity<User>().Property("UserAge").HasField("_age");
            modelBuilder.Entity<User>().Property("_name").HasField("_name");

            modelBuilder.Entity<User>().ToTable("BankUsers");
            //modelBuilder.Entity<User>().HasKey(u => u.IdNumber);
            //modelBuilder.Entity<User>().HasKey(u => new {u.Number, u.Series});

            modelBuilder.Entity<User>().HasAlternateKey(u => u.Number).HasName("AlterKeyNumber");
            //modelBuilder.Entity<User>().Property(u => u.Id)
            modelBuilder.Entity<User>()
                        .Property(u => u.Activity).HasDefaultValue(true);



        }
    }
}
