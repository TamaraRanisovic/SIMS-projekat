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
    /// Interaction logic for ShowAccomodations.xaml
    /// </summary>
    public partial class ShowAccomodations : Window
    {

        public List<Accomodation> Accomodations { get; set; }
        public ShowAccomodations(List<Accomodation> accomodations)
        {
            InitializeComponent();


            Accomodations = accomodations;

            AccommodationsDataGrid.Items.Clear();
            AccommodationsDataGrid.ItemsSource = Accomodations;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            MyAccomodations myAccommodationsWindow = new MyAccomodations();
            myAccommodationsWindow.Show();
            Close();
        }
    }
}
