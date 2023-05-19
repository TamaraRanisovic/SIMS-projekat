using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace InitialProject.ViewModel
{
    public class AccomodationRatingViewModel : INotifyPropertyChanged
    {
        //POLJA PLUS EVENT

        private int accId;
        private int ownerId;
        private int cleanliness;
        private int ownerFriendliness;
        private int idComment;
        private string commentText;
        private int idImage;
        private string imageName;
        private string imageURL;
        private DateTime dateUGone;


        public ICommand RateAccomodationCommand { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        //KONSTRUKTOR
        public AccomodationRatingViewModel()
        {
            RateAccomodationCommand = new DelegateCommand(RateAccomodation);
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

        public int OwnerId
        {
            get { return ownerId; }
            set
            {
                ownerId = value;
                RaisePropertyChanged(nameof(OwnerId));

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

        public int OwnerFriendliness
        {
            get { return ownerFriendliness; }
            set
            {
                ownerFriendliness = value;
                RaisePropertyChanged(nameof(OwnerFriendliness));

            }
        }

        public string CommentText
        {
            get { return commentText; }
            set
            {
                commentText = value;
                RaisePropertyChanged(nameof(CommentText));
            }
        }

        public int IdComment
        {
            get { return idComment; }
            set
            {
                idComment = value;
                RaisePropertyChanged(nameof(IdComment));
                
            }
        }

        public int IdImage
        {
            get { return idImage; }
            set
            {
                idImage = value;
                RaisePropertyChanged(nameof(IdImage));

            }
        }

        public string ImageName
        {
            get { return imageName; }
            set
            {
                imageName = value;
                RaisePropertyChanged(nameof(ImageName));
            }
        }

        public string ImageURL
        {
            get { return imageURL; }
            set
            {
                imageURL = value;
                RaisePropertyChanged(nameof(ImageURL));
            }
        }

        public DateTime DateUGone
        {
            get { return dateUGone; }
            set
            {
                dateUGone = value;
                RaisePropertyChanged(nameof(DateUGone));
            }
        }

        // GLAVNA FUNKCIJA (LOGIKA KAO U CONTROLLERU)
        public void RateAccomodation()
        {
            AccomodationRatingRepository accomodationRatingRepository = new AccomodationRatingRepository();
            
        accomodationRatingRepository.AddAccomodationRating(AccId, OwnerId, Cleanliness, OwnerFriendliness, IdComment, CommentText, IdImage, ImageName, ImageURL, DateUGone);
        MessageBox.Show("Succesfully added Rating for Accomodation!");
        return;
        }

        //RAISE CHANGE i CLOSE
        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }


    }
}
