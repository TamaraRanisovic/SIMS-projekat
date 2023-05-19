using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.ViewModel
{
    public class ShowTourRequestsViewModel : BindableBase
    {

        private ObservableCollection<TourRequestDTO> _tourRequests;

        public ShowTourRequestsViewModel()
        {
            LoadTourRequests();
        }

        public ObservableCollection<TourRequestDTO> TourRequests
        {
            get { return _tourRequests; }
            set
            {
                _tourRequests = value;
                RaisePropertyChanged(nameof(TourRequests));
            }
        }

        public void LoadTourRequests()
        {
            if (UserSession.LoggedInUser != null)
            {
                TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
                TourRequests = new ObservableCollection<TourRequestDTO>(tourRequestService.GetAllByTourist(UserSession.LoggedInUser.Id));
            }
        }
    }
}
