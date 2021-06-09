using GUI.Login;
using GUI.Models;
using GUI.User;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    /// 
    public partial class Profile : Page
    {
        string search_text = "Skriv title, författare eller annat sökord";
        public List<BookDb> searchResult = new List<BookDb>();
        public UserDb current = new UserDb();
        private FuncService service = new Service();
        public  Profile()
        {
            InitializeComponent();
            GetListview();

            current = (UserDb)LoginPage.currentUser;
            if(current.LibraryCard == false)
            {
                LoanBookUser.Visibility = Visibility.Hidden;
            }
        }

        public void GetListview()
        {
            var books = service.GetBooks();
            searchResult = books.Where(x => x.UserId == null).ToList();

            lb_SearchResults.ItemsSource = searchResult;
        }
        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {
            //Fi
            if (searchbox.Text == "Skriv title, författare eller annat sökord" || searchbox.Text == string.Empty)
            {
                GetListview();
            }
            else 
            {
                Service service = new Service();
                searchResult = service.SearchBooks(searchbox.Text);

                lb_SearchResults.ItemsSource = searchResult;
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

        private void lb_SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        //info om bok?
        }

        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            BookDb book = (BookDb)lb_SearchResults.SelectedItem;

            if (MessageBox.Show("Är du säker på att du vill låna denna bok?", "Låna", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                if (book.UserId == null)
                {
                    book.UserId = current.Id;
                    service.UpdateBook(book);
                }

            }

            Task.Delay(2000);
            //MessageBox.Show("Du har nu lånat boken", "Låna", MessageBoxButton.OK);

            NavigationService.Navigate(new Profile());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserProfile());
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new UserBooksInfo());
        }
    }
}
