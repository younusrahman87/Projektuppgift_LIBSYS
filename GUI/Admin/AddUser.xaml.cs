using GUI.Models;
using Logic;
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

            


        }



        private readonly string Firstname = "-- Förnamn --";
        private readonly string Lastname = "-- Efternamn --";
        private readonly string Email = "-- E-Mail --";
        private readonly string JobTitle = "-- Job Title --";
        private readonly string Wrong_msg = "** Fel inmatning **";



        //private void cb_user_till_user_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{

        //}

        private void cb_choose_user_typ_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var CBox = sender as ComboBox;

            if (CBox.SelectedIndex.Equals(0))
            {
                Sp_cb_card_have.Visibility = Visibility.Visible;
                sp_Jobtitle.Visibility = Visibility.Collapsed;
                SP_Button.Visibility = Visibility.Visible;
                return;
            }
            else if (CBox.SelectedIndex.Equals(1) || CBox.SelectedIndex.Equals(2))
            {
                Sp_cb_card_have.Visibility = Visibility.Collapsed;
                sp_Jobtitle.Visibility = Visibility.Visible;
                SP_Button.Visibility = Visibility.Visible;
                return;
            }

            Sp_cb_card_have.Visibility = Visibility.Collapsed;
            sp_Jobtitle.Visibility = Visibility.Collapsed;
            SP_Button.Visibility = Visibility.Collapsed;


        }




        private void Got_focuse(object sender, RoutedEventArgs e)
        {
            var _sender = (TextBox)sender;

            if (_sender.Text.Equals(Firstname)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Lastname)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(Email)) { _sender.Text = string.Empty; }
            else if (_sender.Text.Equals(JobTitle)) { _sender.Text = string.Empty; }



        }


        private void Lost_focuse(object sender, RoutedEventArgs e)
        {

            var _sender = (TextBox)sender;


            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_firstname")) { _sender.Text = Firstname; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_lastname")) { _sender.Text = Lastname; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_email")) { _sender.Text = Email; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Jobtitle")) { _sender.Text = JobTitle; }


        }
        librarysystemdbContext _db = new librarysystemdbContext();
        private void bt_add_user_Click(object sender, RoutedEventArgs e)
        {
            UserDb user = new UserDb();

           
            //------------------------------------------------------Lägga till

            /*
            user.FirstName = "Hans";
            user.LastName = "Johansson";
            user.Email = "Hans@gmail.com";
            user.LibraryCard = true;
            user.Password = "Kula89776623";
            user.Id = 101;
            _db.UserDbs.Add(user);
            _db.SaveChanges();
            */



            //------------------------------------------------------ta bort
            //var obj = _db.UserDbs.Find(101);

            //_db.UserDbs.Remove(obj);
            //_db.SaveChanges();


            //---------------------------------------------------------Ändra 

           /*
            var obj = _db.UserDbs.Find(101);
            obj.FirstName = "Janne";
            obj.LastName = "sson";
            obj.Email = "vafan@gmail.com";
            obj.LibraryCard =false;
            obj.Password = "hejhopp";
            _db.UserDbs.Update(obj);
            _db.SaveChanges();

           */









        }
    }
}
