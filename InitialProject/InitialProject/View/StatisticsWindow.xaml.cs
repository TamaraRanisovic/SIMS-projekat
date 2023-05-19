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
    /// Interaction logic for Statistics.xaml
    /// </summary>
    public partial class StatisticsWindow : Window
    {

        AccomodationRepository accomodationRepository = new AccomodationRepository();
        AccomodationService accomodationService = new AccomodationService();
        public StatisticsWindow()
        {
            InitializeComponent();
            InitializeOwnersAccommodations();
        }

        public void InitializeOwnersAccommodations()
        {

            accomodations.ItemsSource = accomodationRepository.GetAllAccomodations();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MyAccomodations myAccommodationsWindow = new MyAccomodations();
            myAccommodationsWindow.Show();
            Close();
        }

        private void AnnualButton_Click(object sender, RoutedEventArgs e)
        {
            annualStatistics.ItemsSource = new List<Statistics>();
            monthlyStatistics.ItemsSource = new List<Statistics>();
            annualOccupancy.Text = "";
            monthlyOccupancy.Text = "";

            Accomodation selectedAccommodation = accomodations.SelectedItem as Accomodation;

            annualStatistics.ItemsSource = accomodationService.GetAnnualStatisticsBy(selectedAccommodation);
        }

        private void MonthlyButton_Click_1(object sender, RoutedEventArgs e)
        {
            Accomodation selectedAccommodation = accomodations.SelectedItem as Accomodation;

            Statistics selectedAnnualStatistics = annualStatistics.SelectedItem as Statistics;

            int selectedYear = Convert.ToInt32(selectedAnnualStatistics.TimePeriod);

            monthlyStatistics.ItemsSource = accomodationService.GetMonthsStatisticsBy(selectedYear, selectedAccommodation);

            DisplayMaxOccupancy();

        }

        private void DisplayMaxOccupancy()
        {

            double maxOccupancyYear = 0, maxOccupancyMonth = 0;
            string month = "", year = "";

            List<Statistics> monthStatistics = new List<Statistics>();
            List<Statistics> yearStatistics = new List<Statistics>();

            Accomodation selectedAccommodation = accomodations.SelectedItem as Accomodation;
            Statistics selectedAnnualStatistics = annualStatistics.SelectedItem as Statistics;

            int selectedYear = Convert.ToInt32(selectedAnnualStatistics.TimePeriod);

            yearStatistics = accomodationService.GetAnnualStatisticsBy(selectedAccommodation);
            monthStatistics = accomodationService.GetMonthsStatisticsBy(selectedYear, selectedAccommodation);


            foreach (var statistics in yearStatistics)
            {

                if (statistics.Occupancy > maxOccupancyYear)
                {

                    maxOccupancyYear = statistics.Occupancy;
                    year = statistics.TimePeriod;
                }
            }

            maxOccupancyMonth = 0;

            foreach (var statistics in monthStatistics)
            {

                if (statistics.Occupancy > maxOccupancyMonth)
                {

                    maxOccupancyMonth = statistics.Occupancy;
                    month = statistics.TimePeriod;
                }
            }

            annualOccupancy.Text = "  Max occupancy is " + maxOccupancyYear.ToString() + " %, in year: " + year;
            monthlyOccupancy.Text = "  Max occupancy is " + maxOccupancyMonth.ToString() + " %, in month: " + month;

        }
    }
}
