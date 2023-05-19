using InitialProject.ViewModel;
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
    /// Interaction logic for ReservateAccomodationWindow.xaml
    /// </summary>
    public partial class ReservateAccomodationWindow : Window
    {
        public ReservateAccomodationWindow()
        {
            InitializeComponent();
            ReservateAccomodationViewModel viewModel = new ReservateAccomodationViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }
    }
}
