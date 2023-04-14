using InitialProject.Model;
using InitialProject.ViewModel;
using System.Windows;

namespace InitialProject.View
{
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();

            LoginViewModel viewModel = new LoginViewModel();
            viewModel.CloseAction = Close;
            DataContext = viewModel;
        }

        private void txtPassword_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {

        }
    }
}
