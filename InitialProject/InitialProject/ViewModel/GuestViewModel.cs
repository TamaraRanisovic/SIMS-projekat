using InitialProject.Commands;
using InitialProject.View;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class GuestViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //public ICommand ShowCouponsCommand {get; set;}

        //HOME WINDOWI
        public ICommand HomeCommand { get; set; }
        public ICommand ShowAccomodationCommand { get; set; }
        public ICommand RateReccommendationCommand { get; set; }
        public ICommand ReservateCancelCommand { get; set; }


        // PRAVE FUNKCIJE
        public ICommand ReservateAccomodationCommand { get; set; }
        public ICommand CancelReservationCommand { get; set; }
        public ICommand RateAccomodationCommand { get; set; }
        public ICommand ReccommendationForRenovationCommand { get; set; }
        public ICommand RatingForYouCommand { get; set; }



        public GuestViewModel()
        {
            ShowAccomodationCommand = new DelegateCommand(ShowAccomodations);
            ReservateAccomodationCommand = new DelegateCommand(BookAccommodation);
            CancelReservationCommand = new DelegateCommand(CancelReservation);
            RateAccomodationCommand = new DelegateCommand(RateAccAndOwner);
            ReccommendationForRenovationCommand = new DelegateCommand(Reccommendation);
            ReservateCancelCommand = new DelegateCommand(ReservateCancel);
            HomeCommand = new DelegateCommand(HomeBinding);
            RateReccommendationCommand = new DelegateCommand(RateReccommendation);
            RatingForYouCommand = new DelegateCommand(ShowYourRate);
        }

        private void ShowAccomodations()
        {
            var showAccomodationWindow = new ShowAccomodationsWindow();
            showAccomodationWindow.ShowDialog();
        }

        private void HomeBinding()
        {
            var guestWindow = new GuestWindow();
            guestWindow.Show();
        }

        private void BookAccommodation()
        {
            var reservateAccomodationWindow = new ReservateAccomodationWindow();
            reservateAccomodationWindow.ShowDialog();
        }

        private void CancelReservation()
        {
            var cancelReservateWindow = new CancelReservateWindow();
            cancelReservateWindow.ShowDialog();
        }

        private void RateAccAndOwner()
        {
            var rateAccomodationWindow = new RateAccomodationWindow();
            rateAccomodationWindow.ShowDialog();
        }

        private void Reccommendation()
        {
            var reccommendationForRenovationWindow = new ReccommendationRenovationWindow();
            reccommendationForRenovationWindow.ShowDialog();
        }

        private void ReservateCancel()
        {
            var reservateCancel = new ReservateCancelWindow();
            reservateCancel.ShowDialog();
        }

        private void RateReccommendation()
        {
            var rateReccommendation = new RateReccommendationWindow();
            rateReccommendation.ShowDialog();
        }

        private void ShowYourRate()
        {
            var ratingForYou = new RatingForYou();
            ratingForYou.ShowDialog();
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
}
