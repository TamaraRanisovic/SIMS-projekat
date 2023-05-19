using InitialProject.Commands;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class PercentageStatisticsViewModel
    {
        public ICommand NavigateToStats { get; set; }

        public PercentageStatisticsViewModel()
        {
            NavigateToStats = new DelegateCommand(ShowStats);
        }

        public void ShowStats(object destination)
        {
            TouristViewModel touristViewModel = TouristViewModel.Instance;

            switch ((string)destination)
            {
                case "allTime":
                        TourRequestAllTimeStatsView allTimeStats = new TourRequestAllTimeStatsView();
                        touristViewModel.NavService.Navigate(allTimeStats);
                    break;
                case "yearly":
                        TourRequestYearlyStatsView yearlyStats = new TourRequestYearlyStatsView();
                        touristViewModel.NavService.Navigate(yearlyStats);
                    break;
            }         
        }

    }
}
