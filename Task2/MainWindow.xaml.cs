using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Task2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void infoBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Thread.Sleep(3000);
            infoBox.Text = "connect to database";
            Task task = ConnectToDBAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
        private void ConnectToDB()
        {
            infoBox.Text = "data received";
            Random random = new Random();
            infoBox.Foreground = new SolidColorBrush(Color.FromRgb((byte)random.Next(), (byte)random.Next(), (byte)random.Next()));
        }
        private async Task ConnectToDBAsync()
        {
            TaskScheduler scheduler = new MyTaskScheduler();
            TaskFactory factory = new TaskFactory(scheduler);
            await factory.StartNew(ConnectToDB);
        }
    }
}
