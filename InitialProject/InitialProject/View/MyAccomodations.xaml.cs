using InitialProject.Model;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for MyAccomodations.xaml
    /// </summary>
    public partial class MyAccomodations : Window
    {
        public MyAccomodations()
        {
            InitializeComponent();
        }

        private List<Accomodation> accomodations = new List<Accomodation>();

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Home homeWindow = new Home();
            homeWindow.Show();
            Close();
        }

        private void AddAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            AddAccommodation addAccommodationWindow = new AddAccommodation();
            addAccommodationWindow.Show();
            Close();
        }

        private void StatisticsButton_Click(object sender, RoutedEventArgs e)
        {
            StatisticsWindow statisticsWindow = new StatisticsWindow();
            statisticsWindow.Show();
            Close();
        }

        

        private void SuggestionsButton_Click(object sender, RoutedEventArgs e)
        {
           Suggestions suggestionsWindow = new Suggestions();
            suggestionsWindow.Show();
            Close();
        }

        private void ReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            Reservations reservationsWindow = new Reservations();
            reservationsWindow.Show();
            Close();
        }

        private void ShowAccommodationsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowAccomodations showAccommodationsWindow = new ShowAccomodations(accomodations);
            showAccommodationsWindow.Show();
        }

    }
}
