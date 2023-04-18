using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class TrackTourViewModel : INotifyPropertyChanged
    {

        private string _tourName;

        public ICommand ConfirmCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public TrackTourViewModel()
        {
            ConfirmCommand = new DelegateCommand(Confirm, CanConfirm);

        }
        public string TourName
        {
            get { return _tourName; }
            set { _tourName = value; RaisePropertyChanged(nameof(TourName)); }
        }

        public bool CanConfirm()
        {
            return !string.IsNullOrEmpty(TourName);
        }

        public bool IsTourActive(Tour tour)
        {
            CheckpointService checkpointService = new CheckpointService();
            TourService tourService = new TourService();
            List<Checkpoint> checkpoints = checkpointService.GetTourCheckpoints(tour.TourId);
            int falseCheckpoints = tourService.CountFalseCheckpoints(tour);
            int markedCheckpoints = tourService.CountMarkedCheckpoints(tour);
            if (checkpoints.Count == falseCheckpoints)
            {
                return false;
            }
            if (checkpoints.Count == markedCheckpoints)
            {
                return false;
            }
            return true;
        }

        private void Confirm()
        {
            TourRepository tourRepository = new TourRepository();
            Tour tour = tourRepository.GetByName(TourName);
            if (tour  != null)
            {
                if (IsTourActive(tour) == false)
                {
                    MessageBox.Show("Tour isn't active.");
                    return;
                }
                if (CanTouristTrack())
                {
                    TourAttendanceWindow tourAttendanceWindow = new TourAttendanceWindow();
                    TourAttendanceViewModel tourAttendanceViewModel = (TourAttendanceViewModel)tourAttendanceWindow.DataContext;
                    tourAttendanceViewModel.TourName = this.TourName;
                    tourAttendanceWindow.Show();
                } else
                {
                    MessageBox.Show("You can't track this tour");
                }
            } else
            {
                MessageBox.Show("Tour doesn't exist.");
            }
        }

        public bool CanTouristTrack()
        {
            TourRepository tourRepository = new TourRepository();
            Tour tour = tourRepository.GetByName(TourName);
            if (tour == null)
            {
                MessageBox.Show("No such tour!");
            }
            TourReservationService tourReservationService = new TourReservationService();
            List<TourReservation> touristReservations = tourReservationService.GetByTourist(UserSession.LoggedInUser.Id);
            List<TourReservation> tourReservations = tourReservationService.GetByTour(tour);

            foreach (TourReservation tourReservation in tourReservations)
            {
                foreach (TourReservation touristReservation in touristReservations)
                {
                    if (tourReservation.TourReservationId == touristReservation.TourReservationId)
                    {

                        return true;
                    }
                }
            }
            return false;
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public Action CloseAction { get; set; }
    }
}
