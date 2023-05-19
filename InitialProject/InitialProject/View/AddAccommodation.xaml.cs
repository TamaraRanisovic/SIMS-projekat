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
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
    /// Interaction logic for AddAccommodation.xaml
    /// </summary>
    public partial class AddAccommodation : Window
    {

        private List<Accomodation> accomodations = new List<Accomodation>();
        public AddAccommodation()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MyAccomodations myAccommodationsWindow = new MyAccomodations();
            myAccommodationsWindow.Show();
            Close();
        }


        private void AddAccommodationButton_Click(object sender, RoutedEventArgs e)
        {
            string name = NameTextBox.Text;
            AccomodationType accommodationType = (AccomodationType)Enum.Parse(typeof(AccomodationType), AccommodationTypeComboBox.Text); ;
            int maxGuests = int.Parse(MaxGuestsTextBox.Text);
            int minReservationDays = int.Parse(MinReservationDaysTextBox.Text);
            int daysBeforeCanceling = int.Parse(DaysBeforeCancelingTextBox.Text);
            string imageUrl = ImageUrlTextBox.Text;
            string imageName = ImageNameTextBox.Text;

            // Create an instance of AccomodationImage
            AccomodationImage accomodationImage = new AccomodationImage
            {
                URL = imageUrl,
                Name = imageName
            };

            // Create an instance of Accomodation
            Accomodation accomodation = new Accomodation
            {
                Name = name,
                AccomodationType = accommodationType,
                MaxGuests = maxGuests,
                MinReservationDays = minReservationDays,
                DaysBeforeCanceling = daysBeforeCanceling,
                Images = new List<AccomodationImage> { accomodationImage }
            };

            // Add the accomodation to your list or perform any other necessary actions
            accomodations.Add(accomodation);

            // Clear the textboxes
            NameTextBox.Clear();
            AccommodationTypeComboBox.SelectedIndex = -1;
            MaxGuestsTextBox.Clear();
            MinReservationDaysTextBox.Clear();
            DaysBeforeCancelingTextBox.Clear();
            ImageUrlTextBox.Clear();
            ImageNameTextBox.Clear();

            // Display a success message or navigate to another page, etc.
            MessageBox.Show("Accommodation added successfully!");

            ShowAccomodations showAccomodationsWindow = new ShowAccomodations(accomodations);
            showAccomodationsWindow.Show();
        }
    }
}
