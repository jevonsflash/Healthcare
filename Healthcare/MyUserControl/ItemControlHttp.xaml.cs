using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Healthcare.Helper;

namespace Healthcare.MyUserControl
{
    public partial class ItemControlHttp : UserControl
    {
        private string title;
        private string con;

        public string Title {
            get { return title; }
            set { title = value; }
        }
        public string Con
        {
            get { return con; }
            set { con = value; }
        }

        public ItemControlHttp(string title,string con)
        {
            this.Title = title;
            this.Con = con;
            InitializeComponent();
            Loaded += ItemControlHttp_Loaded;
        }

        private void ItemControlHttp_Loaded(object sender, RoutedEventArgs e)
        {
            this.TBTitle.Text = Title;
            Uri uri = HtmlHelper.StrToHTML(con);
            this.Dispatcher.BeginInvoke(() =>
            {

                this.WBCon.Navigate(uri);
            });
        }
        private void BTNFlip_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.BTNFlip.IsChecked)
            {
                this.WBCon.MaxHeight = 0;
            }
            else
            {
                this.WBCon.MaxHeight = double.MaxValue;

            }

        }

    }
}
