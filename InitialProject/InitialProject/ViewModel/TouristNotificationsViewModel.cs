using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class TouristNotificationsViewModel : BindableBase
    {
        private Tour tour;
        private string _tourName;
        private ObservableCollection<Tour> _newTours;
        private ObservableCollection<TouristNotification> _touristNotifications;
        private ObservableCollection<TourDateDTO> _acceptedTourRequests;

        TouristNotificationsService tourNotificationsService = new TouristNotificationsService(new TouristNotificationRepository());
        public ICommand ConfirmCommand { get; set; }
        public ICommand ShowCommand { get; set; }

        public TouristNotificationsViewModel()
        {
            LoadNotifications();
            ConfirmCommand = new DelegateCommand(Confirm);
            ShowCommand = new DelegateCommand(Show);

        }

        public string TourName
        {
            get { return _tourName; }
            set { _tourName = value; RaisePropertyChanged(nameof(TourName)); }
        }


        public ObservableCollection<TouristNotification> TouristNotifications
        {
            get { return _touristNotifications; }
            set
            {
                _touristNotifications = value;
                RaisePropertyChanged(nameof(TouristNotifications));
            }
        }

        public ObservableCollection<TourDateDTO> AcceptedTourRequests
        {
            get { return _acceptedTourRequests; }
            set
            {
                _acceptedTourRequests = value;
                RaisePropertyChanged(nameof(AcceptedTourRequests));
            }
        }
        public ObservableCollection<Tour> NewTours
        {
            get { return _newTours; }
            set
            {
                _newTours = value;
                RaisePropertyChanged(nameof(NewTours));
            }
        }
        public Tour Tour
        {
            get { return tour; }
            set
            {
                tour = value;
                RaisePropertyChanged(nameof(Tour));
            }
        }
        public void LoadNotifications()
        {
            if (UserSession.LoggedInUser != null)
            {
                TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());

                NewTours = new ObservableCollection<Tour>(tourRequestService.GetPartiallyAcceptedTours(UserSession.LoggedInUser.Id));
                TouristNotifications = new ObservableCollection<TouristNotification>(tourNotificationsService.GetByTourist(UserSession.LoggedInUser.Id));
                AcceptedTourRequests = new ObservableCollection<TourDateDTO>(tourRequestService.GetAcceptedToursByTourist(UserSession.LoggedInUser.Id));
            }
        }

        public List<string> GetImageUrls(List<TourImage> tourImages)
        {
            List<string> imageUrls = new List<string>();

            foreach (TourImage tourImage in tourImages)
            {
                imageUrls.Add(tourImage.URL);
            }

            return imageUrls;
        }

        public TourDTO GetTourDTO(Tour tour)
        {
            TourService tourService = new TourService(new TourRepository());
            TourImageService tourImageService = new TourImageService(new TourImageRepository());

            Location location = tourService.GetTourLocation(Tour.TourId);
            Guide guide = tourService.GetTourGuide(Tour.TourId);

            List<Dates> dates = tourService.GetTourDates(Tour.TourId);
            List<TourImage> tourImages = tourImageService.GetByTour(Tour.TourId);
            List<string> imageUrls = GetImageUrls(tourImages);

            TourDTO tourDTO = new TourDTO(tour, location, guide, dates, imageUrls);
            return tourDTO;
        } 

        public void Confirm(object parameter)
        {
            TouristNotification touristNotification = (TouristNotification)parameter;
            TourReservationService tourReservationService = new TourReservationService(new TourReservationRepository());
            TourService tourService = new TourService(new TourRepository());

            TourReservation tourReservation = tourReservationService.GetByNotification(touristNotification.Id);
            tourReservationService.UpdateAttendance(tourReservation.TourReservationId);
            Tour tour = tourService.GetByTourReservation(tourReservation.TourReservationId);
            tourNotificationsService.Delete(touristNotification);
            TouristNotifications = new ObservableCollection<TouristNotification>(tourNotificationsService.GetByTourist(UserSession.LoggedInUser.Id));
        }

        public void Show(object parameter)
        {
            TouristViewModel touristViewModel = TouristViewModel.Instance;
            ShowTourView showTourView = new ShowTourView();
            TourService tourService = new TourService(new TourRepository());

            Tour = tourService.GetByName((string)parameter);
            
            TourDTO tourDTO = GetTourDTO(Tour);

            ShowTourViewModel showTourViewModel = new ShowTourViewModel(tourDTO);
            showTourView.DataContext = showTourViewModel;
            touristViewModel.NavService.Navigate(showTourView);

        }

    }
}
