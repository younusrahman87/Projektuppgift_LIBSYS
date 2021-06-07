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

        private Dictionary<string, string> _regdb;
        public AdminProfile()
        {
            InitializeComponent();
            Adminfo();
            
       
        }


       


        private void Adminfo()
        {
            Tb_date_today.Content = $"Idag är {DateTime.Now.ToString("D")} ";
        }
    }
}
