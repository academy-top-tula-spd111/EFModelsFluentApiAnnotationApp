using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace EFModelsFluentApiAnnotationApp
{
    //[Index("Name")]
    public class Employee
    {
        public int Id { get; set; }

        
        [Required]
        public string? Name { get; set; }
        public int? Age { set; get; }
        //[ForeignKey("CompanyKey")]
        public Company? Company { set; get; }
        public int? CompanyId { set; get; }
        public Position Position { set; get; }
        public int PositionId { set; get; }


        //public string? CompanyTitle { set; get; }
        
        [NotMapped]
        public string? BankAccount { set; get; }

        public Employee(string name, int? age)
        {
            Name = name;
            Age = age;
            //Console.WriteLine($"Construct employee {name}, {age}");
        }
    }
}
