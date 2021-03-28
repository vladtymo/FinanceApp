using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
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
    public partial class RegisterAuthWindow : Window
    {
        private LoginAuthWindow windowLogin;
        private UsersDb userDb = new UsersDb();
        public RegisterAuthWindow()
        {
            InitializeComponent();
        }

        // повертаємось назад до вікна Login
        private void btnGoBackClick(object sender, RoutedEventArgs e)
        {
            windowLogin = new LoginAuthWindow();
            this.Close();
            windowLogin.ShowDialog();
        }

        // НАЗВА БАЗИ ДАНИХ - UserDbFinanceApp
        private async void btnRegisterClick(object sender, RoutedEventArgs e)
        {
            string login = txtLogin.Text.Trim().ToLower();
            string pass = txtPassword.Password.Trim();

            if (login.Length < 5 || login == "")
            {
                txtLogin.ToolTip = "Error login";
                txtLogin.Background = Brushes.Gold;

                await Task.Delay(2000);

                txtLogin.Background = Brushes.Transparent;
            }
            else if (pass.Length < 5 || pass == "")
            {
                txtPassword.ToolTip = "Error";
                txtPassword.Background = Brushes.Gold;

                await Task.Delay(2000);

                txtPassword.Background = Brushes.Transparent;
            }
            else
            {
                //await Task.Run(() =>
                //{
                foreach (var item in userDb.GetAllUsers())
                {
                    if (login == item.Login)
                    {
                        MessageBox.Show("This login already exists");
                        return;
                    }
                }
                //});

                string passHash = ComputeSha256Hash(pass + " " + login);
                User user = new User() { Login = login, Password = passHash };
                userDb.AddUser(user);
                ChangeText(authorization);
            }
        }

        private async static void ChangeText(object obj, int delay = 4000)
        {
            var value = (TextBlock)obj;

            value.Text = "You have successfully created an account";
            value.Foreground = Brushes.Gold;
            await Task.Delay(delay);
            value.Text = "Authorization";
            value.Foreground = Brushes.Gray;
        }

        public string ComputeSha256Hash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

