﻿using GUI.Home;
using GUI.Models;
using System;
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
using Logic;

namespace GUI.Login
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private dynamic _loginService;


        public LoginPage()
        {

            InitializeComponent();
            this.tbUsernam.Focus();



        }




        private void Shoutdown_BT_Click(object sender, RoutedEventArgs e)
        {
            App.Current.MainWindow.Close();
        }


        private void Login_Click(object sender, RoutedEventArgs e)
        {



            NavigationService.Navigate(new HomePage());

        }


        private void ButtonTest_Click(object sender, RoutedEventArgs e)
        {
            var test = new Test();
            test.NewMethod();
        }


        private void Search_BT_Click(object sender, RoutedEventArgs e)
        {
            if (SearchDetailsFount.Visibility == Visibility.Collapsed) { SearchDetailsFount.Visibility = Visibility.Visible; logoimage.Visibility = Visibility.Collapsed; }
            else { SearchDetailsFount.Visibility = Visibility.Collapsed; logoimage.Visibility = Visibility.Visible; }
        }
    }
}
    

