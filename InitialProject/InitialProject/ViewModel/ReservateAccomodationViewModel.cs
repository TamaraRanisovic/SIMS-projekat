using InitialProject.Commands;
using InitialProject.Controller;
using InitialProject.Model;
using InitialProject.Service;
using InitialProject.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class ReservateAccomodationViewModel : INotifyPropertyChanged
    {
        private int accId;
        private int guestId;
        private int numberOfGuests;
        private int accomodationId;
        private string username;
        private string password;
        private DateTime dateIn;
        private DateTime dateOut;

        public ICommand ReservateAccomodationCommand { get; set; }
        public ICommand HomeCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReservateAccomodationViewModel()
        {
            ReservateAccomodationCommand = new DelegateCommand(ReserveAccomodation);
            HomeCommand = new DelegateCommand(HomeBinding);
        }

        private void HomeBinding()
        {
            var guestWindow = new GuestWindow();
            guestWindow.Show();
        }

        public int AccId
        {
            get { return accId; }
            set
            {
                accId = value;
                RaisePropertyChanged(nameof(AccId));

            }
        }

        public int AccomodationId
        {
            get { return accomodationId; }
            set
            {
                accomodationId = value;
                RaisePropertyChanged(nameof(AccomodationId));
            }
        }

        public int GuestId
        {
            get { return guestId; }
            set
            {
                guestId = value;
                RaisePropertyChanged(nameof(GuestId));

            }
        }

        public int NumberOfGuests
        {
            get { return numberOfGuests; }
            set
            {
                numberOfGuests = value;
                RaisePropertyChanged(nameof(NumberOfGuests));

            }
        }

        public string Username
        {
            get { return username; }
            set
            {
                username = value;
                RaisePropertyChanged(nameof(Username));
            }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public DateTime DateIn
        {
            get { return dateIn; }
            set
            {
                dateIn = value;
                RaisePropertyChanged(nameof(DateIn));
            }
        }

        public DateTime DateOut
        {
            get { return dateOut; }
            set
            {
                dateOut = value;
                RaisePropertyChanged(nameof(DateOut));
            }
        }

        public void ReserveAccomodation()
        {
            UserService userService = new UserService();
            AccomodationService accomodationService = new AccomodationService();

            if(userService.Login(username,password) != null)
            {
                Guest guest = (Guest)userService.GetByUsername(username);

                accomodationService.MakeReservation(AccomodationId,GuestId,NumberOfGuests,DateIn,DateOut);
                MessageBox.Show("Succesfully reserved accomodation!");
            }

        }





        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
