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
using WalletWindow.Themes;

namespace WalletWindow
{
    /// <summary>
    /// Interaction logic for PageTheme.xaml
    /// </summary>
    public partial class PageTheme : Window
    {
        public PageTheme()
        {
            InitializeComponent();
        }

        private void btnClickDone(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void ChangeTheme(object sender, RoutedEventArgs e)
        {
            switch (int.Parse(((RadioButton)sender).Uid))
            {
                case 0: ThemesController.SetTheme(ThemesController.ThemeTypes.Light); break;
                case 1: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulLight); break;
                case 2: ThemesController.SetTheme(ThemesController.ThemeTypes.Dark); break;
                case 3: ThemesController.SetTheme(ThemesController.ThemeTypes.ColourfulDark); break;
            }
            e.Handled = true;

            // this.Close();
        }
    }
}
