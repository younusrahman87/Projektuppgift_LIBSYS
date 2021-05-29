using GUI.Login;
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

namespace GUI.User
{
    /// <summary>
    /// Interaction logic for UserProfile.xaml
    /// </summary>
    public partial class UserProfile : Page
    {
        public UserProfile()
        {
            InitializeComponent();
            foreach (var item in LoginPage.currentUser)
            {
                fName.Text = item.FirstName;
                lName.Text = item.LastName;
                email.Text = item.Email;
                if (item.LibraryCard)
                {
                    libraryCard.Text = "Aktivt bibliotekskort";
                }
                else 
                {
                    libraryCard.Text = "Inaktivt bibliotekskort";
                }
            }  
        }

        

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Profile());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserBooksInfo());
        }
    }
}
