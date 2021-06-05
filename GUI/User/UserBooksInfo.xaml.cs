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
     
             using var dbContex = new librarysystemdbContext();
            var books = service.GetBooks();
             var current = (UserDb)LoginPage.currentUser.First();
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

                    var books = service.GetBooks();

                    BookDb updateBook = new BookDb();
                    foreach (var item in books)
                    {
                        if (book.UserId == item.UserId&& book.Id== item.Id)
                        {
                            updateBook.UserId = null;
                            updateBook.Author = item.Author;
                            updateBook.Category = item.Category;
                            updateBook.CategoryId = item.CategoryId;
                            updateBook.Ddc = item.Ddc;
                            updateBook.Id = item.Id;
                            updateBook.Isbn = item.Isbn;
                            updateBook.Price = item.Price;
                            updateBook.Publisher = item.Publisher;
                            updateBook.Title = item.Title;   
                        }
                    }
                    service.UpdateBook(updateBook);
                    Task.Delay(2000);
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
