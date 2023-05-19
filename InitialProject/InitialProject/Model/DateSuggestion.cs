using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class DateSuggestion
    {
        public DateTime Start {  get; set; }
        public DateTime End { get; set; }

        public DateSuggestion (DateTime start, DateTime end)
        {
             Start = start;
             End = end;
        }
    }
}
