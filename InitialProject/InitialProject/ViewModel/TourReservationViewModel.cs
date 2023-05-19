using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using InitialProject.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Navigation;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class TourReservationViewModel : BindableBase
    {
        private string _tourName;
        private int _tourists;
        private bool _isChangeEnabled;
        public NavigationService NavService { get; set; }

        public ICommand BookCommand { get; set; }
        public ICommand ChangeTouristsNumberCommand { get; set; }
        public ICommand ChooseTourCommand { get; set; }
        public ICommand CancelReservationCommand { get; set; }
        public ICommand NavigateToConfirmationWindowCommand { get; set; }
        public ICommand NavToShowTourRequestsPage { get; set; }

        public TourReservationViewModel(NavigationService navService)
        {
            BookCommand = new DelegateCommand(Book, CanBook);
            ChangeTouristsNumberCommand = new DelegateCommand(ChangeTouristsNumber, CanChange);
            ChooseTourCommand = new DelegateCommand(ChooseTour, CanChange);
            CancelReservationCommand = new DelegateCommand(CancelReservation, CanCancel);
            NavigateToConfirmationWindowCommand = new DelegateCommand(NavigateToConfirmationWindow);
            NavService = navService;
        }


        public string TourName
        {
            get { return _tourName; }
            set { _tourName = value; RaisePropertyChanged(nameof(TourName)); }
        }

        public int Tourists
        {
            get { return _tourists; }
            set
            {
                _tourists = value;
                RaisePropertyChanged(nameof(Tourists));
            }
        }

        public bool IsChangeEnabled
        {
            get { return _isChangeEnabled; }
            set
            {
                _isChangeEnabled = value;
                RaisePropertyChanged(nameof(IsChangeEnabled));
            }
        }

        public bool HasFreeSpots(string TourName, int Tourists)
        {
            TourService tourService = new TourService(new TourRepository());
            Tour tour = tourService.GetByName(TourName);

            if (tour == null)
            {
                return false;
            }

            if (tourService.GetFreeSpotsNumber(tour.TourId) < Tourists)
            {
                return false;
            }
            return true;
        }

        private bool CanBook()
        {
            return !string.IsNullOrWhiteSpace(TourName) && Tourists > 0;
        }

        private bool CanChange()
        {
            if (!HasFreeSpots(TourName, Tourists) && CanBook())
            {
                return true;
            }
            return false;
        }

        private void ChangeTouristsNumber()
        {
            Tourists = 0;
        }

        private void ChooseTour()
        {
            return;
        }

        private void CancelReservation()
        {
            var loginWindow = new LoginWindow();
            //CloseAction();
            loginWindow.Show();
        }

        private bool CanCancel()
        {
            if (CanChange())
            {
                return true;
            }
            return false;

        }

        private void Book()
        {
            if (HasFreeSpots(TourName, Tourists))
            {
                NavigateToConfirmationWindow();
            }
        }

        private void NavigateToConfirmationWindow()
        {
            ConfirmReservationViewModel confirmReservationViewModel = new ConfirmReservationViewModel();
            ConfirmReservationWindow confirmReservationWindow = new ConfirmReservationWindow();
            TouristViewModel touristViewModel = TouristViewModel.Instance;

            confirmReservationViewModel.TourName = TourName;
            confirmReservationViewModel.Tourists = Tourists;
            confirmReservationWindow.DataContext = confirmReservationViewModel;

            touristViewModel.NavService.Navigate(confirmReservationWindow);
        }

    }
}
