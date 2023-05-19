using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.DTO
{
    public class TourDateDTO
    {
        
        public int TourId { get; set; }
        public string TourName { get; set; }
        
        public int DateId { get; set; }

        public DateTime Date { get; set; }

        public string Description { get; set; }

        public TourDateDTO() { }

        public TourDateDTO(int tourId, string tourName, DateTime date, int dateId ,string description)
        {   
            TourId = tourId;
            TourName = tourName;
            Date = date;
            DateId = dateId;
            Description = description;
        }

        public TourDateDTO(Tour tour, Dates date)
        {
            TourId = tour.TourId;
            TourName = tour.Name;
            DateId = date.Id;
            Date = date.Date;
            Description = tour.Description;
        }
        
    }
}
