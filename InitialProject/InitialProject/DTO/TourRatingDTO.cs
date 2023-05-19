using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.DTO
{
    public class TourRatingDTO : INotifyPropertyChanged
    {
        public string guideKnowledge;

        public string guideLanguage;

        public string tourAmusement;

        public string comment;

        public string photoURL;

        public List<TourImage> tourImages { get; set; }


        public event PropertyChangedEventHandler PropertyChanged;

        public TourRatingDTO()
        {
            TourImages = new List<TourImage>();

        }

        public TourRatingDTO(string guideKnowledge, string guideLanguage, string tourAmusement, string comment)
        {
            this.guideKnowledge = guideKnowledge;
            this.guideLanguage = guideLanguage;
            this.tourAmusement = tourAmusement;
            this.comment = comment;
            TourImages = new List<TourImage>();

        }

        public string GuideKnowledge
        {
            get { return guideKnowledge; }
            set { guideKnowledge = value; RaisePropertyChanged(nameof(GuideKnowledge)); }
        }

        public string GuideLanguage
        {
            get { return guideLanguage; }
            set
            {
                guideLanguage = value;
                RaisePropertyChanged(nameof(GuideLanguage));
            }
        }

        public string TourAmusement
        {
            get { return tourAmusement; }
            set
            {
                tourAmusement = value;
                RaisePropertyChanged(nameof(TourAmusement));
            }
        }
        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        public string PhotoURL
        {
            get { return photoURL; }
            set
            {
                photoURL = value;
                RaisePropertyChanged(nameof(PhotoURL));
            }
        }

        public List<TourImage> TourImages
        {
            get { return tourImages; }
            set
            {
                tourImages = value;
                RaisePropertyChanged(nameof(TourImages));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
