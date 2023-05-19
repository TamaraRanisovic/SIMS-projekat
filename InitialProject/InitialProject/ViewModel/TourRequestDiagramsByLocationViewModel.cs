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
    public class TourRequestDiagramsByLocationViewModel : BindableBase
    {

        public Dictionary<string, double> tourRequestsByLocation;

        public TourRequestDiagramsByLocationViewModel()
        {
            LoadDiagramData();
        }

        public Dictionary<string, double> TourRequestsByLocation
        {
            get { return tourRequestsByLocation; }
            set
            {
                tourRequestsByLocation = value;
                RaisePropertyChanged(nameof(TourRequestsByLocation));
            }
        }

        public void LoadDiagramData()
        {
            TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
            if (UserSession.LoggedInUser != null)
            {
                TourRequestsByLocation = tourRequestService.CountByLocation(UserSession.LoggedInUser.Id);

            }
        }
    }
}
