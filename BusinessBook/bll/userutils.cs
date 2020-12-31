﻿using BusinessBook.data.dapper;
using BusinessBook.data.viewmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Telerik.Windows.Controls;

namespace BusinessBook.bll
{
    public class userutils
    {
        //public static data.user loggedinuser { get; set; }
        public static data.dapper.user loggedinuserd { get; set; }
        public static string membership { get; set; }
        public static softwaresetting ravicosoftuserid;
        public static softwaresetting ravicosoftusername;
        public static softwaresetting ravicosoftpassword;
        public static softwaresetting ravicosoftbusinessbookmembershipplan;
        public static softwaresetting ravicosoftbusinessbookmembershipexpirydate;
        public static softwaresetting ravicosoftbusinessbookcanrun;
        public static softwaresetting ravicosoftsmsplan;
        public static softwaresetting apiendpoint;

        public static void authorizerole(Window window, string[] roles)
        {

            if (roles.Contains(loggedinuserd.role))
            {
                window.Show();
            }
            else
            {
                RadDesktopAlertManager manager = new RadDesktopAlertManager();
                var alert = new RadDesktopAlert();
                alert.Header = "Alert";
                alert.Content = "This page can only accessed by " + String.Join(",", roles);
                alert.ShowDuration = 5000;
                System.Media.SystemSounds.Hand.Play();
                manager.ShowAlert(alert);
            }
        }
        public static void authorizeroleandmembership(Window window, string[] roles, string[] membershiptypes)
        {
            bool roleok = false;
            bool membershipokok = false;
            if (roles.Contains(loggedinuserd.role))
            {
                roleok = true;
            }
            if (membershiptypes.Contains(membership))
            {
                membershipokok = true;
            }
            if (roleok && membershipokok)
            {
                window.Show();
            }
            else
            {
                RadDesktopAlertManager manager = new RadDesktopAlertManager();
                var alert = new RadDesktopAlert();
                alert.Header = "Alert";
                alert.Content = "This page can only accessed by " + String.Join(",", roles);
                alert.ShowDuration = 5000;
                System.Media.SystemSounds.Hand.Play();
                manager.ShowAlert(alert);
            }
        }

