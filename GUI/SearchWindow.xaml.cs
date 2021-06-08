using GUI.Login;
using GUI.Models;
using Logic;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        List<BookDb> searchResult = new List<BookDb>();
        FuncService funcService = new Service();

        public SearchWindow(List<BookDb> list, string current)
        {

            InitializeComponent();

            
            searchResult = list;
            SearchResults.ItemsSource = searchResult;

            if(current == "personal" || current == "admin")
            {
                RemoveBook.Visibility = Visibility.Visible;
                ReturnBook.Visibility = Visibility.Hidden;
                LoanBook.Visibility = Visibility.Hidden;
            }
            else if(current == "user")
            {
                RemoveBook.Visibility = Visibility.Hidden;
                ReturnBook.Visibility = Visibility.Visible;
                LoanBook.Visibility = Visibility.Visible;
            }
        }

        private void BT_goBack_Click(object sender, RoutedEventArgs e)
        {
            var win = Application.Current.MainWindow;
            win.Show();
            this.Close();

        }

        private void cb_borrowed_book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

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

        private void RemoveBook_Click(object sender, RoutedEventArgs e)
        {
            BookDb selectedBook = (BookDb)SearchResults.SelectedItem;
            using var dbContex = new librarysystemdbContext();
            if (selectedBook != null)
            {
                dbContex.BookDbs.Remove(selectedBook);
                dbContex.SaveChanges();
                MessageBox.Show("Bok raderad!");
                searchResult.Remove(searchResult.Where(b => b.Id == selectedBook.Id).First());
                SearchResults.ItemsSource = searchResult;

            }
            else
            {
                MessageBox.Show("Error! Kunde inte radera bok");
            }
        }

        private void ReturnBook_Click(object sender, RoutedEventArgs e)
        {
            BookDb selectedBook = (BookDb)SearchResults.SelectedItem;

            var current = (UserDb)LoginPage.currentUser;

            if (selectedBook.UserId == current.Id)
            {
                selectedBook.UserId = null;

                funcService.UpdateBook(selectedBook);

                MessageBox.Show("Bok återlämnad!");
            }
            else
            {
                MessageBox.Show("Du kan inte lämna tillbaka den här boken eftersom du inte har lånat den!");
            }
            
        }

        private void LoanBook_Click(object sender, RoutedEventArgs e)
        {
            BookDb selectedBook = (BookDb)SearchResults.SelectedItem;

            var current = (UserDb)LoginPage.currentUser;

            if(selectedBook.UserId == null && current.LibraryCard == true)
            {
                selectedBook.UserId = current.Id;

                funcService.UpdateBook(selectedBook);

                MessageBox.Show("Bok lånad!");
            }
            else if(current.LibraryCard == false)
            {
                MessageBox.Show("Ditt lånekort är spärrat/inaktivt. Vänligen kontakta ditt bibliotek för mer detaljer.");
            }
            else
            {
                MessageBox.Show("Boken är redan utlånad!");
            }
            
        }

        private void Return_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
