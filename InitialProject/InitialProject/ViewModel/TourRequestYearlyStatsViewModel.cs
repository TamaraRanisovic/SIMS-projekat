using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class TourRequestYearlyStatsViewModel : BindableBase
    {
        private double acceptedRequests;
        private double unacceptedRequests;
        private int year;
        private string isStatisticsVisible;
        public ICommand ShowCommand { get; set; }

        public TourRequestYearlyStatsViewModel()
        {
            ShowCommand = new DelegateCommand(Show, CanShow);
            IsStatisticsVisible = "Hidden";
        }

        public double AcceptedRequests
        {
            get { return acceptedRequests; }
            set
            {
                acceptedRequests = value;
                RaisePropertyChanged(nameof(AcceptedRequests));
            }
        }
        public double UnacceptedRequests
        {
            get { return unacceptedRequests; }
            set
            {
                unacceptedRequests = value;
                RaisePropertyChanged(nameof(UnacceptedRequests));
            }
        }

        public int Year
        {
            get { return year; }
            set
            {
                year = value;
                RaisePropertyChanged(nameof(Year));
            }
        }

        public string IsStatisticsVisible
        {
            get { return isStatisticsVisible; }
            set
            {
                isStatisticsVisible = value;
                RaisePropertyChanged(nameof(IsStatisticsVisible));
            }
        }

        public bool CanShow()
        {
            if (Year > 0)
            {
                return true;
            }
            return false;
        }

        public void Show()
        {
            GetAcceptanceRate();
            IsStatisticsVisible = "Visible";
        }
        public void GetAcceptanceRate()
        {
            TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
            double yearlyAcceptanceRate = tourRequestService.GetYearlyAcceptanceRate(UserSession.LoggedInUser.Id, year);
            if (yearlyAcceptanceRate == -1)
            {
                AcceptedRequests = 0;
                UnacceptedRequests = 0;
            } else
            {
                AcceptedRequests = yearlyAcceptanceRate;
                UnacceptedRequests = 100 - AcceptedRequests;
            }
            
        }
    }
}
