using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
            Task task = ConnectToDBAsyct();
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
        private async Task ConnectToDBAsyct()
        {
            TaskScheduler scheduler = new MyTaskScheduler();
            TaskFactory factory = new TaskFactory(scheduler);
            await factory.StartNew(ConnectToDB);
        }
    }
}