        public static bool checkravicosoftuseridexits() 
        {
            var ravicosoftuser = ravicosoftuserid;
            if (ravicosoftuser == null)
            {
                return false;
            }
            else {
                return true;
            }
        }
        public static void loadsoftwaresetting()
        {
            var ssr = new softwaresettingrepo();
            ravicosoftuserid = ssr.getbyname(commonsettingfields.ravicosoftuserid);
            ravicosoftusername = ssr.getbyname(commonsettingfields.ravicosoftusername);
            ravicosoftpassword = ssr.getbyname(commonsettingfields.ravicosoftpassword);
            ravicosoftbusinessbookmembershipplan = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookmembershipplan);
            ravicosoftbusinessbookmembershipexpirydate = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookmembershipexpirydate);
            ravicosoftbusinessbookcanrun = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookcanrun);
            ravicosoftsmsplan = ssr.getbyname(commonsettingfields.ravicosoftsmsplan);
            apiendpoint = ssr.getbyname(commonsettingfields.apiendpoint);

        }
        public static void updateapiendpoint(string newurl)
        {
            var ssr = new softwaresettingrepo();
            if (apiendpoint == null)
            {
                var ss = new softwaresetting() { name = commonsettingfields.apiendpoint, valuetype = "string", stringvalue = newurl };
                apiendpoint = ssr.save(ss);
            }
            else
            {
                apiendpoint.stringvalue = newurl;
                apiendpoint = ssr.update(apiendpoint);
            }
        }

        public static void updateusersetting(apiresponseuserclass user) 
        {
            softwaresettingrepo ssr = new softwaresettingrepo();
            var ravicosoftuserid = ssr.getbyname(commonsettingfields.ravicosoftuserid);
            if (ravicosoftuserid == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftuserid;
                ss.valuetype = "string";
                ss.stringvalue = user._id;
                userutils.ravicosoftuserid = ssr.save(ss);
            }
            else
            {
                ravicosoftuserid.valuetype = "string";
                ravicosoftuserid.stringvalue = user._id;
                userutils.ravicosoftuserid = ssr.update(ravicosoftuserid);
            }

            var username = ssr.getbyname(commonsettingfields.ravicosoftusername);
            if (username == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftusername;
                ss.valuetype = "string";
                ss.stringvalue = user.username;
                userutils.ravicosoftusername = ssr.save(ss);
            }
            else
            {
                username.valuetype = "string";
                username.stringvalue = user.username;
                userutils.ravicosoftuserid = ssr.update(username);
            }


            var userpassword = ssr.getbyname(commonsettingfields.ravicosoftpassword);
            if (userpassword == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftpassword;
                ss.valuetype = "string";
                ss.stringvalue = user.password;
                userutils.ravicosoftpassword = ssr.save(ss);
            }
            else
            {
                userpassword.valuetype = "string";
                userpassword.stringvalue = user.password;
                userutils.ravicosoftpassword = ssr.update(userpassword);
            }

            var membershiptype = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookmembershipplan);
            if (membershiptype == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftbusinessbookmembershipplan;
                ss.valuetype = "string";
                ss.stringvalue = user.businessbookmembershipplan;
                userutils.ravicosoftbusinessbookmembershipplan = ssr.save(ss);
            }
            else
            {
                userpassword.valuetype = "string";
                userpassword.stringvalue = user.businessbookmembershipplan;
                userutils.ravicosoftbusinessbookmembershipplan = ssr.update(membershiptype);
            }

            membershiptype = userutils.ravicosoftbusinessbookmembershipplan;
            if (membershiptype.stringvalue == "Package 2" || membershiptype.stringvalue == "Package 3" || membershiptype.stringvalue == "Package 4")
            {
                if (user.businessbookmembershipexpirydate != null)
                {
                    var membershipexpirydate = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookmembershipexpirydate);
                    if (membershipexpirydate == null)
                    {
                        var ss = new softwaresetting();
                        ss.name = commonsettingfields.ravicosoftbusinessbookmembershipexpirydate;
                        ss.valuetype = "date";
                        ss.datevalue = user.businessbookmembershipexpirydate;
                        userutils.ravicosoftbusinessbookmembershipexpirydate = ssr.save(ss);
                    }
                    else
                    {
                        membershipexpirydate.valuetype = "date";
                        membershipexpirydate.datevalue = user.businessbookmembershipexpirydate;
                        userutils.ravicosoftbusinessbookmembershipexpirydate = ssr.update(membershipexpirydate);
                    }
                }
            }



            var canrunsoftware = ssr.getbyname(commonsettingfields.ravicosoftbusinessbookcanrun);
            if (canrunsoftware == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftbusinessbookcanrun;
                ss.valuetype = "string";
                ss.stringvalue = user.businessbookcanrun;
                userutils.ravicosoftbusinessbookcanrun = ssr.save(ss);
            }
            else
            {
                canrunsoftware.valuetype = "string";
                canrunsoftware.stringvalue = user.businessbookcanrun;
                userutils.ravicosoftbusinessbookcanrun = ssr.update(canrunsoftware);
            }


            var cansendsms = ssr.getbyname(commonsettingfields.ravicosoftsmsplan);
            if (cansendsms == null)
            {
                var ss = new softwaresetting();
                ss.name = commonsettingfields.ravicosoftsmsplan;
                ss.valuetype = "string";
                ss.stringvalue = user.smsplan;
                userutils.ravicosoftsmsplan = ssr.save(ss);
            }
            else
            {
                cansendsms.valuetype = "string";
                cansendsms.stringvalue = user.smsplan;
                userutils.ravicosoftsmsplan = ssr.update(cansendsms);
            }
        }
    }
    
}
