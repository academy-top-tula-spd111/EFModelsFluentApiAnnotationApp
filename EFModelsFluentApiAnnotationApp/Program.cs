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

            //CreateFillDb();

            using (ApplicationContext context = new ApplicationContext(options))
            {
                // Lazy Loading





                //foreach (var user in context.Users.ToList())
                //    Console.WriteLine(user);

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

        static void ForeignKeyNavigationProp()
        {
            using (ApplicationContext context = new ApplicationContext(options))
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //List<Company> companies = new List<Company>()
                //{
                //    new("Yandex"),
                //    new("Mail Group"),
                //    new("Ozon")
                //};

                //List<Employee> employees = new List<Employee>()
                //{
                //    new("Bob", 27){ Company = companies[0] },
                //    new("Tim", 33){ Company = companies[1] },
                //    new("Joe", 21){ Company = companies[2] },
                //    new("Sam", 19){ Company = companies[0] },
                //    new("Leo", 43){ Company = companies[1] },
                //};

                //context.Companies.AddRange(companies);
                //context.Employees.AddRange(employees);

                //context.SaveChanges();

                ////Employee employee = new Employee("Bob", 34);
                ////context.Employees.Add(employee);
                ////employee = new Employee("Tim", 22);
                ////context.Employees.Add(employee);

                ////User user = new User("User1", 22) { Number = "12345" };
                ////context.Users.Add(user);
                ////user = new User("User2", 33) { Number = "55555" };
                ////context.Users.Add(user);



                //Employee employeBen = new("Ben", 27) { Company = companies[2] };

                //List<Employee> employeesAvito = new()
                //{
                //    new("Peet", 38),
                //    new("Philip", 24)
                //};

                //Company avito = new() { Title = "Avito", Employees = employeesAvito };

                //context.Employees.Add(employeBen);
                //context.Companies.Add(avito);

                //context.SaveChanges();

                //Employee employeeMike = new("Mike", 30) { CompanyId = 2 };
                //context.Employees.Add(employeeMike);
                //context.SaveChanges();

                //Employee employeeAnn = new("Ann", 24) { CompanyId = 1 };
                //context.Employees.Add(employeeAnn);
                //context.SaveChanges();


                //var ozon = context.Companies.Find(3);
                //if (ozon != null)
                //    context.Companies.Remove(ozon);
                //context.SaveChanges();


            }
        }

        static void CreateFillDb()
        {
            using (ApplicationContext context = new ApplicationContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                List<City> cities = new()
                {
                    new(){ Title = "Moscow" },
                    new(){ Title = "Benjng" },
                    new(){ Title = "Washington" },
                };

                List<Country> countries = new()
                {
                    new(){ Title = "Russia", Capital = cities[0] },
                    new(){ Title = "Usa", Capital = cities[2] },
                    new(){ Title = "China", Capital = cities[1] },
                };

                List<Company> companies = new()
                {
                    new(){ Title = "Yandex", Country = countries[0] },
                    new(){ Title = "Ozon", Country = countries[0] },
                    new(){ Title = "Mail Group", Country = countries[0] },
                    new(){ Title = "Google", Country = countries[1] },
                    new(){ Title = "Facebook", Country = countries[1] },
                    new(){ Title = "Hiaomy", Country = countries[2] },
                    new(){ Title = "ZTE", Country = countries[2] },
                };

                List<Position> positions = new()
                {
                    new() { Title = "Manager" },
                    new() { Title = "Developer" },
                    new() { Title = "Tester" },
                };

                List<Employee> employees = new()
                {
                    new("Bob", 23) { Company = companies[0], Position = positions[0] },
                    new("Joe", 23) { Company = companies[1], Position = positions[1] },
                    new("Sam", 23) { Company = companies[2], Position = positions[2] },
                    new("Tim", 23) { Company = companies[3], Position = positions[0] },
                    new("Bill", 23) { Company = companies[4], Position = positions[1] },
                    new("Jim", 23) { Company = companies[5], Position = positions[2] },
                    new("Tom", 23) { Company = companies[6], Position = positions[0] },
                    new("Ben", 23) { Company = companies[0], Position = positions[1] },
                    new("Leo", 23) { Company = companies[1], Position = positions[2] },
                    new("Max", 23) { Company = companies[2], Position = positions[0] },
                    new("Peet", 23) { Company = companies[3], Position = positions[1] },
                    new("Mike", 23) { Company = companies[4], Position = positions[2] },
                    new("Don", 23) { Company = companies[5], Position = positions[0] },
                    new("Nick", 23) { Company = companies[6], Position = positions[1] },
                };

                context.Countries.AddRange(countries);
                context.Companies.AddRange(companies);
                context.Employees.AddRange(employees);

                context.SaveChanges();
            }
        }

        static void EagerLoading()
        {
            // Eager loading - жадная загрузка

            //var companies = context.Companies.Where(c => c.Id == 1).ToList();
            //var employees = context.Employees
            //                       .Include(e => e.Company)
            //                       .ToList();
            //foreach(var employee in employees)
            //    Console.WriteLine($"{employee.Name} {employee?.Company?.Title}");


            //var companies = context.Companies
            //                       .Include(c => c.Employees)
            //                       .ToList();

            //foreach(var company in companies)
            //{
            //    Console.WriteLine(company.Title);
            //    foreach(var employee in company.Employees)
            //        Console.WriteLine($"\t{employee.Name}");
            //}

            //var employees = context.Employees
            //                        .Include(e => e.Company)
            //                            .ThenInclude(c => c.Country)
            //                        .ToList();

            //var employees = context.Employees
            //                        .Include(e => e.Company.Country)
            //                        .ToList();

            //foreach (var employee in employees)
            //    Console.WriteLine($"{employee.Name} {employee?.Company?.Title} {employee?.Company?.Country?.Title}");

            

            //var employees = context.Employees
            //                       .Include(e => e.Company)
            //                            .ThenInclude(c => c.Country)
            //                                .ThenInclude(cr => cr.Capital)
            //                       .Include(e => e.Position)
            //                       .ToList();
            //foreach (var employee in employees)
            //{
            //    Console.WriteLine($"Name: {employee.Name}");
            //    Console.WriteLine($"\tCompany: {employee.Company.Title} Position: {employee.Position.Title}");
            //    Console.WriteLine($"\t\t{employee.Company.Country.Title} {employee.Company.Country.Capital.Title}");
            //}
        }
        static void ExplicitLoading()
        {
            // Explicit Loading - явная загрузука

            Company? company = context.Companies.FirstOrDefault();
            if (company != null)
            {
                context.Entry(company).Collection(c => c.Employees).Load();
            }

            Console.WriteLine(company.Title);
            foreach (var e in company.Employees)
                Console.WriteLine($"\t{e.Name}");

            Employee? employee = context.Employees.FirstOrDefault();
            if (employee != null)
                context.Entry(employee).Reference(e => e.Company).Load();
            Console.WriteLine($"{employee.Name} {employee?.Company?.Title}");
        }
    }
}