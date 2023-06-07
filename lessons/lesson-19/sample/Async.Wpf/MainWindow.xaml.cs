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

namespace Async.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Service _service;

        public MainWindow()
        {
            InitializeComponent();

            _service = new Service();
        }

        private async void MainButton_Click(object sender, RoutedEventArgs e)
        {
            await _service.DoWork();
        }

        private async void MainButton2_Click(object sender, RoutedEventArgs e)
        {
            await _service.DoWorkAsync();
        }

        private async void MainButton1_Click(object sender, RoutedEventArgs e)
        {
            WriteToOutputAfter(100, "DoMoreSync");

            var count = (await _service.DoMoreWork()).Count();

            TxtDbl.Text += $"{count} ";
        }

        private async void MainButton3_Click(object sender, RoutedEventArgs e)
        {
            WriteToOutputAfter(100, "DoMoreAsync");

            var count = (await _service.DoMoreAsyncWork()).Count();

            TxtDbl.Text += $"{count} ";
        }

        private async void Window_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TxtDbl.Text += "X ";
        }

        private void WriteToOutputAfter(int ms, string text)
        {
            new DispatcherTimer(TimeSpan.FromMilliseconds(ms), DispatcherPriority.Send,
                (s, e) =>
                {
                    Console.WriteLine(text);
                    TxtDbl.Text += text + " ";
                    ((DispatcherTimer)s).Stop();
                }, Dispatcher).Start();
        }
    }
}
