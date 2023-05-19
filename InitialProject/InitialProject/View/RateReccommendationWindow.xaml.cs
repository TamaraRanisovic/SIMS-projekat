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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InitialProject.View
{
    /// <summary>
<<<<<<<< HEAD:InitialProject/InitialProject/View/ConfirmReservationWindow.xaml.cs
    /// Interaction logic for ConfirmReservationWindow.xaml
    /// </summary>
    public partial class ConfirmReservationWindow : Page
========
    /// Interaction logic for RateReccommendationWindow.xaml
    /// </summary>
    public partial class RateReccommendationWindow : Window
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RateReccommendationWindow.xaml.cs
    {
        public RateReccommendationWindow()
        {
            InitializeComponent();
<<<<<<<< HEAD:InitialProject/InitialProject/View/ConfirmReservationWindow.xaml.cs
            //DataContext = new ConfirmReservationViewModel();
========
            GuestViewModel viewModel = new GuestViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RateReccommendationWindow.xaml.cs
        }
    }
}
