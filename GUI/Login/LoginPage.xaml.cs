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
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public List<BookDb> searchResult = new List<BookDb>();

        public static IEnumerable<UserDb> currentUser;
        public static IEnumerable<PersonalDb> currentPersonal;
        private dynamic _loginService;
        string search_text = "Skriv title, författare eller annat sökord";
        IValidation validation = new Logic.Validation();
        private FuncService service = new Service();
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
            if (validation.checkIfValidUser(tbUsernam.Text, pbPassword.Password))
            {
                //Hämtar rätt användare
                currentUser = service.GetUserInfo(tbUsernam.Text);
               


                NavigationService.Navigate(new HomePage("user"));
            } 
            else if (validation.checkIfValidPersonal(tbUsernam.Text, pbPassword.Password))
            {
                if (validation.checkIfAdmin(tbUsernam.Text, pbPassword.Password))
                {

                    NavigationService.Navigate(new HomePage("admin"));

                }
                else
                {
                    currentPersonal = service.GetPersonalInfo(tbUsernam.Text);
                    NavigationService.Navigate(new HomePage("personal"));
                }
            }
            else
            {
                MessageBox.Show("Felaktig inmating av användarnamn eller lösenord", "Error", MessageBoxButton.OK);
            }


        }

        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {
            //if (SearchDetailsFount.Visibility == Visibility.Collapsed) { SearchDetailsFount.Visibility = Visibility.Visible; logoimage.Visibility = Visibility.Collapsed; }
            //else { SearchDetailsFount.Visibility = Visibility.Collapsed; logoimage.Visibility = Visibility.Visible; }

            //var resultList = books.Where(b => b.Author.Contains(searchbox.Text) || b.Category.CategoryName.Contains(searchbox.Text) || b.Title.Contains(searchbox.Text) || b.Isbn.Contains(searchbox.Text));

            Service service = new Service();
            searchResult = service.SearchBooks(searchbox.Text);

            SearchResults.ItemsSource = searchResult;
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

        private void SearchResults_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            BookDb selectedBook = (BookDb)SearchResults.SelectedItem;

            MessageBox.Show(
                $"Titel: {selectedBook.Title} \n" +
                $"Författare: {selectedBook.Author} \n" +
                $"Förlag: {selectedBook.Publisher} \n" +
                $"Pris: {selectedBook.Price} \n" +
                $"Kategori: {selectedBook.Category.CategoryName} \n" +
                $"ISBN: {selectedBook.Isbn} \n" +
                $"DDC: {selectedBook.Ddc} \n" +
                $"Id: {selectedBook.Id} \n"
                );
        }

        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
    

