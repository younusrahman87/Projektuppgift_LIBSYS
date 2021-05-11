using GUI.Login;
using GUI.Staff;
using GUI.Pages;
using System;
using System.Collections.Generic;
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
using GUI.Admin;

namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {
        string search_text = "Skriv title, författare eller annat sökord";
        string Bt_name_bok = "Böcker";
        string Bt_name_user = "Användare";




        public HomePage()
        {


            InitializeComponent();
            searchbox.Text = search_text;

        }

        private void MenuBT_Click(object sender, RoutedEventArgs e)
        {

            Button Converted_to_Bt = sender as Button;

            if(Converted_to_Bt.Content.Equals(Bt_name_bok))
            {
                Usermenu.Visibility = Visibility.Collapsed;
                if (Bookmenu.Visibility == Visibility.Visible) { Bookmenu.Visibility = Visibility.Collapsed; return; }
                Bookmenu.Visibility = Visibility.Visible;
                return;
            }

            else if (Converted_to_Bt.Content.Equals(Bt_name_user))
            {
                Bookmenu.Visibility = Visibility.Collapsed;
                if (Usermenu.Visibility == Visibility.Visible) { Usermenu.Visibility = Visibility.Collapsed; return; }
                Usermenu.Visibility = Visibility.Visible;
                return;
            }

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



        private void ExitUser_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }





        private void AddItemBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new AddItem());

        }


        private void ChangeitemBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new ChangeRemoveBooks());
        }

        private void AdduserBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new AddUser());
        }

        private void ChangeuserBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new ChangeRemoveUser());
        }

        private void ProfilButton_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new Profile());
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            SearchWindow search_obj = new SearchWindow();

            search_obj.Show();
            var mainwin = Application.Current.MainWindow;
            mainwin.Hide();
        }
    }
}
