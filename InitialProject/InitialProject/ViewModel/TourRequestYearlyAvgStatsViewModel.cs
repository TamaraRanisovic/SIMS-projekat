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
    public class TourRequestYearlyAvgStatsViewModel : BindableBase
    {
        private double avgNumOfTourists;
        private int year;
        public string isStatisticsVisible;
        public ICommand ShowCommand { get; set; }

        public TourRequestYearlyAvgStatsViewModel()
        {
            ShowCommand = new DelegateCommand(Show, CanShow);
            IsStatisticsVisible = "Hidden";
        }

        public double AvgNumOfTourists
        {
            get { return avgNumOfTourists; }
            set
            {
                avgNumOfTourists = value;
                RaisePropertyChanged(nameof(AvgNumOfTourists));
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
            GetAvgNumOfTourists();
            IsStatisticsVisible = "Visible";
        }

        public void GetAvgNumOfTourists()
        {
            if (UserSession.LoggedInUser != null)
            {
                TourRequestStatisticsService tourRequestStatisticsService = new TourRequestStatisticsService();
                AvgNumOfTourists = tourRequestStatisticsService.GetAvgNumOfTouristsByYear(UserSession.LoggedInUser.Id, Year);
            }
        }
    }
}
