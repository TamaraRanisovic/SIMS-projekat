using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialProject.ViewModel
{
    public class TourRequestAllTimeViewModel : BindableBase
    {
        private double acceptedRequests;
        private double unacceptedRequests;
        public TourRequestAllTimeViewModel()
        {
            GetAcceptanceRate();
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

        public void GetAcceptanceRate()
        {
            if (UserSession.LoggedInUser != null)
            {
                TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
                AcceptedRequests = tourRequestService.GetAcceptanceRate(UserSession.LoggedInUser.Id);
                UnacceptedRequests = 100 - AcceptedRequests;
            }
        }
    }
}
