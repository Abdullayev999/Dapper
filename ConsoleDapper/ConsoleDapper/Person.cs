using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDapper
{
    public class Person
    {
        public int Id { get; set; } 
        public string FullName { get; set; }
        public int Age { get; set; }
        public Department Department { get; set; }
        public int DepartmentId { get; set; }
        public override string ToString()
        {
            return $"{Id}\t{FullName.PadRight(19,' ')} {Age}";
        }
    }
}
