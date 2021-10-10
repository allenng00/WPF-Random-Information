using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InspirationalQuotes
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string[] _quotes = new string[]
        {
            "Quote (1).jpg",
            "Quote (2).jpg",
            "Quote (3).jpg",
            "Quote (4).jpg",
            "Quote (5).jpg",
            "Quote (6).jpg",
            "Quote (7).jpg",
            "Quote (8).jpg",
            "Quote (9).jpg",
            "Quote (10).jpg", 
            "Quote (11).jpg",
            "Quote (12).jpg",
            "Quote (13).jpg",
            "Quote (14).jpg",
            "Quote (15).jpg",
            "Quote (16).jpg",
            "Quote (17).jpg",
            "Quote (18).jpg",
            "Quote (19).jpg",
            "Quote (20).jpg"
        };
        private Random _rng = new Random();
        private System.Timers.Timer _timer;

        public MainWindow()
        {
            InitializeComponent();
            ChangeQuote(0);
            _timer = new System.Timers.Timer(3000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(
            object sender, 
            ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() =>
            {
                ChangeQuote(1);
            });
        }

        private void infoButton_Click(
            object sender, 
            RoutedEventArgs e)
        {
            _timer.Stop();
            ChangeQuote(1);
            _timer.Start();
        }

        private void ChangeQuote(int index = 0)
        {
            if (index != 0)
            {
                index = _rng.Next(_quotes.Length);
            }

            var bitmap =
                new BitmapImage(
                    new Uri(
                        $"Images/{_quotes[index]}",
                        UriKind.Relative)
                    );
            quoteImage.Source = bitmap;
        }
    }
}
