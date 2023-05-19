using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using WebApi.Entities;
using static System.Net.Mime.MediaTypeNames;

namespace InitialProject.ViewModel
{
    public class TourRatingViewModel :  BindableBase
    {
        private string _tourName;

        private TourRatingDTO tourRatingDTO;

        public ICommand RateTourCommand { get; set; }

        public ICommand AddPhotoCommand { get; set; }

        public TourRatingViewModel()
        {
            RateTourCommand = new DelegateCommand(RateTour, CanRateTour);
            AddPhotoCommand = new DelegateCommand(AddPhoto);
            TourRatingDTO  = new TourRatingDTO();
        }

        public string TourName
        {
            get { return _tourName; }
            set
            {
                _tourName = value;
                RaisePropertyChanged(nameof(TourName));
            }
        }
            

        public TourRatingDTO TourRatingDTO
        {
            get { return tourRatingDTO; }
            set
            {
                tourRatingDTO = value;
                RaisePropertyChanged(nameof(TourRatingDTO));
            }
        }

 
        public bool CanRateTour()
        {
            if (TourRatingDTO.GuideKnowledge != null && TourRatingDTO.GuideLanguage != null && TourRatingDTO.TourAmusement != null && !string.IsNullOrEmpty(TourRatingDTO.Comment) && TourRatingDTO.TourImages.Count >= 1)
            {
                return true;
            }
            return false;
        }


        public void RateTour()
        {
            TourRatingService tourRatingService = new TourRatingService(new TourRatingRepository());
            TourService tourService = new TourService(new TourRepository());
            Tour ratedTour = tourService.GetByName(TourName);
            if (ratedTour == null)
            {
                MessageBox.Show("No such tour!");
                return;
            }
            if (CanTouristRate())
            {
                int guideKnowledge = GetIntFromString(TourRatingDTO.GuideKnowledge);
                int guideLanguage = GetIntFromString(TourRatingDTO.GuideLanguage);
                int tourAmusement = GetIntFromString(TourRatingDTO.TourAmusement);

                TourRating tourRating = new TourRating(guideKnowledge, guideLanguage, tourAmusement, TourRatingDTO.Comment, TourRatingDTO.TourImages);
                tourRatingService.Add(tourRating, UserSession.LoggedInUser.Id, ratedTour.TourId);
                TourRatingDTO.TourImages.Clear();
                MessageBox.Show("You successfully rated a tour!");
            } else
            {
                TourRatingDTO.TourImages.Clear();
                MessageBox.Show("You can't rate this tour.");
            }
        }

        public void AddPhoto()
        {
            TourImage tourImage = new TourImage(TourName, TourRatingDTO.PhotoURL);
            TourRatingDTO.TourImages.Add(tourImage);
            TourRatingDTO.PhotoURL = null;
            MessageBox.Show("You added an image!");
        }

        public bool CanTouristRate()
        {
            TourService tourService = new TourService(new TourRepository());
            Tour tour = tourService.GetByName(TourName);
            if (tour == null)
            {
                MessageBox.Show("No such tour!");
            }
            TouristService touristsService = new TouristService(new TouristRepository());
            return touristsService.CanTouristRate(UserSession.LoggedInUser.Id, tour);
        }

        public int GetIntFromString(string str)
        {
            int value;
            if (int.TryParse(Regex.Match(str, @"\d+").Value, out value))
            {
                return value;
            }

            return -1;
        }
    }
}
