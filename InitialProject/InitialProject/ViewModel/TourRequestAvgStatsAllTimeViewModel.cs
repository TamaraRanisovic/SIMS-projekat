using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class TourRequestAvgStatsAllTimeViewModel : BindableBase
    {

        private double avgNumOfTourists;

        public TourRequestAvgStatsAllTimeViewModel()
        {
            GetAvgNumOfTourists();
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

        public void GetAvgNumOfTourists()
        {
            if (UserSession.LoggedInUser != null)
            {
                TourRequestStatisticsService tourRequestStatisticsService = new TourRequestStatisticsService();
                AvgNumOfTourists = tourRequestStatisticsService.GetAvgNumOfTourists(UserSession.LoggedInUser.Id);
            }
        }


    }
}
