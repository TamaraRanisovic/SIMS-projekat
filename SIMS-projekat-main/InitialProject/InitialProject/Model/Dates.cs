using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Dates
    {
        [Key]
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public Dates() { }

        public Dates(DateTime date)
        {
            Date = date;
        }
    }
}
