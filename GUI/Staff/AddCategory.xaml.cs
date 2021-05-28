using GUI.Models;
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
using System.Windows.Shapes;

namespace GUI.Staff
{
    /// <summary>
    /// Interaction logic for AddCategory.xaml
    /// </summary>
    public partial class AddCategory : Window
    {
        public AddCategory()
        {
            InitializeComponent();
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            if(tb_NewCategory.Text != string.Empty)
            {
                CategoryDb category = new CategoryDb() { CategoryName = tb_NewCategory.Text };
                using var dbContex = new librarysystemdbContext();
                dbContex.CategoryDbs.Add(category);

                dbContex.SaveChanges();

                this.Close();
            }
            else
            {
                MessageBox.Show("Felaktigt input, försök igen!");
            }
            

            
        }
    }
}
