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
    /// Interaction logic for AddPersonal.xaml
    /// </summary>
    public partial class AddPersonal : Page
    {
        private readonly string Firstname = "-- Förnamn --";
        private readonly string Lastname = "-- Efternamn --";
        private readonly string Email = "-- E-Mail --";
        private readonly string JobTitle = "-- Job Title --";
        private readonly string Wrong_msg = "** Fel inmatning **";
        private FuncService service = new Service();
        private IValidation validation = new Logic.Validation();
        private UserDb user { get; set; } = new UserDb();
        private PersonalDb personal { get; set; } = new PersonalDb();

        public AddPersonal()
        {
            InitializeComponent();
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


            if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_Firstname")) { _sender.Text = Firstname; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_lastname")) { _sender.Text = Lastname; }
            else if (_sender.Text.Equals(string.Empty) && _sender.Name.Equals("tb_email")) { _sender.Text = Email; }



        }

      

        private void addPersonal_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //--------------------------------------------------------Valedering av korrekt inmatning saknas


                if (validation.AvailableEmail(email.Text)&& validation.AvailableSocialSecurityNumber(PersonNr.Text))
                {
                    personal.FirstName = firstName.Text;
                    personal.LastName = lastName.Text;
                    personal.Email = email.Text;
                    personal.JobTitle = jobTitle.Text;
                    personal.Password = password.Password;
                    personal.SocialSecurityNumber = PersonNr.Text;
                    service.AddPersonal(personal);

                    MessageBox.Show("Personal är tillagd", "Användare", MessageBoxButton.OK);
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

   
    }
}
