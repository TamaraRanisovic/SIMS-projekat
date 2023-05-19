using InitialProject.Commands;
using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class TourRequestViewModel : BindableBase
    {

        private TourRequestDTO tourRequestDTO;
        private ObservableCollection<Guide> _guides;
        public Guide _selectedGuide;
        public ICommand RequestCommand { get; set; }

        public TourRequestViewModel()
        {
            RequestCommand = new DelegateCommand(Request, CanRequest);
            TourRequestDTO = new TourRequestDTO();
            TourRequestDTO.StartDate = DateTime.Now;
            TourRequestDTO.EndDate = DateTime.Now;
            LoadGuides();
        }

        public TourRequestDTO TourRequestDTO
        {
            get { return tourRequestDTO; }
            set
            {
                tourRequestDTO = value;
                RaisePropertyChanged(nameof(TourRequestDTO));
            }
        }

        public ObservableCollection<Guide> Guides
        {
            get { return _guides; }
            set
            {
                _guides = value;
                RaisePropertyChanged(nameof(Guides));
            }
        }
        public Guide SelectedGuide
        {
            get { return _selectedGuide; }
            set
            {
                _selectedGuide = value;
                RaisePropertyChanged(nameof(SelectedGuide));
            }
        }

        public bool CanRequest()
        {
            if (TourRequestDTO.City == null || TourRequestDTO.Country == null || TourRequestDTO.Language == null || TourRequestDTO.Tourists <= 0 || TourRequestDTO.Description == null || TourRequestDTO.StartDate < DateTime.Now || TourRequestDTO.EndDate < DateTime.Now || TourRequestDTO.EndDate < TourRequestDTO.StartDate)
            {
                return false;
            }
            return true;
        }

        public void Request()
        {
            TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
            TourRequest tourRequest = new TourRequest(TourRequestDTO.City, TourRequestDTO.Country, TourRequestDTO.Language, TourRequestDTO.Tourists, TourRequestDTO.Description, TourRequestDTO.StartDate, TourRequestDTO.EndDate);
            tourRequestService.Add(tourRequest, UserSession.LoggedInUser.Id, SelectedGuide.Id);
            MessageBox.Show("You successfully requested a tour!");
        }

        public void LoadGuides()
        {
            UserService userService = new UserService(new UserRepository());
            Guides = new ObservableCollection<Guide>(userService.GetAllGuides());
        }

    }
}
