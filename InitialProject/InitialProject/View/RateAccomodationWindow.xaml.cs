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
<<<<<<<< HEAD:InitialProject/InitialProject/View/TouristCouponsWindow.xaml.cs
    public partial class TouristCouponsWindow : Page
========
    /// <summary>
    /// Interaction logic for RateAccomodationWindow.xaml
    /// </summary>
    public partial class RateAccomodationWindow : Window
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RateAccomodationWindow.xaml.cs
    {
        public RateAccomodationWindow()
        {
            InitializeComponent();
<<<<<<<< HEAD:InitialProject/InitialProject/View/TouristCouponsWindow.xaml.cs
            TouristCouponsViewModel viewModel = new TouristCouponsViewModel();
            /*
            DataContext = viewModel;*/
========
            AccomodationRatingViewModel viewModel = new AccomodationRatingViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
>>>>>>>> origin/OwnerGuest:InitialProject/InitialProject/View/RateAccomodationWindow.xaml.cs
        }

    }
}
