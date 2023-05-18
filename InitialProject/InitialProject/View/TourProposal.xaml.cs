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
    /// Interaction logic for TourProposal.xaml
    /// </summary>
    public partial class TourProposal : Window
    {
        public TourRequestService tourRequestService = new TourRequestService(new TourRequestRepository());
        public TourRequestRepository tourRequestRepository = new TourRequestRepository();
        public TourProposal()
        {
            InitializeComponent();
            data.ItemsSource = tourRequestService.GetAll();
        }

        private void language_TextChanged(object sender, TextChangedEventArgs e)
        {
            language.Text = tourRequestService.MostWantedLanguage();
        }

        private void location_TextChanged(object sender, TextChangedEventArgs e)
        {
            location.Text = tourRequestService.MostWantedLocation();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            data.ItemsSource = tourRequestRepository.GetAllByCity(location.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            data.ItemsSource = tourRequestRepository.GetAllByLanguage(language.Text);
        }

        private void AcceptRequest(object sender, RoutedEventArgs e)
        {
            var item = data.SelectedItem as TourRequest;
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
    }
}
