using GUI.Models;
using Logic;
using System;
using System.Collections;
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

namespace GUI.Admin
{
    /// <summary>
    /// Interaction logic for ChangeRemoveUser.xaml
    /// </summary>
    public partial class ChangeRemoveUser : Page
    {
        private FuncService service = new Service();
        private IValidation validation = new Logic.Validation();
        private UserDb user { get; set; } = new UserDb();
 
        public ChangeRemoveUser()
        {
            InitializeComponent();
            GetListview();



        }
      
        public void GetListview()
        {
            GetData getData = new GetData();
            var users = getData.GetUser();
            foreach (var item in users)
            {
                listView.Items.Add(item);

            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDb user = (UserDb)listView.SelectedItem;

            firstName.Text = user.FirstName.ToString();
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Ändra
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Ta bort
        }
    }
}
