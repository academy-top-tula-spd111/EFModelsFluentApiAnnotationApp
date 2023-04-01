using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EFModelsFluentApiAnnotationApp
{
    internal class Program
    {
        static DbContextOptions<ApplicationContext> options = null!;
        static void Main(string[] args)
        {
            
            OnConfigUse();

            using(ApplicationContext context = new ApplicationContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                //Employee employee = new Employee("Bob", 34);
                //context.Employees.Add(employee);
                //employee = new Employee("Tim", 22);
                //context.Employees.Add(employee);

                User user = new User("User1", 22) { Number = "12345" };
                context.Users.Add(user);
                user = new User("User2", 33) { Number = "55555" };
                context.Users.Add(user);


                context.SaveChanges();
            }

            using (ApplicationContext context = new ApplicationContext(options))
            {
                foreach (var user in context.Users.ToList())
                    Console.WriteLine(user);

                //Console.WriteLine("Employees list:");
                //var employes = context.Employees.ToList();
                //foreach (var employee in employes)
                //{
                //    Console.WriteLine($"Name: {employee.Name}, age: {employee.Age}");
                //}
            }

        }

        static void OnConfigUse()
        {
            var builderConfig = new ConfigurationBuilder();
            builderConfig.SetBasePath(Directory.GetCurrentDirectory());
            builderConfig.AddJsonFile("appsettings.json");
            var config = builderConfig.Build();

            string? connectionString = config.GetConnectionString("DefaultConnection");
            options = new DbContextOptionsBuilder<ApplicationContext>().UseSqlServer(connectionString).Options;
        }
        static void EntityFrameworkCRUD()
        {
            //Create DB
            //using(ApplicationContext context = new())
            //{
            //    context.Database.EnsureDeleted();
            //    context.Database.EnsureCreated();

            //    Employee employee = new Employee() { Name = "Bob", Age = 34 };
            //    context.Employees.Add(employee);
            //    employee = new Employee() { Name = "Tim", Age = 22 };
            //    context.Employees.Add(employee);

            //    context.SaveChanges();
            //}

            // Read DB
            //using (ApplicationContext context = new())
            //{
            //    var employees = context.Employees;
            //    foreach(var employee in employees)
            //        Console.WriteLine($"Name: {employee.Name}, age: {employee.Age}");
            //}

            // Edit 
            //using (ApplicationContext context = new())
            //{
            //    Employee? employee = context.Employees.First(e => e.Age > 25);
            //    if(employee != null)
            //    {
            //        employee.Name = "Bobby";
            //        employee.Age++;
            //        context.SaveChanges();
            //    }
            //}

            // Delete
            //using (ApplicationContext context = new())
            //{
            //    Employee? employee = context.Employees.First(e => e.Age > 25);
            //    if (employee != null)
            //    {
            //        context.Remove(employee);
            //        context.SaveChanges();

            //        var employees = context.Employees;
            //        foreach (var e in employees)
            //            Console.WriteLine($"Name: {e.Name}, age: {e.Age}");
            //    }
            //}
        }
    }
}