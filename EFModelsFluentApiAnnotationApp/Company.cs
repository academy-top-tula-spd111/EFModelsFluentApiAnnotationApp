using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelsFluentApiAnnotationApp
{
    public class Company
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public List<Employee> Employees { get; set; } = new();
        public int CountryId { set; get; }
        public Country? Country { set; get; }
        public Company()
        {

        }
        public Company(string title)
        {
            Title = title;
        }
    }
}
