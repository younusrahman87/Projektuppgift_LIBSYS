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

        private void bt_add_user_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                //--------------------------------------------------------Valedering av korrekt inmatning saknas


                if (validation.AvailableEmail(tb_email.Text))
                {
                    if (cb_choose_user_typ.SelectedIndex.Equals(0))
                    {
                        user.FirstName = tb_firstname.Text;
                        user.LastName = tb_lastname.Text;
                        user.Email = tb_email.Text;
                        if (cb_card_have.SelectedIndex.Equals(0)) { user.LibraryCard = true; }
                        else { user.LibraryCard = false; }
                        user.Password = tb_password.Password;
                        service.AddUser(user);

                    }
                    else if (cb_choose_user_typ.SelectedIndex.Equals(1))
                    {
                        personal.FirstName = tb_firstname.Text;
                        personal.LastName = tb_lastname.Text;
                        personal.Email = tb_email.Text;
                        personal.JobTitle = tb_Jobtitle.Text;
                        personal.Password = tb_password.Password;
                        service.AddPersonal(personal);

                    }
                    else if (cb_choose_user_typ.SelectedIndex.Equals(2))
                    {
                        personal.FirstName = tb_firstname.Text;
                        personal.LastName = tb_lastname.Text;
                        personal.Email = tb_email.Text;
                        personal.JobTitle = tb_Jobtitle.Text;
                        personal.Password = tb_password.Password;
                        service.AddPersonal(personal);

                    }

                    MessageBox.Show("Användare är tillagd", "Användare", MessageBoxButton.OK);
                }
                MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }



        }

        private void Bt_remove_case_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (validation.RemoveEmailUser(tb_sc_email.Text))
                {
                    service.RemoveUser(tb_sc_email.Text);

                    MessageBox.Show("Användare är nu borttagen", "Användare", MessageBoxButton.OK);
                }
                else if (validation.RemoveEmailPersonal(tb_sc_email.Text))
                {
                    service.RemovePersonal(tb_sc_email.Text);
                    MessageBox.Show("Peronal är nu borttagen", "Användare", MessageBoxButton.OK);
                }
                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }
               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }




        }

        private void search_bt_Click(object sender, RoutedEventArgs e)
        {
            //--------------------------------------------------------------Sök med hjälp av email

           

            try
            {
                if (validation.RemoveEmailUser(tb_sc_search_user.Text))
                {
                    cb_sc_choose_user_typ.SelectedIndex = 0;
                    IEnumerable<UserDb> user = service.GetUserInfo(tb_sc_search_user.Text);

                    foreach (var item in user)
                    {
                    tb_sc_firstname.Text = item.FirstName;
                    tb_sc_lastname.Text = item.LastName;
                    tb_sc_email.Text = item.Email;
                    tb_sc_password.Password = item.Password;
                    }
                }
               else if (validation.RemoveEmailPersonal(tb_sc_search_user.Text))
                {
                    cb_sc_choose_user_typ.SelectedIndex = 1;
                    IEnumerable<PersonalDb> personal = service.GetPersonalInfo(tb_sc_search_user.Text);

                    foreach (var item in personal)
                    {
                        tb_sc_firstname.Text = item.FirstName;
                        tb_sc_lastname.Text = item.LastName;
                        tb_sc_email.Text = item.Email;
                        tb_sc_password.Password = item.Password;
                    }
                }
                else
                { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }
             
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

        }

        private void Bt_edit_mekanik_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (validation.RemoveEmailUser(tb_sc_email.Text))
                {
                    user.FirstName = tb_sc_firstname.Text;
                    user.LastName = tb_sc_lastname.Text;

                    user.Email = tb_sc_email.Text;
                    user.Password = tb_sc_password.Password;
                    service.UpdateUser(user);

                    MessageBox.Show("Användare är nu uppdaterad", "Användare", MessageBoxButton.OK);
                }
                else if (validation.RemoveEmailPersonal(tb_sc_email.Text))
                {
                    personal.FirstName = tb_sc_firstname.Text;
                    personal.LastName = tb_sc_lastname.Text;

                    personal.Email = tb_sc_email.Text;
                    personal.Password = tb_sc_password.Password;
                    service.UpdatePersonal(personal);


                    MessageBox.Show("Peronal är nu uppdaterad", "Användare", MessageBoxButton.OK);
                }
                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }


        }
    }
}
