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
using Healthcare.Helper;
using Healthcare.Model;
using Healthcare.Server;

namespace Healthcare
{
    public partial class MainPage : PhoneApplicationPage
    {
        private static InfoServer infoser = new InfoServer();

        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            InitBGStyle();
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            int page = 1;
            HttpHelper ht = new HttpHelper();
            string url = "http://www.tngou.net/api/info/list";
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("page", page.ToString());
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;
        }
        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            List<InfoShowItem> temp = infoser.InfoShowDeserializer(e.Node).ToList();
            this.Dispatcher.BeginInvoke(() =>
            {
                this.LBInfo.ItemsSource = temp.Select(c => new
                {
                    id = c.id,
                    title = c.title,
                    time = TimeHelper.TimeStamptoDateTime(c.time.ToString()).ToString("MM月dd日"),
                    count = c.count,
                    rcount = c.rcount
                });

            });
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
                string destination = "/GeneralResultPage.xaml";
                destination += string.Format("?keyword={0}&type={1}", this.TBMainSearch.Text, "Symptom");
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

        private void LBInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string parmId = ((sender as ListBox).SelectedItem as dynamic).id.ToString();
            string destination = "/InfoDetailPage.xaml";
            destination += string.Format("?id={0}", parmId);
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void BTN检查项目_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Check");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void BTN手术项目_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Operation");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void BTN食疗大全_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Cook");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));


        }

        private void BTN健康食品_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Food");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));


        }

        private void BTN健康知识_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", string.Empty, "Operation");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));


        }
    }
}