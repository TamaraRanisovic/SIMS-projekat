using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.Model
{
    public class TourRequest
    {
        [Key]
        public int Id { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Language { get; set; }

        public int Tourists { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime RequestDate { get; set; }

        public RequestStatus RequestStatus { get; set; }

        public List<TouristNotification> Notifications { get; set; }

        public TourRequest()
        {
            this.RequestDate = DateTime.Now;
            this.RequestStatus = RequestStatus.Pending;
            Notifications = new List<TouristNotification>();

        }

        public TourRequest(string city, string country, string language, int tourists, string description, DateTime startDate, DateTime endDate)
        {
            this.City = city;
            this.Country = country;
            this.Language = language;
            this.Tourists = tourists;
            this.Description = description;
            this.StartDate = startDate;
            this.EndDate = endDate;
            this.RequestDate = DateTime.Now;
            this.RequestStatus = RequestStatus.Pending;
            Notifications = new List<TouristNotification>();

        }


    }
}
