using InitialProject.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class Renovation
    {
        [Key]
        public int Id { get; set; }
        public Accomodation Accomodation { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public TimeSpan Duration { get; set; }
        public string Description { get; set; }

        public Renovation () { }

        public Renovation(DateTime start, DateTime end, TimeSpan duration, string description)
        {
            Start = start;
            End = end;
            Duration = duration;
            Description = description;
        }

        public Renovation (Accomodation accomodation, DateTime start, DateTime end, TimeSpan duration, string description)
        {
            Accomodation = accomodation;
            Start = start;
            End = end;
            Duration = duration; 
            Description = description;
        }

        public Renovation(RenovationDto renovation)
        {
            this.Id = renovation.Id;
            this.Start = renovation.Start;
            this.End = renovation.End;
            this.Description = renovation.Description;
            this.Duration = renovation.Duration;
        }


    }
}
