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
    public class TourRequestStatisticsViewModel : BindableBase
    {
        public ICommand NavigateToStatsPage { get; set; }

        public TourRequestStatisticsViewModel()
        {
            NavigateToStatsPage = new DelegateCommand(ShowStats);
        }

        public void ShowStats(object destination)
        {
            TouristViewModel touristViewModel = TouristViewModel.Instance;
            switch ((string)destination)
            {
                case "percentage":
                    PercentageStatisticsView percentageView = new PercentageStatisticsView();
                    touristViewModel.NavService.Navigate(percentageView);
                    break;
                case "diagrams":
                    TourRequestDiagramsView diagramsView = new TourRequestDiagramsView();
                    touristViewModel.NavService.Navigate(diagramsView);
                    break;
                case "avgStats":
                    TourRequestAvgsStatsView avgsStatsViewModel = new TourRequestAvgsStatsView();
                    touristViewModel.NavService.Navigate(avgsStatsViewModel);
                    break;
            }
        }
    }
}
