using System.Collections.Generic;

namespace DapperMailings.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }
         
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
