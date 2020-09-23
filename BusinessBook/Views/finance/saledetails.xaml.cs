﻿
using BusinessBook.bll;
using BusinessBook.data;
using System;
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
using System.Windows.Shapes;

namespace BusinessBook.Views.finance
{
    /// <summary>
    /// Interaction logic for saledetails.xaml
    /// </summary>
    public partial class saledetails : Window
    {
        public int saleid;
        List<data.dapper.financeaccount> financeaccounts = null;
        public saledetails(int saleId)
        {
            InitializeComponent();
            var financeaccountrepo = new data.dapper.financeaccountrepo();
            var financetransactionrepo = new data.dapper.financetransactionrepo();
            var salepurchaseproductrepo = new data.dapper.salepurchaseproductrepo();
            //var financetransactions = financetransactionrepo.get();
            financeaccounts = financeaccountrepo.get();

            saleid = saleId;
           // var db = new dbctx();
            //var productsinsale = db.salepurchaseproduct.Where(a => a.fk_financetransaction_salepurchaseproduct_financetransaction == saleid).ToList();
            var productsinsale = salepurchaseproductrepo.getmultiplebytransactionid(saleid);
            foreach (var item in productsinsale)
            {
                dg.Items.Add(item);
            }
        }
        public void printPeceipt(object sender, RoutedEventArgs e)
        {
            saleutils.printDuplicateRecipt(saleid);
        }
    }
}