using GUI.Models;
using Logic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
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
        GetData getData = new GetData();
        private UserDb user { get; set; } = new UserDb();
 
        public ChangeRemoveUser()
        {
           InitializeComponent();
            
          GetListview();

        }
      
        public  void  GetListview()
        {
           
            var users = getData.GetUser();
            
            foreach (var item in  users)
                {
                    listView.Items.Add(item);

                }
        }

        private void listView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserDb user = (UserDb)listView.SelectedItem;
            if (user != null)
            {
                id.Text = user.Id.ToString();
                firstName.Text = user.FirstName.ToString();
                lastName.Text = user.LastName.ToString();
                email.Text = user.Email.ToString();
                password.Password = user.Password.ToString();
                libraryCard.Text = user.LibraryCard.ToString();
                PersonNr.Text = user.SocialSecurityNumber.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Ändra
            try
            {
                if (validation.RemoveEmailUser(email.Text))
                {
                    user.FirstName = firstName.Text;
                    user.LastName = lastName.Text;
                    user.SocialSecurityNumber = PersonNr.Text;
                    user.Email = email.Text;
                    user.Password = password.Password;
                    if (libraryCard.SelectedIndex.Equals(1)) { user.LibraryCard = true; }
                    else { user.LibraryCard = false; }
                    service.UpdateUser(user);

                    MessageBox.Show("Användare är nu uppdaterad", "Användare", MessageBoxButton.OK);
                    ChangeRemoveUser changeRemoveUser = new ChangeRemoveUser();
                    this.NavigationService.Navigate(changeRemoveUser);
                }
            
                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
           
        }



    

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
           
            try
            {
                if (validation.RemoveEmailUser(email.Text))
                {
                    service.RemoveUser(email.Text);

                    MessageBox.Show("Användare är nu borttagen", "Användare", MessageBoxButton.OK);
                    ChangeRemoveUser changeRemoveUser = new ChangeRemoveUser();
                    this.NavigationService.Navigate(changeRemoveUser);
                }
               
                else { MessageBox.Show("Felaktig inmating av email", "Användare", MessageBoxButton.OK); }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }

          //  Uppdatera Listview
          
        }

        //Behöver koppla denna med lånefunktionen. LÅT VARA KVAR //Calle
        private void libraryCard_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (libraryCard.SelectedIndex == 1)
            {           
                        user.LibraryCard = false;
                        
            } 
            else if (libraryCard.SelectedIndex == 2)
            {                       
                        user.LibraryCard = true;
                    
                      
            }
        }
    }
}
