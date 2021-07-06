using System;

namespace DapperMailings.Models
{
    public class Promotion
    { 
        public int Id { get; set; } 
        public int Percent { get; set; } 
        public DateTime StartDate { get; set; } 
        public DateTime EndDate { get; set; }
        public int CountryId { get; set; }
        public Country Country { get; set; }
        public int ProducId { get; set; }
        public Product Product { get; set; }

        public override string ToString()
        {
            return $"{Percent} %\t{StartDate.ToShortDateString()}  {EndDate.ToShortDateString()}";
        }

    }
}
