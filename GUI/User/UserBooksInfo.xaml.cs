using GUI.Login;
using GUI.Models;
using GUI.Pages;
using Logic;
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

namespace GUI.User
{
    /// <summary>
    /// Interaction logic for UserBooksInfo.xaml
    /// </summary>
    public partial class UserBooksInfo : Page
    {
        BookDb book = new BookDb();

        private FuncService service = new Service();
        public UserBooksInfo()
        {
            InitializeComponent();
            GetListview();
        }
        public void GetListview()
        {
     
             
             var books = service.GetBooks();
             var current = (UserDb)LoginPage.currentUser;
            foreach (var item in books)
            {
                if (current.Id == item.UserId)
                {
                    booksListview.Items.Add(item);
                }
            }
        }

        private void Profile_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfile());
        }

    

        private void Loan_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Profile());
          

        }

        private void booksListview_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           book = (BookDb)booksListview.SelectedItem;
        }

        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Är du säker på att du vill återlämmna denna bok?", "Återlämna", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    book.UserId = null;
                    service.UpdateBook(book);
                    Task.Delay(2000);
                    MessageBox.Show("Du har nu lämnat tillbaka boken", "Återlämna", MessageBoxButton.OK);

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
