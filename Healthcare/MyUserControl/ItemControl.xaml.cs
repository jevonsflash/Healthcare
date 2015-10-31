using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Diagnostics;

namespace Healthcare.MyUserControl
{
    public partial class ItemControl : UserControl
    {
        private string title;
        private string con;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        public string Con
        {
            get { return con; }
            set { con = value; }
        }

        public ItemControl(string title, string con)
        {
            this.Title = title;
            this.Con = con;
            InitializeComponent();
            Loaded += ItemControl_Loaded;
        }

        private void ItemControl_Loaded(object sender, RoutedEventArgs e)
        {
            this.TBTitle.Text = Title;
            this.TBCon.Text = Con;
            Debug.WriteLine("当前ItemBlock高度"+this.ItemBlock.ActualHeight);
        }
       

        private void BTNFlip_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.BTNFlip.IsChecked)
            {
                this.TBCon.MaxHeight = 0;
            }
            else
            {
                this.TBCon.MaxHeight = double.MaxValue;

            }

        }
    }
}
