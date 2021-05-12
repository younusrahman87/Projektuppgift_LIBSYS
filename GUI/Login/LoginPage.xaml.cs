using GUI.Home;
using GUI.Models;
using System;
using System.Collections.Generic;
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
using Logic;

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private dynamic _loginService;
        string search_text = "Skriv title, författare eller annat sökord";

        public LoginPage()
        {

            InitializeComponent();
            this.tbUsernam.Focus();
            searchbox.Text = search_text;


        }




        private void Shoutdown_BT_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new HomePage());

        }

        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {
            if (SearchDetailsFount.Visibility == Visibility.Collapsed) { SearchDetailsFount.Visibility = Visibility.Visible; logoimage.Visibility = Visibility.Collapsed; }
            else { SearchDetailsFount.Visibility = Visibility.Collapsed; logoimage.Visibility = Visibility.Visible; }

            

        }

        private void SearchBox_GotFocus(object sender, RoutedEventArgs e)
        {
            if (searchbox.Text == search_text) searchbox.Text = string.Empty; return;

            searchbox.Text = search_text;
        }

        private void searchBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (searchbox.Text == string.Empty) searchbox.Text = search_text; return;


        }


    }
}
    

