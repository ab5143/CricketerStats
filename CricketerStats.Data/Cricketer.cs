using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketerStats.Data
{
    public class Cricketers
    {

        [Key]
        public int CricketerId { get; set; }


        [Required]
        public Guid UserId { get; set; }


        [Required]
        public string   Name { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public  int TotalRuns { get; set; }

       
    }
}
