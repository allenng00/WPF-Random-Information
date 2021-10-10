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

namespace EnglishByImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region Attributes
        private string[] _images = new string[]
        {
            "Basket.jpg",
            "Cup.jpg",
            "Dog.jpg",
            "Happy.jpg",
            "KiwiFruit.jpg",
            "Lettuce.jpg",
            "Man.jpg",
            "Pea.jpg",
            "Rapper.jpg",
            "Red.jpg",
            "Showjumping.jpg",
            "Skirt.jpg",
            "Sky.jpg",
            "Snake.jpg",
            "Volleyball.jpg",
            "Water.jpg",
            "Watermelon.jpg"
        };
        private string[] _words = new string[]{
            "Basket\n/ˈbæs.kət/ (noun)\ncái rổ",
            "Cup\n/kʌp/ (noun)\nvật chứa, tách",
            "Dog\n/dɑːɡ/ (noun)\ncon chó",
            "Happy\n/ˈhæp.i/ (adj)\nvui vẻ, hạnh phúc",
            "Kiwi (fruit)\n/ˈki·wi (ˌfrut)/ (noun)\ntrái Kiwi",
            "Lettuce\n/ˈlet̬.ɪs/ (noun)\nrau diếp",
            "Man\n/mæn/ (noun)\nđàn ông, loài người",
            "Pea\n/piː/ (noun)\nđậu",
            "Rapper\n/ˈræp.ɚ/ (noun)\nngười biểu diễn hay nghệ sĩ nhạc Rap",
            "Red\n/red/ (noun)\nmàu đỏ",
            "Showjumping\n/ˈʃoʊˌdʒʌm.pɪŋ/ (noun)\n" +
                "môn (thể thao) cưỡi ngựa vượt chướng ngại vật",
            "Skirt\n/skɝːt/ (noun)\nváy ngắn",
            "Sky\n/skaɪ/ (noun)\nbầu trời",
            "Snake\n/sneɪk/ (noun)\ncon rắn",
            "Volleyball\n/ˈvɑː.li.bɑːl/ (noun)\nbóng chuyền",
            "Water\n/ˈwɑː.t̬ɚ/ (noun)\nnước",
            "Watermelo\n/ˈwɑː.t̬ɚˌmel.ən/ (noun)\n(quả) dưa hấu"
        };

        private Random _rng = new Random();
        private System.Timers.Timer _timer; 
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            ChangeWord(0);
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
                ChangeWord(1);
            });
        }

        private void infoButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            _timer.Stop();
            ChangeWord(1);
            _timer.Start();
        }


        private void ChangeWord(int index = 0)
        {
            if (index != 0)
            {
                index = _rng.Next(_images.Length);
            }

            var bitmap =
                new BitmapImage(
                    new Uri(
                        $"Images/{_images[index]}",
                        UriKind.Relative)
                    );

            volcabularyTextBlock.Text = _words[index];
            randomImage.Source = bitmap;
        }
    }
}
