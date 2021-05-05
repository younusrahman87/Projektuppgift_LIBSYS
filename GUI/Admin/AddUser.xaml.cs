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

namespace GUI.Admin
{
    /// <summary>
    /// Interaction logic for AddUser.xaml
    /// </summary>
    public partial class AddUser : Page
    {
        public AddUser()
        {
            InitializeComponent();

            DP_User_birth.DisplayDateEnd = DateTime.Now;


        }



        private readonly string Namn = "-- Användare Namn --";
        private readonly string Addres = "-- Adress --";
        private readonly string Email = "-- E-Mail --";
        private readonly string Wrong_msg = "** Fel inmatning **";



        private void cb_user_till_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void cb_choose_user_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }




        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(Namn)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Addres)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Email)) { _sender.Text = string.Empty; }
 


        }


        private void Lost_focuse(object sender, RoutedEventArgs e)
        {

            var _sender = (TextBox)sender;


            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Namn")) { _sender.Text = Namn; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_adress")) { _sender.Text = Addres; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_email")) { _sender.Text = Email; }


        }
    }
}
