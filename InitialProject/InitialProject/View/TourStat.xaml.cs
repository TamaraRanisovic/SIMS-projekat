﻿using InitialProject.DTO;
using InitialProject.Model;
using InitialProject.Repository;
using InitialProject.Service;
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
    /// Interaction logic for TourStat.xaml
    /// </summary>
    public partial class TourStat : Window
    {
        public TourStat()
        {
            InitializeComponent();
        }

        private void FinishedTours_Click(object sender, RoutedEventArgs e)
        {

            TourStatService tourStatService = new TourStatService();


                List<TourDateDTO> tourDateDTO = tourStatService.FinishedTours();

                ListOfTours.ItemsSource = tourDateDTO;
            
        }

        private void MostVisited_Click(object sender, RoutedEventArgs e)
        {   
            
            MostVisited mostVisited = new MostVisited();
            mostVisited.Show();
            Close();
        }

       

        private void GuestStat_Click(object sender, RoutedEventArgs e)
        {
            GuestStat guestStat = new GuestStat();
            guestStat.Show();
            Close();
        }

        private void ShowReview_Click(object sender, RoutedEventArgs e)
        {   
            int dateId = Int32.Parse(DateToReview.Text);
            ReviewView reviewView = new ReviewView(dateId);
            reviewView.Show();
            Close ();
        }
    }
}
