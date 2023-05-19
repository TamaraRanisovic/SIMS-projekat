using InitialProject.Commands;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace InitialProject.ViewModel
{
    public class TouristViewModel : BindableBase
    {
        public NavigationService NavService { get; set; }
        public Frame Frame { get; set; }

        private static readonly Lazy<TouristViewModel> instance = new Lazy<TouristViewModel>(() => new TouristViewModel());

        public static TouristViewModel Instance => instance.Value;
        
        public ICommand NavigateToPage { get; set; }

        public TouristViewModel()
        {
            NavigateToPage = new DelegateCommand(Navigate);
        }

        private void Navigate(object destination)
        {
            switch((string)destination)
            {
                case "tourRating":
                    Page tourRating = new TourRatingWindow();
                    this.Frame.NavigationService.Navigate(tourRating);
                    break;
                case "bookTour":
                    Page tourReservation = new TourReservationWindow();
                    this.Frame.NavigationService.Navigate(tourReservation);
                    break;
                case "tourTracking":
                    Page tourTracking = new TrackTourWindow();
                    this.Frame.NavigationService.Navigate(tourTracking);
                    break;
                case "coupons":
                    Page showCoupons = new TouristCouponsWindow();
                    this.Frame.NavigationService.Navigate(showCoupons);
                    break;
                case "notifications":
                    Page notifications = new TouristNotificationsWindow();
                    this.Frame.NavigationService.Navigate(notifications);
                    break;
                case "requestTour":
                    Page tourRequest = new TourRequestWindow();
                    this.Frame.NavigationService.Navigate(tourRequest);
                    break;
                case "showTourRequests":
                    Page showTourRequests = new ShowTourRequestsWindow();
                    this.Frame.NavigationService.Navigate(showTourRequests);
                    break;
                case "requestStats":
                    Page tourRequestStatistics = new TourRequestStatisticsView();
                    this.Frame.NavigationService.Navigate(tourRequestStatistics);
                    break;
            }
            
        }
        
        public Action CloseAction { get; set; }

    }
}
