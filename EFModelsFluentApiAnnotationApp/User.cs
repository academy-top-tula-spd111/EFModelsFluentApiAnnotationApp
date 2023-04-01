using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFModelsFluentApiAnnotationApp
{
    //[Table("GameUsers")]
    public class User
    {
        [Column("UserName")]
        string _name;
        
        int _age;
        
        //[Key]

        public Guid Id { get; set; }
        public string Number { set; get; }
        //public string UserName => _name;
        public int UserAge => _age;
        public bool Activity { set; get; }
        public User()
        {
            _name = "";
            _age = 0;
        }
        public User(string name, int age)
        {
            _name = name;
            _age = age;
        }

        public override string ToString()
        {
            return $"User name: {_name}, age: {_age}";
        }
    }
}
