using InitialProject.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace InitialProject.DTO
{
    public class RegisterDTO : INotifyPropertyChanged
    {
        private string username;
        private string password;
        private string confirmPassword;
        private UserType userType;
        private int age;

        public event PropertyChangedEventHandler PropertyChanged;

        public RegisterDTO()
        {
            
        }

        public string Username
        {
            get { return username; }
            set { username = value; RaisePropertyChanged(nameof(Username)); }
        }

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                RaisePropertyChanged(nameof(Password));
            }
        }

        public string ConfirmPassword
        {
            get { return confirmPassword; }
            set { confirmPassword = value; RaisePropertyChanged(nameof(ConfirmPassword)); }
        }

        public UserType UserType
        {
            get { return userType; }
            set { userType = value; RaisePropertyChanged(nameof(UserType)); }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                RaisePropertyChanged(nameof(Age));
            }
        }

        private void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
