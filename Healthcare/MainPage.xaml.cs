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
        private static LoreServer loreser = new LoreServer();

        // 构造函数
        public MainPage()
        {
            InitializeComponent();
            this.TBVersion.Text = (Application.Current as App).V;
            // 用于本地化 ApplicationBar 的示例代码
            //BuildLocalizedApplicationBar();
            int page = 1;
            string url1 = StaticURLHelper.InfoList;
            string url2 = StaticURLHelper.LoreList;
            HttpHelper ht = new HttpHelper();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("page", page.ToString());
            ht.CreatePostHttpResponse(url1, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;

            HttpHelper ht2 = new HttpHelper();
            Dictionary<string, string> dic2 = new Dictionary<string, string>();
            dic2.Add("page", page.ToString());
            ht2.CreatePostHttpResponse(url2, dic2);
            ht2.FileWatchEvent += Ht_FileWatchEvent2;
            MessageBox.Show((App.RootFrame.Foreground as SolidColorBrush).Color.ToString());

        }

        private void Ht_FileWatchEvent2(object sender, CompleteEventArgs e)
        {
            List<LoreShowItem> temp = loreser.LoreShowDeserializer(e.Node).ToList();
            this.Dispatcher.BeginInvoke(() =>
            {
                this.LBLore.ItemsSource = temp.Select(c => new
                {
                    id = c.id,
                    title = c.title,
                    time = TimeHelper.TimeStamptoDateTime(c.time.ToString()).ToString("MM月dd日"),
                    count = c.count,
                    rcount = c.rcount
                });

            });
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

        private void BTN药品查询_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/DrugSubPage.xaml";
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


        private void HyperlinkButton_Click(object sender, RoutedEventArgs e)
        {
            string destination = "/AboutPage.xaml";
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }
        private void LBInfo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string parmId = ((sender as ListBox).SelectedItem as dynamic).id.ToString();
            string destination = "/InfoDetailPage.xaml";
            destination += string.Format("?id={0}&type={1}", parmId, "Info");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }

        private void LBLore_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string parmId = ((sender as ListBox).SelectedItem as dynamic).id.ToString();
            string destination = "/InfoDetailPage.xaml";
            destination += string.Format("?id={0}&type={1}", parmId, "Lore");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }
    }
}