﻿using InitialProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InitialProject.View
{
    public partial class TourReservationWindow : Page
    {
        public TourReservationViewModel _ViewModel { get; set; }

        public TourReservationWindow()
        {
            InitializeComponent();
            this._ViewModel = new TourReservationViewModel(this.NavigationService);
            this.DataContext = this._ViewModel;
         //   DataContext = viewModel;*/
        }

    }
}
