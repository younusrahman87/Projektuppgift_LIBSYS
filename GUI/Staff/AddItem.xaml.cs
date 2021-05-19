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

namespace GUI.Staff
{
    /// <summary>
    /// Interaction logic for AddItem.xaml
    /// </summary>
    public partial class AddItem : Page
    {
        public List<CategoryDb> categorys = new List<CategoryDb>();
        public List<BookDb> books = new List<BookDb>();
        public BookDb selectedBook = new BookDb();
        public AddItem()
        {
            InitializeComponent();

            using var dbContex = new librarysystemdbContext();
            categorys = dbContex.CategoryDbs.ToList();
            cb_Category.ItemsSource = categorys;
        }


        //---------------------------------------------------
        private readonly string Title = "-- Boktitel --";
        private readonly string Author = "-- Författare --";
        private readonly string Language = "-- Språk --";
        private readonly string Price = "-- Publiceringsdatum --";
        private readonly string ISBN = "-- E-bok ISBN --";
        private readonly string Wrong_msg = "** Fel inmatning **";
        //---------------------------------------------------



        private void cb_choose_book_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            bt_add_book.Visibility = Visibility.Visible;
        }


        private void bt_add_book_Click(object sender, RoutedEventArgs e)
        {
            Error_msg.Content = string.Empty;

            if (tb_Author.Text == string.Empty)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Price.Text == string.Empty)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Publisher.Text == string.Empty)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Title.Text == string.Empty)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }

            CategoryDb categoryItem = (CategoryDb)cb_Category.SelectedItem;

            if(!Int32.TryParse(tb_Price.Text, out int price))
            {
                Error_msg.Content = Wrong_msg;
                return;
            }

            decimal DDC = 0;

            if (tb_DDC.Text != string.Empty && Decimal.TryParse(tb_DDC.Text, out DDC) == false)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }

            if(tb_ISBN.Text != string.Empty && tb_ISBN.Text.Length != 17)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }

            var book = new BookDb
            {
                Price = price,
                Title = tb_Title.Text,
                Author = tb_Author.Text,
                Publisher = tb_Publisher.Text,
                CategoryID = categoryItem.ID,
                DDC = DDC,
                ISBN = tb_ISBN.Text,
            };

            using var dbContex = new librarysystemdbContext();
            dbContex.BookDbs.Add(book);

            dbContex.SaveChanges();

            MessageBox.Show("Bok tillagd!");
        }

        private void Add_Category_Click(object sender, RoutedEventArgs e)
        {
            
        }


        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(Title)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Author)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Language)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Price)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(ISBN)) { _sender.Text = string.Empty; }


        }


        private void Lost_focuse(object sender, RoutedEventArgs e)
        {

            var _sender = (TextBox)sender;


            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Booktitel")) { _sender.Text = Title; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Author")) { _sender.Text = Author; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Language")) { _sender.Text = Language; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Price")) { _sender.Text = Price; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Ebook")) { _sender.Text = ISBN; }


        }

        private void Bt_remove_case_Click(object sender, RoutedEventArgs e)
        {
            Error_msg.Content = string.Empty;
            using var dbContex = new librarysystemdbContext();
            if (selectedBook != null)
            {
                dbContex.BookDbs.Remove(selectedBook);
                dbContex.SaveChanges();
                MessageBox.Show("Bok raderad!");
            }
            else
            {
                Error_msg.Content = Wrong_msg;
            }
        }

        private void search_bt_Click(object sender, RoutedEventArgs e)
        {
            using var dbContex = new librarysystemdbContext();
            books = dbContex.BookDbs.ToList();
            books.ForEach(b => b.Category = categorys.Where(c => c.ID == b.CategoryID).FirstOrDefault());
            
            
            try
            {
                selectedBook = books.Where(b => b.Id == int.Parse(tb_sc_search_Boo.Text)).FirstOrDefault();
            }
            catch
            {
                Error_msg.Content = Wrong_msg;
                selectedBook = null;
                return;
            }

            tb_sc_Category.Text = selectedBook.Category.CategoryName;
            tb_sc_Title.Text = selectedBook.Title;
            tb_sc_Author.Text = selectedBook.Author;
            tb_sc_Publisher.Text = selectedBook.Publisher;
            tb_sc_Price.Text = selectedBook.Price.ToString();
            tb_sc_ISBN.Text = selectedBook.ISBN;
            tb_sc_DDC.Text = selectedBook.DDC.ToString();

        }
    }
}
