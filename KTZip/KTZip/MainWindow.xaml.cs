using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

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
            restoreLastSesion();
        }

        private void restoreLastSesion()
        {
            return;
            throw new NotImplementedException();
        }
        #region Buttons
        private void button_Back_Click(object sender, RoutedEventArgs e)
        {
            OperationResult result = tryExecuteOperation("~`back`", false);
        }

        private void button_Up_Click(object sender, RoutedEventArgs e)
        {
            OperationResult result = tryExecuteOperation("~`up`", true);
        }

        private void button_Forward_Click(object sender, RoutedEventArgs e)
        {
            OperationResult result = tryExecuteOperation("~`forward`", false);
        }

        private void button_Repeat_Click(object sender, RoutedEventArgs e)
        {
            OperationResult result = tryExecuteOperation("~`refresh`", false);
        }
        #endregion

        private OperationResult tryExecuteOperation(string path, bool newHistoryEntry)
        {
            if (newHistoryEntry)
            {
                if (path == "~`up`")
                {

                }
            }
            else
            {
                if (path == "~`back`")
                {

                }
                else if (path == "~`forward`")
                {

                }
                else if (path == "~`refresh`")
                {

                }
            }

            return OperationResult.OperationDone;
        }

        #region TitleBar buttons
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
        #endregion

        #region ComboBox
        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var uri = new Uri(comboBox.Text);

            if (uri.IsUnc)
            {
                Console.WriteLine("Connects to host '{0}'", uri.Host);
            }
            else
            {

            }
        }

        private void comboBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                string path = comboBox.Text;
                determineOperation(path);
            }
        }

        private OperatioType determineOperation(string path)
        {
            try
            {
                var uri = new Uri(path);
                if (uri.IsUnc)
                {
                    Console.WriteLine("Connects to host '{0}'", uri.Host);
                    return OperatioType.UNC;
                }
                else if (uri.IsFile)
                {
                    Console.WriteLine(uri);
                    return OperatioType.File;
                }
                else //URL
                {
                    if (path.StartsWith("http:"))
                    {
                        return OperatioType.Http;
                    }
                    else if (path.StartsWith("ftp:"))
                    {
                        return OperatioType.Ftp;
                    }
                    else if (path.StartsWith("https:"))
                    {
                        return OperatioType.Https;
                    }
                    else
                    {
                        MessageBox.Show("Ten protokuł nie jest jeszcze obsługiwany");
                        return OperatioType.unknown;
                    }
                }
            }
            catch (UriFormatException)
            {
                string websitePattern = @"^(www)?[^.](.)[^.](([-.\w]*[0-9a-zA-Z])+(:(0-9)*)*(\/?)([a-zA-Z0-9\-\.\?\,\'\/\\\+&amp;%\$#_]*))[^.](.)[^.]([a-zA-Z0-9]+)$";
                Regex reg = new Regex(websitePattern, RegexOptions.Compiled | RegexOptions.IgnoreCase);
                if (reg.IsMatch(path))
                    return OperatioType.Http;
                else
                    return OperatioType.unknown;
            }
        }
        #endregion
    }
}
