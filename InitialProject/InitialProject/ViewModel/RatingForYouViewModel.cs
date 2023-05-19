using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
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
    public class RatingForYouViewModel : INotifyPropertyChanged
    {
        private int accId;
        private int cleanliness;
        private int ruleCompliance;
        private string comment;
        private GuestRating guestRating;

        public ICommand RatingForYouCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public RatingForYouViewModel()
        {
            RatingForYouCommand = new DelegateCommand(ShowRating);
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

        public int Cleanliness
        {
            get { return cleanliness; }
            set
            {
                cleanliness = value;
                RaisePropertyChanged(nameof(Cleanliness));
            }
        }

        public int RuleCompliance
        {
            get { return ruleCompliance; }
            set
            {
                ruleCompliance = value;
                RaisePropertyChanged(nameof(RuleCompliance));
            }
        }

        public string Comment
        {
            get { return comment; }
            set
            {
                comment = value;
                RaisePropertyChanged(nameof(Comment));
            }
        }

        public GuestRating GuestRating
        {
            get { return guestRating; }
            set
            {
                guestRating = value;
                RaisePropertyChanged(nameof(GuestRating));
            }
        }

        public void ShowRating()
        {
            AccomodationRatingRepository accomodationRatingRepository = new AccomodationRatingRepository();
            
            GuestRating = accomodationRatingRepository.PrikazOcenaOdVlasnika(AccId);

            Cleanliness = GuestRating.Cleanliness;
            RuleCompliance = GuestRating.RuleCompliance;
            Comment = GuestRating.Comment;

            MessageBox.Show("This is a rating for Guest!");
            return;
        }


        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
