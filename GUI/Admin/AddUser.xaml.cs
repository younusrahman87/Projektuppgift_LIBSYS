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

        private FuncService service = new Service();
        private IValidation validation = new Logic.Validation();
        private UserDb user { get; set; } = new UserDb();
        private PersonalDb personal { get; set; } = new PersonalDb();
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

        private void bt_add_user_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                //--------------------------------------------------------Valedering av korrekt inmatning saknas


                if (validation.AvailableEmail(tb_email.Text)&& validation.AvailableSocialSecurityNumber(PersonNr.Text))
                {
                    user.FirstName = tb_firstname.Text;
                    user.LastName = tb_lastname.Text;
                    user.Email = tb_email.Text;
                    if (cb_card_have.SelectedIndex.Equals(0)) { user.LibraryCard = true; }
                    else { user.LibraryCard = false; }
                    user.Password = tb_password.Password;
                    user.SocialSecurityNumber = PersonNr.Text;
                    service.AddUser(user);

                    MessageBox.Show("Användare är tillagd", "Användare", MessageBoxButton.OK);
                }
                else
                {
                    MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }



        }

        private void cb_card_have_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
