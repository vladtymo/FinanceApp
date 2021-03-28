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
    public partial class RegisterAuthWindow : Window
    {
        private LoginAuthWindow windowLogin;
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

        private void btnRegisterClick(object sender, RoutedEventArgs e)
        {

        }
    }
}
