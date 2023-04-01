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
        public int CompanyId { get; set; }
        public string Title { get; set; } = null!;

        public Company()
        {

        }
        public Company(string title)
        {
            Title = title;
        }
    }
}
