using Client.Commands;
using ServerTypes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Client
{
    class RegisterAuthViewModel : INotifyPropertyChanged
    {
        private string login;
        private string password;
        private string name;
        private string surname;
        private string email;

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

        public string Name
        {
            get => name;

            set
            {
                if (name != value)
                {
                    name = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Surname
        {
            get => surname;

            set
            {
                if (surname != value)
                {
                    surname = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Email
        {
            get => email;

            set
            {
                if (email != value)
                {
                    email = value;

                    OnPropertyChanged();
                }
            }
        }

        public System.Windows.Input.ICommand RegisterRequestCommand => registerRequestCommand;

        private Command registerRequestCommand;

        public RegisterAuthViewModel()
        {
            registerRequestCommand = new DelegateCommand(() => RegisterRequest(), () => !string.IsNullOrEmpty(Login) && !string.IsNullOrEmpty(Password) &&
                                                                                        !string.IsNullOrEmpty(Name)  && !string.IsNullOrEmpty(Surname)  &&
                                                                                        !string.IsNullOrEmpty(Email));

            PropertyChanged += (sender, args) =>
            {
                registerRequestCommand.RaiseCanExecuteChanged();
            };
        }

        public void RegisterRequest()
        {
            // [0] - Login; [1] - Password; [2] - Email; [3] - Name; [4] - Suranme;

            ClientConnection.Connect("127.0.0.1", 20444);

            ClientConnection.Send(new RegisterCommand(), new object[] { Login, Password, Email, Name, Surname});

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
