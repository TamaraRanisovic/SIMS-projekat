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
    /// Interaction logic for RenovataionTest.xaml
    /// </summary>
    public partial class RenovationTest : Window
    {

        public AccomodationRepository accomodationRepository = new AccomodationRepository();
        public AccomodationService accomodationService = new AccomodationService();
        public RenovationService renovationService = new RenovationService();
        public RenovationTest()
        {
            InitializeComponent();
            accomodations.ItemsSource = accomodationRepository.GetAllAccomodations();
        }

        private void duration_days_TextChanged(object sender, TextChangedEventArgs e)
        {
            dateSuggestions.ItemsSource = new List<DateSuggestion>();

            if (startDate.SelectedDate.HasValue && endDate.SelectedDate.HasValue)
            {
                DateTime desiredStart = startDate.SelectedDate.Value;
                DateTime desiredEnd = endDate.SelectedDate.Value;

                if (!duration_days.Text.Equals(""))
                {
                    TimeSpan duration = new System.TimeSpan(Convert.ToInt32(duration_days.Text), 0, 0, 0);
                    Accomodation selectedAccommodation = accomodations.SelectedItem as Accomodation;

                    dateSuggestions.ItemsSource = accomodationService.GetRenovationDateSuggestions(selectedAccommodation, desiredStart, desiredEnd, duration);
                }
            }
            else
            {

                MessageBox.Show("Niste izabrali datum!");
            }
        }


        private void rescheduleButton_Click(object sender, RoutedEventArgs e)
        {
            DateSuggestion chosenDate = dateSuggestions.SelectedItem as DateSuggestion;

            Accomodation selectedAccommodation = accomodations.SelectedItem as Accomodation;


            TimeSpan duration = new System.TimeSpan(Convert.ToInt32(duration_days.Text), 0, 0, 0);

            if (chosenDate != null)
            {

                renovationService.Save(selectedAccommodation, chosenDate, description.Text, duration);
            }
            else
            {
                MessageBox.Show("Niste izabrali datum!");
            }
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Renovations renovationsWindow = new Renovations();
            renovationsWindow.Show();
            Close();
        }
    }
}
