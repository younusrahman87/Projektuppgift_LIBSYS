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

            if (tb_Author.Text == null)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Price.Text == null)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Publisher.Text == null)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }
            else if(tb_Title.Text == null)
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

            if (tb_DDC.Text != null && Decimal.TryParse(tb_DDC.Text, out DDC) == false)
            {
                Error_msg.Content = Wrong_msg;
                return;
            }

            if(tb_ISBN.Text != null && tb_ISBN.Text.Length != 17)
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

        private void tb_Language_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
