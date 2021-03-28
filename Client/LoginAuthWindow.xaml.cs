using DAL;
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

namespace Client
{
    public partial class LoginAuthWindow : Window
    {
        private RegisterAuthWindow windowRegister;
        private UsersDb userDb;
        public LoginAuthWindow()
        {
            InitializeComponent();
            userDb = new UsersDb();
        }

        // переходимо до вікна Registration
        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            windowRegister = new RegisterAuthWindow();
            this.Close();
            windowRegister.ShowDialog();
        }

        private void btnLoginClick(object sender, RoutedEventArgs e)
        {
            windowRegister = new RegisterAuthWindow();

            string hash = txtPassword.Password + " " + txtLogin.Text;
            string passHash = windowRegister.ComputeSha256Hash(hash);
            windowRegister = null;

            foreach (var item in userDb.GetAllUsers())
            {
                if (txtLogin.Text == item.Login)
                {
                    if (item.Password == passHash)
                    {
                        MessageBox.Show("OPEN NEW WINDOW");

                        // OPEN MAIN WINDOW
                                                
                        return;
                    }
                    else
                    {
                        MessageBox.Show("Invalid login information");
                        return;
                    }
                }
            }
            MessageBox.Show("User does not exist");
        }
    }
}

