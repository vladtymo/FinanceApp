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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WalletWindow.Themes;
using System.Net;
using Newtonsoft.Json;

namespace WalletWindow
{
    public partial class MainWindow : Window
    {
        const string LINK = "https://api.privatbank.ua/p24api/pubinfo?json&exchange&coursid=5";
        public string CurrentDate { get; set; }
        public string CurrentCurrency { get; set; }

        private DispatcherTimer timer;
        double panelWidth;
        bool hidden;
        public MainWindow()
        {
            InitializeComponent();

            using (WebClient client = new WebClient())
            {
                var json = client.DownloadString(LINK);
                var result = JsonConvert.DeserializeObject<List<ExchangeRate>>(json);
                CurrentCurrency = result[0].sale;
            }

            CurrentDate = DateTime.Now.ToShortDateString().ToString();

            this.DataContext = this;

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 10);
            timer.Tick += Timer_Tick;

            panelWidth = sidePanel.Width;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (hidden)
            {
                sidePanel.Width += 5;
                if (sidePanel.Width >= panelWidth)
                {
                    timer.Stop();
                    hidden = false;
                }
            }
            else
            {
                sidePanel.Width -= 5;
                if (sidePanel.Width <= 45)
                {
                    timer.Stop();
                    hidden = true;
                }
            }
        }

        private void btnClickMenu(object sender, RoutedEventArgs e)
        {
            timer.Start();
        }

        private void PanelHeader_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void btnChangeTheme(object sender, RoutedEventArgs e)
        {
            PageTheme pageTheme = new PageTheme();
            pageTheme.Show();
        }

        private void btnClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
