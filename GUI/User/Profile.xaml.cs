using GUI.Home;
using GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace GUI.Pages
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : Page
    {

        public  Profile()
        {
            InitializeComponent();


            //var curentuser = (User)HomePage._GCU[2];

            //if (!curentuser.UserType.Equals(Enum.GetName(typeof(IUserDataAccess.TypeOfUser), 1))) { Userinfo(); Userskills(); }     


            //if (_closedC.Where(x=>x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Count() > 0) { cb_finshed_case.IsEnabled = true; cb_finshed_case.ItemsSource = _closedC.Where(x => x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Select(x => x.Key); }

        }



        private void Userinfo()
        {
            //_mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic mkObj);
            //tb_username.Content = mkObj.Namn;
            //tb_useremail.Content = _userdb.Where(x => x.Value.UserId.Equals(HomePage._GCU[1].ToString())).Select(x => x.Key).ToArray()[0];
            //tb_userbirth.Content = mkObj.Birthdate;
            ////tb_usertotal_case.Content = _closedC.Where(x => x.Value.Mechanic_ID.Equals(HomePage._GCU[1])).Count();
            //tb_resignmentdate.Content = mkObj.LastDate;

            ////tb_case1_Info.Content = mkObj.Vehicles_case[0];
            ////tb_case2_Info.Content = mkObj.Vehicles_case[1];
        }

        private void Userskills()
        {
            //_mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic _mekObj);



        }

        private void BT_chnageSkills_Click(object sender, RoutedEventArgs e)
        {
            //_mechanicdb.TryGetValue(HomePage._GCU[1].ToString(), out Mechanic _mekObj);

            string msg = $"Vill du ändra dina kompetens ?";
            string result = MessageBox.Show(msg, "Bekräftelse", MessageBoxButton.YesNo, MessageBoxImage.Question).ToString();



            if (result.Equals("Yes"))
            {


                //_mechanicdb.Remove(HomePage._GCU[1].ToString());

                //_mechanicdb.Add(HomePage._GCU[1].ToString(), _mekObj);

                //IUserDataAccess.Write<string, Mechanic>(_mechanicdb, Enum.GetName(typeof(IUserDataAccess.File_Type), 2));

            }






        }

        private void cb_borrowed_book_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
