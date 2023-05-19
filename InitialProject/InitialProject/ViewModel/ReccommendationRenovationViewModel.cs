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
    public class ReccommendationRenovationViewModel : INotifyPropertyChanged
    {
        private int accId;
        private int rating;
        private string reccommendation;

       // private AccomodationReview accomodationReview;

        public ICommand ReccommendationForRenovationCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        public ReccommendationRenovationViewModel() 
        {
            ReccommendationForRenovationCommand = new DelegateCommand(ReccomendationRenovation);
        } 

        public int AccId
        {
            get { return accId; }
            set
            {
                accId = value;
                RaisePropertyChanged(nameof(accId));
            }
        }

        public int Rating
        {
            get { return rating; }
            set
            {
                rating = value;
                RaisePropertyChanged(nameof(rating));
            }
        }

        public string Reccommendation
        {
            get { return reccommendation; }
            set
            {
                reccommendation = value;
                RaisePropertyChanged(nameof(reccommendation));
            }
        }

        //public AccomodationReview AccomodationReview 
        //{
           // get { return accomodationReview; }
           // set
           // {
            //    accomodationReview = value;
           //     RaisePropertyChanged(nameof(AccomodationReview));
         //   }
       // }

        public void ReccomendationRenovation()
        {
            AccomodationReviewRepository accomodationReviewRepository = new AccomodationReviewRepository();

           accomodationReviewRepository.AddAccomodationReview(AccId,Rating, Reccommendation);
            MessageBox.Show("Succesfully added reccommendation renovation!");
            return;
        }



        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

    }
}
