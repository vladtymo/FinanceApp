﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Client.Commands;
using ServerTypes;

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

        private Commands.Command loginRequestCommand;

        public System.Windows.Input.ICommand LoginRequestCommand => loginRequestCommand;

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
            ClientConnection.Connect("127.0.0.1", 20444);

            CommandResult res = ClientConnection.Send(new LoginCommand(), new object[] { Login, Password});

            MessageBox.Show(res.Result.ToString());

            LoginStatus = true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
