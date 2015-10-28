using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Healthcare
{
    public partial class DrugSubPage : PhoneApplicationPage
    {
        private PhoneApplicationService phoneser = new PhoneApplicationService();

        public DrugSubPage()
        {
            InitializeComponent();
        }

        private void BTNDrug_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Drug");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void BTNDrugNumber_Click(object sender, RoutedEventArgs e)
        {
            phoneser.State.Add("number",)
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "DrugNumber");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void BTNDrugCode_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "DrugCode");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }
    }
}