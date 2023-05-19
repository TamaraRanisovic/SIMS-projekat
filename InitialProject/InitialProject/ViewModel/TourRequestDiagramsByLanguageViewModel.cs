using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace InitialProject.ViewModel
{
    public class TourRequestDiagramsByLanguageViewModel : BindableBase
    {

        public Dictionary<string, double> tourRequestsByLanguage;

        public TourRequestDiagramsByLanguageViewModel()
        {
            LoadDiagramData();
        }

        public Dictionary<string, double> TourRequestsByLanguage
        {
            get { return tourRequestsByLanguage; }
            set
            {
                tourRequestsByLanguage = value;
                RaisePropertyChanged(nameof(TourRequestsByLanguage));
            }
        }

        public void LoadDiagramData()
        {
            TourRequestStatisticsService tourRequestStatisticsService = new TourRequestStatisticsService();
            if (UserSession.LoggedInUser != null)
            {
                TourRequestsByLanguage = tourRequestStatisticsService.CountByLanguage(UserSession.LoggedInUser.Id);
            }
        }
    }
}
