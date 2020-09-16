﻿using System;
using System.Collections.Generic;
using System.Linq;
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
using RIAB_Restaurent_Management_System.Views;
using System.Globalization;

using RIAB_Restaurent_Management_System.bll;
using RIAB_Restaurent_Management_System.data;
using RIAB_Restaurent_Management_System.Properties;
using Telerik.Windows.Controls;
using RIAB_Restaurent_Management_System.Views.others;
using RIAB_Restaurent_Management_System.data.dapper;
using System.Dynamic;

namespace RIAB_Restaurent_Management_System
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            RadDesktopAlertManager manager = new RadDesktopAlertManager();
            var currentdate = DateTime.Now;
            var lastsaveddate = Settings.Default.lastsavedate;
            var activationdate = Settings.Default.activationdate;
            var expireindays = Settings.Default.expireindays;
            var activationdatecheck = activationdate.AddDays(expireindays);
            if (currentdate < lastsaveddate) 
            {
                var alert = new RadDesktopAlert();
                alert.Header = "Business Book Alert";
                alert.Content = "Please correct your system date first";
                alert.ShowDuration = 30000;
                System.Media.SystemSounds.Hand.Play();
                manager.ShowAlert(alert);
                Close();
            }
            else
            {
                Settings.Default.lastsavedate = DateTime.Now;
                Settings.Default.Save();
                var expireddifference = (activationdatecheck - currentdate).TotalDays;
                if (expireddifference < 0)
                {
                    InitializeComponent();
                    tb_Name.Focus();

                }
                else if (expireddifference < 7) 
                {
                    InitializeComponent();
                    tb_Name.Focus();
                    var alert = new RadDesktopAlert();
                    alert.Header = "Business Book Alert";
                    alert.Content = "Your licence has been expired. Please renew licence";
                    alert.ShowDuration = 30000;
                    System.Media.SystemSounds.Hand.Play();
                    manager.ShowAlert(alert);
                }
                else {

                    new registersoftware().Show();
                    var alert = new RadDesktopAlert();
                    alert.Header = "Business Book Alert";
                    alert.Content = "Your licence has been expired. Please renew licence";
                    alert.ShowDuration = 30000;
                    System.Media.SystemSounds.Hand.Play();
                    manager.ShowAlert(alert);
                }
            }
        }

        private void btn_Login(object sender, RoutedEventArgs e)
        {
            login();
        }

        private void btn_CloseApplication(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void PressEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter) 
            {
                login();
            }
        }
        void login() 
        {
            //int nextMonthInt = Convert.ToInt32(DateTime.Now.ToString("MM")) + 1;
            //string nextMonthString = Convert.ToString(nextMonthInt);
            //char[] monthNameArray = DateTime.Now.ToString("MMM", CultureInfo.InvariantCulture).ToCharArray();
            //char secondCharacterofMonth = monthNameArray[1];
            //string password = nextMonthString + secondCharacterofMonth;



            //var db = new dbctx();
            //data.user user = db.user.Where(a => (a.username == tb_Name.Text && a.password == tb_Pasword.Password)).FirstOrDefault();
            data.dapper.user userd = new  data.dapper.userrepo().get(tb_Name.Text, tb_Pasword.Password);
            int i = 0;
            if (userd != null) {
            userutils.loggedinuserd = userd;
                new RMS().Show();
                Close();
            }
            else
            {
                    MessageBox.Show("Username or password not exists", "Failed");

            }

            //if (tb_Name.Text == "admin")
            //{
            //    DateTime licenceDate = new DateTime(2022, 3, 1);
            //    if (tb_Pasword.Password == MyPrinterSetting.Pass)
            //    {
            //        //new RMS().Show();
            //        //Close();
            //        if (DateTime.Now < licenceDate)
            //        {
            //            new RMS().Show();
            //            Close();
            //        }
            //        else
            //        {
            //            BLL.AutoClosingMessageBox.Show("Please renew Licence", "Failed", 3000);
            //        }

            //    } else if (tb_Pasword.Password == "adminmasterpassword")
            //    {
            //        //new RMS().Show();
            //        //Close();
            //        if (DateTime.Now < licenceDate)
            //        {
            //            new RMS().Show();
            //            Close();
            //        }
            //        else
            //        {
            //            BLL.AutoClosingMessageBox.Show("Please renew Licence", "Failed", 3000);
            //        }
            //    }
            //}
            //else if (tb_Name.Text == "user")
            //{
            //    if (tb_Pasword.Password == "12345")
            //    {
            //        new User().Show();
            //        Close();
            //    }
            //}
            //else
            //{
            //    BLL.AutoClosingMessageBox.Show("Wrong User Name and Password", "Failed", 3000);
            //}
        }
    }
}
