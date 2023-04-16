using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class TourDateDTO
    {
        public int Id { get; set; }

        public string TourName { get; set; }
        
        public int DateId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public TourDateDTO() { }

        public TourDateDTO(string tourName, DateTime date, int dateId ,string description)
        {
            TourName = tourName;
            Date = date;
            DateId = dateId;
            Description = description;
        }
    }
}
