using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Entities;

namespace InitialProject.DTO
{
    public class TourDTO : INotifyPropertyChanged
    {
        public string tourName;
        public string language;
        public int duration;
        public int maxGuests;
        public string description;
        public string guideUsername;
        public string city;
        public string country;
        public ObservableCollection<Dates> dates;
        public ObservableCollection<string> imageUrls;

        public event PropertyChangedEventHandler PropertyChanged;

        public TourDTO(Tour tour, Location location, Guide guide, List<Dates> dates, List<string> imageUrls)
        {
            this.TourName = tour.Name;
            this.Language = tour.Language;
            this.Duration = tour.Duration;
            this.MaxGuests = tour.MaxGuests;
            this.Description = tour.Description;
            this.guideUsername = guide.Username;
            this.City = location.City;
            this.Country = location.Country;
            this.Dates = new ObservableCollection<Dates>(dates);
            this.ImageUrls = new ObservableCollection<string>(imageUrls);
        }

        public TourDTO()
        {

        }

        public string TourName
        {
            get { return tourName; }
            set
            {
                tourName = value;
                RaisePropertyChanged(nameof(TourName));
            }
        }

        public string Language
        {
            get { return language; }
            set
            {
                language = value;
                RaisePropertyChanged(nameof(Language));
            }
        }

        public int Duration
        {
            get { return duration; }
            set
            {
                duration = value;
                RaisePropertyChanged(nameof(Duration));
            }
        }
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                RaisePropertyChanged(nameof(Description));
            }
        }

        public int MaxGuests
        {
            get { return maxGuests; }
            set
            {
                maxGuests = value;
                RaisePropertyChanged(nameof(MaxGuests));
            }
        }

        public string GuideUsername
        {
            get { return guideUsername; }
            set
            {
                guideUsername = value;
                RaisePropertyChanged(nameof(GuideUsername));
            }
        }
        public string City
        {
            get { return city; }
            set
            {
                city = value;
                RaisePropertyChanged(nameof(City));
            }
        }
        public string Country
        {
            get { return country; }
            set
            {
                country = value;
                RaisePropertyChanged(nameof(Country));
            }
        }
        public ObservableCollection<Dates> Dates
        {
            get { return dates; }
            set
            {
                dates = value;
                RaisePropertyChanged(nameof(Dates));
            }
        }

        public ObservableCollection<string> ImageUrls
        {
            get { return imageUrls; }
            set
            {
                imageUrls = value;
                RaisePropertyChanged(nameof(ImageUrls));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
