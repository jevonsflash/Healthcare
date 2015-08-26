using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Healthcare.Resources;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Healthcare.JMessbox;

namespace Healthcare
{
    public partial class MainPage : PhoneApplicationPage
    {
        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            InitBGStyle();

            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
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

        private static void InitTextBlockStyle(object sender, bool isFoc)
        {
            Color transparentColor = Colors.Transparent;
            SolidColorBrush transparentBrush = new SolidColorBrush(transparentColor);
            //SolidColorBrush PhoneBackgroundBrush = Application.Current.Resources["PhoneBackgroundBrush"] as SolidColorBrush;
            (sender as Control).Background = transparentBrush;
            (sender as TextBox).SelectionBackground = transparentBrush;
            (sender as Control).BorderBrush = transparentBrush;
            if (string.IsNullOrEmpty((sender as TextBox).Text))
            {
                (sender as TextBox).Text = "如：“发热”，“小儿”";

            }

            if (isFoc)
            {
                Color whiteColor = Colors.White;
                whiteColor.A = 45;
                SolidColorBrush whiteBrush = new SolidColorBrush(whiteColor);
                ((sender as Control).Parent as Border).Background = whiteBrush;
                if ((sender as TextBox).Text == "如：“发热”，“小儿”")
                {
                    (sender as TextBox).Text = string.Empty;
                }
            }
            else
            {
                ((sender as Control).Parent as Border).Background = transparentBrush;

            }

        }
        private void InitBGStyle()
        {

            BitmapImage bi01 = new BitmapImage(new Uri("img/metro.png", UriKind.Relative));
            ImageBrush ib01 = new ImageBrush();
            ib01.ImageSource = bi01;
            ib01.Opacity = 10;
            this.PanoramaMain.Background = ib01;
        }

        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {
            if (this.TBMainSearch.Text == "如：“发热”，“小儿”" || string.IsNullOrEmpty(this.TBMainSearch.Text))
            {
                JMessBox jb = new JMessBox("请输入内容");
                jb.Show();
            }
            else
            {
                string type = typeof(Model.DiseaseListItem).Name;
                string destination = "/GeneralResultPage.xaml";
                destination += string.Format("?keyword={0}?type={1}", this.TBMainSearch.Text,type);
                NavigationService.Navigate(new Uri(destination, UriKind.Relative));
            }

        }


        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;

            JMessBox jb = new JMessBox("再按一次离开");
            jb.Completed += (b) =>
            {
                if (b)
                {
                    //退出代码

                    Application.Current.Terminate();
                }
            };
            jb.Show();
        }
    }
}