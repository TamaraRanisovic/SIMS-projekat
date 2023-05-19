using Accessibility;
using InitialProject.Commands;
using InitialProject.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class CancelReservationViewModel : INotifyPropertyChanged
    {
        private int idAcc;

        public ICommand CancelReservationCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;


        public CancelReservationViewModel() 
        {
            CancelReservationCommand = new DelegateCommand(CancelReservationn);
        }


        public int IdAcc
        {
            get { return idAcc; }
            set
            {
                idAcc = value;
                RaisePropertyChanged(nameof(IdAcc));
            }
        }

        public void CancelReservationn()
        {
            AccomodationService accomodationService = new AccomodationService();

            accomodationService.CancelReservation(IdAcc);
            MessageBox.Show("Succesfully removed accomodation reservation!");
            return;
        }

        public int GetIntFromString(string str)
        {
            int value;
            if (int.TryParse(Regex.Match(str, @"\d+").Value, out value))
            {
                return value;
            }

            return -1;
        }


        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
