using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class TourRequestDTO : INotifyPropertyChanged
    {
        public string city;

        public string country;

        public string language;

        public int tourists;

        public string description;

        public DateTime startDate;

        public DateTime endDate;

        public RequestStatus requestStatus;

        public Guide guide;

        public event PropertyChangedEventHandler PropertyChanged;

        public TourRequestDTO() 
        {
            this.requestStatus = RequestStatus.Pending;
        }

        public TourRequestDTO(string city, string country, string language, int tourists, string description, DateTime startDate, DateTime endDate)
        {
            this.city = city;
            this.country = country;
            this.language = language;
            this.tourists = tourists;
            this.description = description;
            this.startDate = startDate;
            this.endDate = endDate;
            this.requestStatus = RequestStatus.Pending;
        }

        public TourRequestDTO(TourRequest tourRequest, Guide guide)
        {
            this.city = tourRequest.City;
            this.country = tourRequest.Country;
            this.language = tourRequest.Language;
            this.tourists = tourRequest.Tourists;
            this.description = tourRequest.Description;
            this.startDate = tourRequest.StartDate;
            this.endDate = tourRequest.EndDate;
            this.requestStatus = tourRequest.RequestStatus;
            this.guide = guide;
        }
        public string City
        {
            get { return city; }
            set { city = value; RaisePropertyChanged(nameof(City)); }
        }

        public string Country
        {
            get { return country; }
            set { country = value; RaisePropertyChanged(nameof(Country)); }
        }

        public string Language
        {
            get { return language; }
            set { language = value; RaisePropertyChanged(nameof(Language)); }
        }


        public int Tourists
        {
            get { return tourists; }
            set { tourists = value; RaisePropertyChanged(nameof(Tourists)); }
        }

        public string Description
        {
            get { return description; }
            set { description = value; RaisePropertyChanged(nameof(Description)); }
        }

        public DateTime StartDate
        {
            get { return startDate; }
            set { startDate = value; RaisePropertyChanged(nameof(StartDate)); }
        }

        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; RaisePropertyChanged(nameof(EndDate)); }
        }

        public RequestStatus RequestStatus
        {
            get { return requestStatus; }
            set { requestStatus = value; RaisePropertyChanged(nameof(RequestStatus)); }
        }


        public Guide Guide
        {
            get { return guide; }
            set { guide = value; RaisePropertyChanged(nameof(Guide)); }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
