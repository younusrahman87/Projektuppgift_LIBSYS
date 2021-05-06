using GUI.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {


        public SearchWindow()
        {

            InitializeComponent();


        }




        private void BT_goBack_Click(object sender, RoutedEventArgs e)
        {
            var win = Application.Current.MainWindow;
            win.Show();
            this.Close();

        }

        private void cb_borrowed_book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
