using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelsFluentApiAnnotationApp
{
    public class Position
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        List<Employee> Employees { get; set; } = new();
    }
}
