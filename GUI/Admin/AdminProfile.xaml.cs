using Logic;
using Logic.Entities;
using Logic.Vehicle;
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
    /// Interaction logic for AdminProfile.xaml
    /// </summary>
    public partial class AdminProfile : Page
    {
        private Dictionary<string, Components> _komponentdb;
        private Dictionary<string, VehicleCase> _casedb;
        private Dictionary<string, Mechanic> _mechanicdb;
        private Dictionary<string, User> _userdb;
        private Dictionary<string, string> _regdb;
        public AdminProfile()
        {
            InitializeComponent();
            Adminfo();
            MekanikInfo();
       
        }


        private void MekanikInfo()
        {
            



        }


        private void Adminfo()
        {
            Tb_date_today.Content = $"Idag är {DateTime.Now.ToString("D")} ";
        }
    }
}
