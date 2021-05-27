using GUI.Home;
using GUI.Models;
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

namespace GUI
{
    /// <summary>
    /// Interaction logic for SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {


        public SearchWindow(List<BookDb> searchResult)
        {

            InitializeComponent();

            SearchResults.ItemsSource = searchResult;

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

        }
    }
}
