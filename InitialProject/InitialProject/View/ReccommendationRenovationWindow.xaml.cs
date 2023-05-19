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

    public partial class ReccommendationRenovationWindow : Window
    { 
        public ReccommendationRenovationWindow()
        {
            InitializeComponent();

            ReccommendationRenovationViewModel viewModel = new ReccommendationRenovationViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

    }
}
