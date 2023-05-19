using InitialProject.Commands;
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
using System.Windows;
using System.Windows.Input;
using WebApi.Entities;

namespace InitialProject.ViewModel
{
    public class ShowTourViewModel : BindableBase
    {
        public TourDTO tourDTO;

        public ShowTourViewModel()
        {
            
        }
        public ShowTourViewModel(TourDTO tourDTO)
        {
            TourDTO = tourDTO;
        }

        public TourDTO TourDTO
        {
            get { return tourDTO; }
            set
            {
                tourDTO = value;
                RaisePropertyChanged(nameof(TourDTO));
            }
        }

 

    }
}
