using CricketerStats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketerStats.Models
{
    public class OneDayStatsCreate
    {

        //[Required]
        //[MinLength(1, ErrorMessage = "Please enter at least 2 characters.")]
        //[MaxLength(100, ErrorMessage = "There are too many characters in this field.")]

        public int WicketOneDayInt { get; set; }

        public int CenturyOneDayInt { get; set; }

        public int HatrickOneDayInt { get; set; }
        public int CricketerId { get; set; }
    }
}
