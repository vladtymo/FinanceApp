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
        public LoginAuthWindow()
        {
            InitializeComponent();
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

        }
    }
}
