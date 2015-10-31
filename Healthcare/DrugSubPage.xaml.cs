using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Media;
using Healthcare.JMessbox;

namespace Healthcare
{
    public partial class DrugSubPage : PhoneApplicationPage
    {
        private bool isByKeywords;
        public DrugSubPage()
        {
            InitializeComponent();
            this.BTNDrug.IsChecked = true;
            isByKeywords = (bool)this.BTNDrug.IsChecked;
        }
        private void TBMainSearch_GotFocus(object sender, RoutedEventArgs e)
        {
            InitTextBlockStyle(sender, true);

        }

        private void TBMainSearch_LostFocus(object sender, RoutedEventArgs e)
        {
            InitTextBlockStyle(sender, false);
        }

        private void TBMainSearch_Loaded(object sender, RoutedEventArgs e)
        {
            InitTextBlockStyle(sender, false);

        }
        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(this.TBMainSearch.Text))
            {
                JMessBox jb = new JMessBox("请输入内容");
                jb.Show();
            }
            else
            {
                string destination = "/DrugResultPage.xaml";

                if (isByKeywords)
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("name", "drug");
                    dic.Add("keyword", this.TBMainSearch.Text);
                    PhoneApplicationService.Current.State["dic"] = dic;
                    destination += string.Format("?type={0}", "Drug");

                }
                else
                {
                    Dictionary<string, string> dic = new Dictionary<string, string>();
                    dic.Add("number", "国药准字Z" + this.TBMainSearch.Text);
                    PhoneApplicationService.Current.State["dic"] = dic;
                    destination += string.Format("?type={0}", "DrugNumber");


                }



                NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            }

        }

        private void BTNDrug_Click(object sender, RoutedEventArgs e)
        {
            this.BTNDrugNumber.IsChecked = !this.BTNDrug.IsChecked;
            isByKeywords = (bool)this.BTNDrug.IsChecked;
            this.TBPrefix.Visibility = isByKeywords ? Visibility.Collapsed : Visibility.Visible;
        }

        private void BTNDrugNumber_Click(object sender, RoutedEventArgs e)
        {
            this.BTNDrug.IsChecked = !this.BTNDrugNumber.IsChecked;
            isByKeywords = (bool)this.BTNDrug.IsChecked;
            this.TBPrefix.Visibility = isByKeywords ? Visibility.Collapsed : Visibility.Visible;

        }

        private void BTNDrugCode_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/BarCode.xaml", UriKind.Relative));

        }
        private static void InitTextBlockStyle(object sender, bool isFoc)
        {
            Color transparentColor = Colors.Transparent;
            SolidColorBrush transparentBrush = new SolidColorBrush(transparentColor);
            //SolidColorBrush PhoneBackgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            (sender as Control).Background = transparentBrush;
            (sender as TextBox).SelectionBackground = transparentBrush;
            (sender as Control).BorderBrush = transparentBrush;
            if (isFoc)
            {
                Color whiteColor = Colors.White;
                whiteColor.A = 45;
                SolidColorBrush whiteBrush = new SolidColorBrush(whiteColor);
                ((sender as Control).Parent as Border).Background = whiteBrush;
            }
            else
            {
                ((sender as Control).Parent as Border).Background = transparentBrush;

            }

        }

    }
}