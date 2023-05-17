using InitialProject.Interfaces;
using InitialProject.Migrations;
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
using WebApi.Entities;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for TourRequestStat.xaml
    /// </summary>
    public partial class TourRequestStat : Window
    {
        public TourRequestService TourRequestService = new TourRequestService(new TourRequestRepository());
        public TourRequestRepository requestRepository = new TourRequestRepository();
        public TourRequestStat()
        {
            InitializeComponent();

            Zahtevi.ItemsSource = requestRepository.GetAll();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location(City.Text, Country.Text);

            Zahtevi.ItemsSource = requestRepository.GetAllByLocation(location);

            NumOfRequests.Text = (TourRequestService.Stat(requestRepository.GetAllByLocation(location))).ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string language = Language.Text;
            Zahtevi.ItemsSource = requestRepository.GetAllByLanguage(language);
            NumOfRequests.Text = (TourRequestService.Stat(requestRepository.GetAllByLanguage(language))).ToString();
            
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(Year.Text);
            Zahtevi.ItemsSource = requestRepository.GetAllByYear(year);
            NumOfRequests.Text = (TourRequestService.Stat(requestRepository.GetAllByYear(year))).ToString();
        }

        private void Language_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            int year = int.Parse(Year.Text);
            int month = int.Parse(Month.Text);
            Zahtevi.ItemsSource = requestRepository.GetAllByYearAndMonth(year, month);
            NumOfRequests.Text = (TourRequestService.RequestsByMonthsInAYearStat(requestRepository.GetAllByYearAndMonth(year, month), year, month)).ToString();
        }
    }
}