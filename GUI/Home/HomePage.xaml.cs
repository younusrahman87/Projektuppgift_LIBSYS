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
using GUI.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Logic;

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
        string bt_seminarier = "Personal";
        string currentTypeOfUser;

        public List<BookDb> searchResult = new List<BookDb>();



       
        public HomePage(string current)
        {


            InitializeComponent();
            searchbox.Text = search_text;

            DEMO_Panel(current);

        }

        private void DEMO_Panel(string current)
        {
            currentTypeOfUser = current;

            if (current == "personal")
            {
    
                Menubar_frame.Navigate(new AdminProfile());
                PersonalPanel.Visibility = Visibility.Visible;
                AdminPanel.Visibility = Visibility.Collapsed;
                return;


            }
           else if (current == "admin")
            {
                Menubar_frame.Navigate(new AdminProfile());
                PersonalPanel.Visibility = Visibility.Visible;
                AdminPanel.Visibility = Visibility.Visible;
                return;
            }
            else if(current=="user")
            {
                Menubar_frame.Navigate(new Profile());
                AdminPanel.Visibility = Visibility.Collapsed;
                PersonalPanel.Visibility = Visibility.Collapsed;
                return;
            }
        }

        private void MenuBT_Click(object sender, RoutedEventArgs e)
        {

            BookMenuBT.BorderThickness = new Thickness(0, 0, 0, 2);
            BookMenuBT.BorderBrush = new SolidColorBrush(Colors.Gray);
            UserBT.BorderThickness = new Thickness(0, 0, 0, 0);
            personalBT.BorderThickness = new Thickness(0, 0, 0, 0);

            Button Converted_to_Bt = sender as Button;



            if(Converted_to_Bt.Content.Equals(Bt_name_bok))
            {
                Usermenu.Visibility = Visibility.Collapsed;
                personalmenu.Visibility = Visibility.Collapsed;
                if (Bookmenu.Visibility == Visibility.Collapsed) 
                { Bookmenu.Visibility = Visibility.Visible;
                  return; }
                Bookmenu.Visibility = Visibility.Visible;
                return;
            }

            else if (Converted_to_Bt.Content.Equals(Bt_name_user))
            {
                UserBT.BorderThickness = new Thickness(0, 0, 0, 2);
                UserBT.BorderBrush = new SolidColorBrush(Colors.Gray);
                BookMenuBT.BorderThickness = new Thickness(0, 0, 0, 0);
                personalBT.BorderThickness = new Thickness(0, 0, 0, 0);

                Bookmenu.Visibility = Visibility.Collapsed;
                personalmenu.Visibility = Visibility.Collapsed;
                if (Usermenu.Visibility == Visibility.Collapsed) { Usermenu.Visibility = Visibility.Visible; 
                                                                return; }
                Usermenu.Visibility = Visibility.Visible;
                return;
            }

            else if (Converted_to_Bt.Content.Equals(bt_seminarier))
            {
                personalBT.BorderThickness = new Thickness(0, 0, 0, 2);
                personalBT.BorderBrush = new SolidColorBrush(Colors.Gray);
                BookMenuBT.BorderThickness = new Thickness(0, 0, 0, 0);
                UserBT.BorderThickness = new Thickness(0, 0, 0, 0);


                Bookmenu.Visibility = Visibility.Collapsed;
                Usermenu.Visibility = Visibility.Collapsed;
                if (personalmenu.Visibility == Visibility.Collapsed)
                {
                    personalmenu.Visibility = Visibility.Visible;

                }

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

            UserBT.BorderThickness = new Thickness(0, 0, 0, 0);
            BookMenuBT.BorderThickness = new Thickness(0, 0, 0, 0);
            personalBT.BorderThickness = new Thickness(0,0,0,0);
            Usermenu.Visibility = Visibility.Collapsed;
            Bookmenu.Visibility = Visibility.Collapsed;
            personalmenu.Visibility = Visibility.Collapsed;



          
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            Service service = new Service();
            searchResult = service.SearchBooks(searchbox.Text);

            SearchWindow search_obj = new SearchWindow(searchResult, currentTypeOfUser);

            search_obj.Show();
            
        }

        private void ChangepersonalBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new ChangeRemovePersonal());
        }

        private void AddpersonalBT_Click(object sender, RoutedEventArgs e)
        {
            Menubar_frame.Navigate(new AddPersonal());
        }
    }
}
