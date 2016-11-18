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

namespace KTZip
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

        private void button_Back_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Up_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Forward_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Repeat_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void button_Max_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Maximized)
                WindowState = WindowState.Normal;
            else
                WindowState = WindowState.Maximized;
        }

        private void button_Min_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }
    }
}
