using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketerStats.Data
{
    public class OneDayStats
    {
        [Key]
        public int OneDayInt { get; set; }

        [ForeignKey (nameof(Cricketer))]
        public int CricketerId { get; set; }

        public virtual Cricketers Cricketer { get; set; }

        [Required]
        public int WicketOneDayInt { get; set; }

        [Required]
        public int CenturyOneDayInt { get; set; }

        [Required]
        public int HatrickOneDayInt { get; set; }


    }
}
