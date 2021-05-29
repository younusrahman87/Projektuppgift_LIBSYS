using GUI.Login;
using GUI.Models;
using GUI.Pages;
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

namespace GUI.User
{
    /// <summary>
    /// Interaction logic for UserBooksInfo.xaml
    /// </summary>
    public partial class UserBooksInfo : Page
    {
        BookDb book = new BookDb();


        public UserBooksInfo()
        {
            InitializeComponent();
            GetListview();
        }
        public void GetListview()
        {
     
             using var dbContex = new librarysystemdbContext();
             var books = dbContex.BookDbs.ToList();
             var current = (UserDb)LoginPage.currentUser.First();
            foreach (var item in books)
            {
                if (current.Id == item.UserId)
                {
                    booksListview.Items.Add(item);
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfile());
        }

    

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Profile());
          

        }

        private void booksListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           book = (BookDb)booksListview.SelectedItem;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Är du säker på att du vill återlämmna denna bok?", "Återlämna", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    using var dbContex = new librarysystemdbContext();
                    var books = dbContex.BookDbs.ToList();
                    foreach (var item in books)
                    {
                        if (book.UserId == item.UserId&& book.Id== item.Id)
                        {
                            item.UserId = null;
                        }

                    }
                            dbContex.SaveChanges();
                    NavigationService.Navigate(new UserBooksInfo());


                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }
    }
}
