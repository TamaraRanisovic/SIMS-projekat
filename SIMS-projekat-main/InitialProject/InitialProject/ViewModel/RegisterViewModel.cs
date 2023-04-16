using InitialProject.Commands;
using InitialProject.Model;
using InitialProject.Repository;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace InitialProject.ViewModel
{
    public class RegisterViewModel : INotifyPropertyChanged
    {
        private string _username;
        private string _password;
        private string _confirmPassword;
        private UserType _userType;
        private string _message;

        public event PropertyChangedEventHandler PropertyChanged;

        public DelegateCommand RegisterCommand { get; private set; }
        public DelegateCommand CancelCommand { get; private set; }

        public RegisterViewModel()
        {
            UserTypes = new ObservableCollection<UserType>(Enum.GetValues(typeof(UserType)).Cast<UserType>());
            RegisterCommand = new DelegateCommand(Register, CanRegister);
            CancelCommand = new DelegateCommand(Cancel);
        }
        public ObservableCollection<UserType> UserTypes { get; private set; }

        public string Username
        {
            get { return _username; }
            set { _username = value; RaisePropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get { return _confirmPassword; }
            set { _confirmPassword = value; RaisePropertyChanged(nameof(ConfirmPassword)); }
        }

        public UserType UserType
        {
            get { return _userType; }
            set { _userType = value; RaisePropertyChanged(nameof(UserType)); }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; RaisePropertyChanged(nameof(Message)); }
        }

        private bool CanRegister()
        {
            // Enable Register button only if all required fields are filled
            return !string.IsNullOrEmpty(Username) &&
                   !string.IsNullOrEmpty(Password) &&
                   !string.IsNullOrEmpty(ConfirmPassword) &&
                   UserType != null &&
                   Password == ConfirmPassword;
        }

        private void Register()
        {          

                User user = new User(Username, Password, UserType);
                UserRepository userRepository = new UserRepository();
                userRepository.AddUser(user);
                            
                MessageBox.Show("Registration successful!");
                CloseWindow();
                
        }
        private void Cancel()
        {
            CloseAction();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    if (window == Application.Current.MainWindow)
                    {
                        Application.Current.Shutdown();
                    }
                    else
                    {
                        window.Close();
                    }
                }
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }
    }
   
}
