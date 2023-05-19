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
    /// Interaction logic for Reservations.xaml
    /// </summary>
    public partial class Reservations : Window
    {
        public Reservations()
        {
            InitializeComponent();
        }

        private void ShowReservationsButton_Click(object sender, RoutedEventArgs e)
        {
            ShowReservations showReservationsWindow = new ShowReservations();
            showReservationsWindow.Show();
            Close();
        }

        private void RescheduleRequestsButton_Click(object sender, RoutedEventArgs e)
        {
            ReschedulingRequests reschedulingRequestsWindow = new ReschedulingRequests();
            reschedulingRequestsWindow.Show();
            Close();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MyAccomodations myAccommodationsWindow = new MyAccomodations();
            myAccommodationsWindow.Show();
            Close();
        }
    }
}
