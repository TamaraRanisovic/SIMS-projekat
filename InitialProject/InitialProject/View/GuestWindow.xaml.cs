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
    /// <summary>
    /// Interaction logic for GuestWindow.xaml
    /// </summary>
    public partial class GuestWindow : Window
    {
        public GuestWindow()
        {
            InitializeComponent();
            GuestViewModel viewModel = new GuestViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }
    }
}
