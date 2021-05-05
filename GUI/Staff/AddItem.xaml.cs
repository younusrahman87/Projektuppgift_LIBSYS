using System;
using System.Collections.Generic;
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
        public AddItem()
        {
            InitializeComponent();
            DP_book_PublicationDate.DisplayDateEnd = DateTime.Now;
        }


        //---------------------------------------------------
        private readonly string Title = "-- Boktitel --";
        private readonly string Author = "-- Författare --";
        private readonly string Language = "-- Språk --";
        private readonly string PublicationDate = "-- Publiceringsdatum --";
        private readonly string Ebook = "-- E-bok ISBN --";
        private readonly string Wrong_msg = "** Fel inmatning **";
        //---------------------------------------------------



        private void cb_choose_book_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cb_choose_book_typ.SelectedIndex.Equals(1)) tb_Ebook.Visibility = Visibility.Visible;
            else tb_Ebook.Visibility = Visibility.Collapsed;

            bt_add_book.Visibility = Visibility.Visible;

        }


        private void bt_add_book_Click(object sender, RoutedEventArgs e)
        {
            if (cb_choose_book_typ.SelectedIndex.Equals(1) && tb_Ebook.Text != Ebook ) Error_msg.Content = "Yes funker 1";
            else if (cb_choose_book_typ.SelectedIndex.Equals(0) && tb_PublicationDate.Text != PublicationDate) Error_msg.Content = "Yes funker 2";
        }


        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(Title)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Author)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Language)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(PublicationDate)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Ebook)) { _sender.Text = string.Empty; }


        }


        private void Lost_focuse(object sender, RoutedEventArgs e)
        {

            var _sender = (TextBox)sender;


            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Booktitel")) { _sender.Text = Title; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Author")) { _sender.Text = Author; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Language")) { _sender.Text = Language; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_PublicationDate")) { _sender.Text = PublicationDate; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Ebook")) { _sender.Text = Ebook; }


        }


    }
}
