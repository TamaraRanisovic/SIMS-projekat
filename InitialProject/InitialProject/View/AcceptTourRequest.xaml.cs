using InitialProject.Migrations;
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
using WebApi.Entities;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AcceptTourRequest.xaml
    /// </summary>
    public partial class AcceptTourRequest : Window
    {
        TourRequestRepository repository = new TourRequestRepository();

        public AcceptTourRequest()
        {
            InitializeComponent();
            TourRequests.ItemsSource = repository.GetAll();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string language = Language.Text;
            TourRequests.ItemsSource = repository.GetAllByLanguage(language);
        }

        private void Language_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Country_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Location location = new Location(City.Text, Country.Text);

            TourRequests.ItemsSource = repository.GetAllByLocation(location);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            int num = int.Parse(Number.Text);
            TourRequests.ItemsSource = repository.GetAllByNumOfTourists(num);

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            var list = repository.GetAll();
            var output = new List<TourRequest>();
            foreach (var item in list)
            {
                if(item.StartDate >= DateTime.Parse(StartDate.Text) && item.StartDate < DateTime.Parse(EndDate.Text))
                {   
                    output.Add(item);
                }
            }

            TourRequests.ItemsSource = output;
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            TourRequests.ItemsSource = repository.GetAll();
        }

        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            var item = TourRequests.SelectedItem as TourRequest;
            if (item.RequestStatus != RequestStatus.Pending)
            { 
                MessageBox.Show("zahtev je vec prihvacen");
            }
            else
            {
                CreateTourBasedOnRequest createTourBasedOnRequest = new CreateTourBasedOnRequest(item);
                createTourBasedOnRequest.Show();
                Close();
            }

        }

        private void home_Click(object sender, RoutedEventArgs e)
        {
            GuideWindow guideWindow = new GuideWindow();
            guideWindow.Show();
            Close();
        }
    }
}
