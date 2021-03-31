using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Commands;

namespace Client
{
    class LoginAuthViewModel : INotifyPropertyChanged
    {
        private string login;
        private string password;

        private bool loginStatus;
        public bool LoginStatus
        {
            get => loginStatus;

            set
            {
                if(loginStatus != value)
                {
                    loginStatus = value;

                    OnPropertyChanged();
                }
            }
        }

        public string Login
        {
            get => login;

            set
            {
                if (login != value)
                {
                    login = value;
                    OnPropertyChanged();
                }
            }
        }
        public string Password
        {
            get => password;

            set
            {
                if (password != value)
                {
                    password = value;
                    OnPropertyChanged();
                }
            }
        }

        private Command loginRequestCommand;

        public ICommand LoginRequestCommand => loginRequestCommand;

        public LoginAuthViewModel()
        {
            LoginStatus = false;

            loginRequestCommand = new DelegateCommand(() => LoginRequest(), () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password));

            PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == nameof(Login) || args.PropertyName == nameof(Password))
                {
                    loginRequestCommand.RaiseCanExecuteChanged();
                }           
            };
        }

        private void LoginRequest()
        {
            // TODO: Request to server...

            LoginStatus = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
