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

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public List<BookDb> books = new List<BookDb>();
        public List<CategoryDb> categorys = new List<CategoryDb>();
       // public List<BookDb> resultList = new List<BookDb>();

        private dynamic _loginService;
        string search_text = "Skriv title, författare eller annat sökord";
        IValidation validation = new Logic.Validation();
        public LoginPage()
        {

            InitializeComponent();
            this.tbUsernam.Focus();
            searchbox.Text = search_text;
            using var dbContex = new librarysystemdbContext();            
            categorys = dbContex.CategoryDbs.ToList();
            books = dbContex.BookDbs.ToList();
            books.ForEach(b => b.Category = categorys.Where(c => c.Id == b.CategoryId).FirstOrDefault());

        }




        private void Shoutdown_BT_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (validation.checkIfValidUser(tbUsernam.Text, pbPassword.Password))
            {
                NavigationService.Navigate(new HomePage());
            } 
            else if (validation.checkIfValidPersonal(tbUsernam.Text, pbPassword.Password))
            {
                if (validation.checkIfAdmin(tbUsernam.Text, pbPassword.Password))
                {
                    // admin
                    NavigationService.Navigate(new HomePage());
                }
                // Personal
                NavigationService.Navigate(new HomePage());
            }
            else
            {
                MessageBox.Show("Felaktig inmating av användarnamn eller lösenord", "Error", MessageBoxButton.OK);
            }

            





        }

        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {
            if (SearchDetailsFount.Visibility == Visibility.Collapsed) { SearchDetailsFount.Visibility = Visibility.Visible; logoimage.Visibility = Visibility.Collapsed; }
            else { SearchDetailsFount.Visibility = Visibility.Collapsed; logoimage.Visibility = Visibility.Visible; }

            var resultList = books.Where(b => b.Author.Contains(searchbox.Text) || b.Category.CategoryName.Contains(searchbox.Text) || b.Title.Contains(searchbox.Text) || b.Isbn.Contains(searchbox.Text));
            
            
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

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void searchbox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
    

