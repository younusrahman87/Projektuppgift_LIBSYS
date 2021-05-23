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
    /// Interaction logic for ChangeRemovePersonal.xaml
    /// </summary>
    public partial class ChangeRemovePersonal : Page
    {
        private FuncService service = new Service();
        private IValidation validation = new Logic.Validation();
        GetData getData = new GetData();
        private PersonalDb personal { get; set; } = new PersonalDb();
        public ChangeRemovePersonal()
        {
            InitializeComponent();
            GetListview();
        }
        public void GetListview()
        {

            var personal = getData.GetPesonal();

            foreach (var item in personal)
            {
                listView.Items.Add(item);

            }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonalDb personal = (PersonalDb)listView.SelectedItem;
            if (personal != null)
            {
                id.Text = personal.Id.ToString();
                firstName.Text = personal.FirstName.ToString();
                lastName.Text = personal.LastName.ToString();
                email.Text = personal.Email.ToString();
                password.Password = personal.Password.ToString();
                PersonNr.Text = personal.SocialSecurityNumber.ToString();
                jobtitle.Text = personal.JobTitle.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            try
            {
                if (validation.RemoveEmailPersonal(email.Text))
                {
                    service.RemovePersonal(email.Text);

                    MessageBox.Show("Användare är nu borttagen", "Användare", MessageBoxButton.OK);
                }

                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

            //  Uppdatera Listview

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Ändra
            try
            {
                if (validation.RemoveEmailPersonal(email.Text))
                {
                    personal.FirstName = firstName.Text;
                    personal.LastName = lastName.Text;
                    personal.JobTitle = jobtitle.Text;
                    personal.Email = email.Text;
                    personal.Password = password.Password;
                    personal.SocialSecurityNumber = PersonNr.Text;
                    service.UpdatePersonal(personal);

                    MessageBox.Show("Personal är nu uppdaterad", "Användare", MessageBoxButton.OK);
                }

                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

            //Uppdatera Listview

        }
    }
}
