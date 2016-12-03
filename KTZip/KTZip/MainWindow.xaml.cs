using System;
using System.Collections.ObjectModel;
using System.Drawing;
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
        public static bool supsuppressNextSelection = false;
        private static string currentPath = @"C:\";
        private ObservableCollection<FileObject> _FilesCollection;

        public ObservableCollection<FileObject> FilesCollection
        {
            get { return _FilesCollection; }
            set
            {
                if (_FilesCollection != value)
                {
                    _FilesCollection = value;
                    OnPropertyChanged();
                }
            }
        }

        private void OnPropertyChanged()
        {
            throw new NotImplementedException();
        }

        public MainWindow()
        {
            InitializeComponent();
            restoreLastSesion();
            //using (var secureString = "Some string to encrypt".ToSecureString())
            //{
            //    cypherText = secureString.EncryptString();
            //}

            //using (var secureString = cypherText.DecryptString())
            //{
            //    clearText = secureString.ToInsecureString();
            //}
            //list.ItemSource = lista;
            _FilesCollection = new ObservableCollection<FileObject>();
            listView.ItemsSource = FilesCollection;
            FilesCollection.Add(new FileObject("1", 0, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("2", 1, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("3", 2, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("4", 3, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("5", 4, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("6", 5, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            FilesCollection.Add(new FileObject("7", 6, DateTime.Now, true, new Icon(@"C:\Users\Konrad\Source\Repos\KTZip\KTZip\KTZip\Pictures\KTZLogoS.png.ico")));
            //ICollectionView view = CollectionViewSource.GetDefaultView(listView.ItemsSource);
            //view.Refresh();
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
        #region ListView
        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var list = e.AddedItems;
            if (!supsuppressNextSelection)
            {
                if (Keyboard.Modifiers != ModifierKeys.Control)
                {
                    listView.UnselectAll();
                    listView.SelectedItems.Add(list);
                    supsuppressNextSelection = true;
                }
            }
            supsuppressNextSelection = false;
        }

        private void listView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            //open
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (Keyboard.Modifiers == ModifierKeys.Control)
            {
                if (e.Key == Key.C)
                {
                    ContextPaste.IsEnabled = true;
                    MessageBox.Show("Copy");
                }
                else if (e.Key == Key.V)
                {
                    MessageBox.Show("Paste");
                }
                else if (e.Key == Key.X)
                {
                    ContextPaste.IsEnabled = true;
                    MessageBox.Show("Cut");
                }
                else if (e.Key == Key.F)
                {
                    MessageBox.Show("Search");
                }
            }
                
        }

        private void listView_DragEnter(object sender, DragEventArgs e)
        {
            Console.Out.WriteLine("Drag Enter");
        }

        private void listView_Drop(object sender, DragEventArgs e)
        {
            Console.Out.WriteLine("Drag drop");
        }

        private void listView_MouseDown(object sender, MouseButtonEventArgs e)
        {
            FileObject fo = ((ListViewItem)sender).Content as FileObject;
            if (Keyboard.Modifiers != ModifierKeys.Control || fo == null)
            {
                listView.UnselectAll();
            }
        }

        private void listView_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                string toSend = string.Empty;
                foreach (FileObject str in listView.SelectedItems)
                    toSend += str.fileName + "\n";
                //DragDrop.DoDragDrop(listView, toSend, DragDropEffects.Copy);
            }
        }
    }
    #endregion

}

