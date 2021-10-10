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

namespace EnglishGame
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int Turn_MAX = 10;
        const int TimeRemain = 30;

        private Random _rng = new Random();
        private System.Timers.Timer _timer;
        private int _timeremain = TimeRemain;
        private Player _player = new Player();

        public MainWindow()
        {
            InitializeComponent();
            ShowQuestion();

            _timer = new System.Timers.Timer(1000);
            _timer.Elapsed += _timer_Elapsed;
            _timer.Start();
        }

        private void _timer_Elapsed(object sender, ElapsedEventArgs e)
        {

            Dispatcher.Invoke(() =>
            {
                this.Title = $"{_timeremain}";
            });

            _timeremain--;

            if (_timeremain == 0)
            {
                _timeremain = TimeRemain;

                if (_player.Turns > 0)
                {
                    _player.Turns--;
                    ShowQuestion();
                }
                else
                {
                    // End game and show Score
                    // Ask whether player want to continue or quit
                }

            }
            else
            {
                //Do nothing
            }
        }

        private void ShowQuestion()
        {

        }

        private void answer01Button_Click(object sender, RoutedEventArgs e)
        {
            _timer.Stop();
            //_timer.Start();
        }

        private void answer02Button_Click(object sender, RoutedEventArgs e)
        {
            //_timer.Stop();
            _timer.Start();
        }

    }
    class Player
    {
        private int _turns;
        private int _score;

        public int Turns
        {
            get => _turns;
            set => _turns = value;
        }

        public int Score
        {
            get => _score;
            set => _score = value;
        }

        public Player()
        {
            _turns = 10;
            _score = 0;
        }
    }
}
