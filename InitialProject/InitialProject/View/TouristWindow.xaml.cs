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
    public partial class TouristWindow : Window
    {
        public TouristViewModel _ViewModel { get; set; }

        public TouristWindow()
        {
            InitializeComponent();
            this._ViewModel = TouristViewModel.Instance;
            this._ViewModel.NavService = this.frame.NavigationService;
            this._ViewModel.Frame = this.frame;

            this.DataContext = this._ViewModel;
        }

    }
}
