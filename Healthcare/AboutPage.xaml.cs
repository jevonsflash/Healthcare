﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Microsoft.Phone.Tasks;

namespace Healthcare
{
    public partial class AboutPage : PhoneApplicationPage
    {
        private string v = (Application.Current as App).V;
        public AboutPage()
        {
            InitializeComponent();
            this.TBVersion.Text = v;
            this.TBVersion2.Text = v;
        }


        private void BTNMail_Click(object sender, RoutedEventArgs e)
        {
            EmailComposeTask ect01 = new EmailComposeTask();
            ect01.To = "jevons@hotmail.com";
            ect01.Show();
        }

        private void BTNLove_Click(object sender, RoutedEventArgs e)
        {
            MarketplaceReviewTask marketplaceReviewTask = new MarketplaceReviewTask();
            marketplaceReviewTask.Show();

        }

        private void BTNWeibo_Click(object sender, RoutedEventArgs e)
        {
            WebBrowserTask wbt01 = new WebBrowserTask();
            UriBuilder uriSite = new UriBuilder("http://weibo.com/jevonsflash");
            wbt01.Uri = uriSite.Uri;
            wbt01.Show();

        }
    }
}