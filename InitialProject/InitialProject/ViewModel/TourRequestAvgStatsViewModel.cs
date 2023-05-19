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
    public class TourRequestAvgStatsViewModel : BindableBase
    {
        public ICommand NavigateToStats { get; set; }

        public TourRequestAvgStatsViewModel()
        {
            NavigateToStats = new DelegateCommand(ShowStats);
        }

        public void ShowStats(object destination)
        {
            TouristViewModel touristViewModel = TouristViewModel.Instance;

            switch ((string)destination)
            {
                case "allTime":
                    TourRequestAvfStatsAllTimeView allTimeStats = new TourRequestAvfStatsAllTimeView();
                    touristViewModel.NavService.Navigate(allTimeStats);
                    break;
                case "yearly":
                    TourRequestYearlyAvgStatsView yearlyStats = new TourRequestYearlyAvgStatsView();
                    touristViewModel.NavService.Navigate(yearlyStats);
                    break;
            }
        }
    }
}
