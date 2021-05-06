using GUI.Login;
using GUI.Staff;
using GUI.Pages;
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
using GUI.Admin;

namespace GUI.Home
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage : Page
    {



        private string searchboxtxt = "-- SMART SÖK --";
        private static object[] Current_user;
        public static object[] _GCU { get { if (Current_user == null) { Current_user = new object[4]; } return Current_user;} }
        public HomePage()
        {


            InitializeComponent();

            
        }

        private void Sing_out_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }


        private void Search_box_got_focuse(object sender, RoutedEventArgs e)
        {
            if (Search_box.Text.Equals(searchboxtxt))
            { Search_box.Text = string.Empty; }
        }




        private void Search_box_lost_focuse(object sender, RoutedEventArgs e)
        {
            if (Search_box.Text.Equals(string.Empty))
            { Search_box.Text = searchboxtxt; }
        }





        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {


            SearchWindow search_obj = new SearchWindow();

            search_obj.Show();
            var mainwin = Application.Current.MainWindow;
            mainwin.Hide();
            Search_box.Text = searchboxtxt;

        }













        private void Profil_bt_Click(object sender, RoutedEventArgs e)
        {

            Profil_bt.BorderBrush = new SolidColorBrush(Colors.Green);
            AddItemBT.BorderBrush = default;
            AddUser_Admin.BorderBrush = default;

            Menubar_frame.Navigate(new Profile());

            //if (_GCU[0].Equals(Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1)))
            //{ Menubar_frame.Navigate(new AdminProfile()); }
            //else { Menubar_frame.Navigate(new Profile()); }

        }

        private void AddItemBT_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush= default;
            AddUser_Admin.BorderBrush = default;
            AddItemBT.BorderBrush = new SolidColorBrush(Colors.Green);
           

            Menubar_frame.Navigate(new AddItem() );
        }

        private void add_User_Click(object sender, RoutedEventArgs e)
        {
            Profil_bt.BorderBrush = default;
            AddItemBT.BorderBrush = default;
            AddUser_Admin.BorderBrush = new SolidColorBrush(Colors.Green);
            Menubar_frame.Navigate(new AddUser());
        }
    }
}
