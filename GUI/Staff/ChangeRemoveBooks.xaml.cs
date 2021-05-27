using GUI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace GUI.Staff
{
    /// <summary>
    /// Interaction logic for ChangeRemoveBooks.xaml
    /// </summary>
    public partial class ChangeRemoveBooks : Page
    {
        public List<CategoryDb> categorys = new List<CategoryDb>();
        public List<BookDb> books = new List<BookDb>();
        public BookDb selectedBook = new BookDb();
        public ChangeRemoveBooks()
        {
            InitializeComponent();

            using var dbContex = new librarysystemdbContext();
            categorys = dbContex.CategoryDbs.ToList();
            cb_Category.ItemsSource = categorys;
            UpdateBookList();
        }

        private void UpdateBookList()
        {
            using var dbContex = new librarysystemdbContext();
            books = dbContex.BookDbs.ToList();
            books.ForEach(b => b.Category = categorys.Where(c => c.Id == b.CategoryId).FirstOrDefault());
            lb_books.ItemsSource = books;
            Error_msg.Visibility = Visibility.Hidden;
        }

        private void Bt_edit_book_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using var dbContex = new librarysystemdbContext();
                var newBook = dbContex.BookDbs.Find(int.Parse(tb_sc_search_Boo.Text));
                int price = 0;
                    decimal DDC = 0;

                    CategoryDb categoryItem = (CategoryDb)cb_Category.SelectedItem;

                    if (tb_sc_Author.Text == string.Empty ||
                        tb_sc_Publisher.Text == string.Empty ||
                        tb_sc_Title.Text == string.Empty)
                    {
                        
                        return;
                    }
                    else if (tb_sc_Price.Text == string.Empty || !Int32.TryParse(tb_sc_Price.Text, out price))
                    {
                        
                        return;
                    }
                    else if (tb_sc_DDC.Text == string.Empty && !Decimal.TryParse(tb_sc_DDC.Text, out DDC))
                    {
                        ;
                        return;
                    }
                    else if (tb_sc_ISBN.Text == string.Empty && tb_sc_ISBN.Text.Length != 17)
                    {
                       
                        return;
                    }
                    else
                    {
                        newBook.Price = price;
                        newBook.Title = tb_sc_Title.Text;
                        newBook.Author = tb_sc_Author.Text;
                        newBook.Publisher = tb_sc_Publisher.Text;
                        newBook.CategoryId = categoryItem.Id;
                        newBook.Ddc = DDC;
                        newBook.Isbn = tb_sc_ISBN.Text;

                        dbContex.SaveChanges();
                        MessageBox.Show("Bok updaterad!");
                        UpdateBookList();

                        tb_sc_Title.Text = "-- Titel --";
                        tb_sc_Author.Text = "-- Författare --";
                        tb_sc_Publisher.Text = "-- Förlag --";
                        tb_sc_Price.Text = "-- Pris --";
                        tb_sc_ISBN.Text = "-- ISBN --";
                        tb_sc_DDC.Text = "-- DDC --";
                    }
            }
            catch
            {
                Error_msg.Content = "Error! Felaktig input";
                return;
            }
            
        }

        private void Bt_remove_book_Click(object sender, RoutedEventArgs e)
        {
            using var dbContex = new librarysystemdbContext();
            if (selectedBook != null)
            {
                dbContex.BookDbs.Remove(selectedBook);
                dbContex.SaveChanges();
                MessageBox.Show("Bok raderad!");
                UpdateBookList();
                
                tb_sc_Title.Text = "-- Titel --";
                tb_sc_Author.Text = "-- Författare --";
                tb_sc_Publisher.Text = "-- Förlag --";
                tb_sc_Price.Text = "-- Pris --";
                tb_sc_ISBN.Text = "-- ISBN --";
                tb_sc_DDC.Text = "-- DDC --";
            }
            else
            {
                Error_msg.Content = "Error! Kunde inte radera bok";
            }
        }

        private void search_bt_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                selectedBook = books.Where(b => b.Id == int.Parse(tb_sc_search_Boo.Text)).First();
            }
            catch
            {
                Error_msg.Content = $"Error! Ingen bok hittades med id: {tb_sc_search_Boo.Text}";
                selectedBook = null;
                return;
            }

            cb_Category.SelectedItem = selectedBook.Category;
            tb_sc_Title.Text = selectedBook.Title;
            tb_sc_Author.Text = selectedBook.Author;
            tb_sc_Publisher.Text = selectedBook.Publisher;
            tb_sc_Price.Text = selectedBook.Price.ToString();
            tb_sc_ISBN.Text = selectedBook.Isbn;
            tb_sc_DDC.Text = selectedBook.Ddc.ToString();
        }

        private void lb_books_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedBook = (BookDb)lb_books.SelectedItem;

            if(selectedBook != null)
            {
                cb_Category.SelectedItem = selectedBook.Category;
                tb_sc_Title.Text = selectedBook.Title;
                tb_sc_Author.Text = selectedBook.Author;
                tb_sc_Publisher.Text = selectedBook.Publisher;
                tb_sc_Price.Text = selectedBook.Price.ToString();
                tb_sc_ISBN.Text = selectedBook.Isbn;
                tb_sc_DDC.Text = selectedBook.Ddc.ToString();
                tb_sc_search_Boo.Text = selectedBook.Id.ToString();
            }
        }

        private void cb_Category_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Bt_remove_book.Visibility = Visibility.Visible;
        }
    }
}
