using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Staff
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public List<CategoryDb> categorys = new List<CategoryDb>();
        public List<BookDb> newBooks = new List<BookDb>();
        //---------------------------------------------------
        private readonly string BookTitle = "-- Titel --";
        private readonly string Author = "-- Författare --";
        private readonly string Publisher = "-- Förlag --";
        private readonly string Price = "-- Pris --";
        private readonly string ISBN = "-- ISBN --";
        private readonly string DDC = "-- DDC --";

        private readonly string Error = "** Fel inmatning **";
        private readonly string Saved = "** Sparad **";
        //---------------------------------------------------
        public AddItem()
        {
            InitializeComponent();

            using var dbContex = new librarysystemdbContext();

            try
            {
                categorys = dbContex.CategoryDbs.ToList();
                cb_Category.ItemsSource = categorys;
            }
            catch (Exception)
            {
                MessageDisplay.Content = "** Kunde inte ladda objekt **";
            }
        }

        private void cb_choose_book_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bt_add_book.Visibility = Visibility.Visible;
        }

        private void bt_add_book_Click(object sender, RoutedEventArgs e)
        {
            int price = 0;
            decimal DDC = 0;

            CategoryDb categoryItem = (CategoryDb)cb_Category.SelectedItem;

            if (tb_Author.Text == string.Empty ||
                tb_Publisher.Text == string.Empty ||
                tb_Title.Text == string.Empty)
            {
                MessageDisplay.Content = Error;
                return;
            }
            else if(tb_Price.Text == string.Empty || !Int32.TryParse(tb_Price.Text, out price))
            {
                MessageDisplay.Content = Error;
                return;
            }
            else if (tb_DDC.Text == string.Empty || !Decimal.TryParse(tb_DDC.Text, out DDC))
            {
                MessageDisplay.Content = Error;
                return;
            }
            else if (tb_ISBN.Text == string.Empty || tb_ISBN.Text.Length != 17)
            {
                MessageDisplay.Content = Error;
                return;
            }

            else
            {
                var book = new BookDb
                {
                    Price = price,
                    Title = tb_Title.Text,
                    Author = tb_Author.Text,
                    Publisher = tb_Publisher.Text,
                    CategoryId = categoryItem.Id,
                    Ddc = DDC,
                    Isbn = tb_ISBN.Text,
                };

                using var dbContex = new librarysystemdbContext();
                dbContex.BookDbs.Add(book);

                dbContex.SaveChanges();
                newBooks.Add(book);
                UpdateNewBookList();

                MessageDisplay.Content = Saved;
            }
        }

        private void UpdateNewBookList()
        {
            lb_new_books.ItemsSource = newBooks;
        }

        private void Add_Category_Click(object sender, RoutedEventArgs e)
        {
            AddCategory addCategoryWindow = new AddCategory();
            addCategoryWindow.Show();
        }

        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(BookTitle)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Author)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Publisher)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Price)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(ISBN)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(DDC)) { _sender.Text = string.Empty; }
        }

        private void Lost_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Title")) { _sender.Text = BookTitle; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Author")) { _sender.Text = Author; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Publisher")) { _sender.Text = Publisher; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Price")) { _sender.Text = Price; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_ISBN")) { _sender.Text = ISBN; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_DDC")) { _sender.Text = DDC; }
        }
    }
}
