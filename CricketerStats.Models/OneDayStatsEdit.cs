using CricketerStats.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CricketerStats.Models
{
    public class OneDayStatsEdit
    {

        public int WicketOneDayInt { get; set; }
             
        public int CenturyOneDayInt { get; set; }
                
        public int HatrickOneDayInt { get; set; }

        public int OneDayIntId { get; set; }

        [ForeignKey(nameof(Cricketer))]
        public int CricketerId { get; set; }

        public virtual Cricketer Cricketer { get; set; }
    }




}

