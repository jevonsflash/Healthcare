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
using System.Windows.Media.Imaging;
using Healthcare.JMessbox;
using Healthcare.Helper;
using System.Threading.Tasks;
using Healthcare.Server;
using Healthcare.Model;

namespace Healthcare
{
    public partial class GeneralResultPage : PhoneApplicationPage
    {
        private MapServer mapser = new MapServer();
        private int filterNum;
        private string keyword;
        private string type;
        private MyUserControl.FilterSelectorControl oItem;

        public GeneralResultPage()
            : base()
        {
            InitializeComponent();
            InitBGStyle();
        }

        #region 事件

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

        private async void BTNSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = this.TBMainSearch.Text;
            await Render();
        }

        private void LLSResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idStr = ((sender as LongListSelector).SelectedItem as Model.KeyWordsMap).id.ToString();
            string destination = "/GeneralDetailPage.xaml";
            destination += string.Format("?id={0}&type={1}", idStr, type);
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if (parameters.ContainsKey("type"))
            {
                type = (parameters["type"] as string);
            }
            if (parameters.ContainsKey("keyword"))
            {
                keyword = (parameters["keyword"] as string);
            }
            this.TBMainSearch.Text = keyword;
            await Render();

            base.OnNavigatedTo(e);

        }

        private async Task Render()
        {
            List<Model.KeyWordsMap> result = await GetData(keyword);
            if (result.Count == 0)
            {
                this.MsgBox.Visibility = Visibility.Visible;
                this.MsgBox.TBMessage.Text = string.Format("找不到内容：{0}", keyword);
            }
            else
            {
                this.MsgBox.Visibility = Visibility.Collapsed;
            }
            this.Dispatcher.BeginInvoke(() =>
            {
                this.LLSResult.ItemsSource = result;
                InitFilterButton("", "");
            });
        }
        private void BTNMore_Click(object sender, RoutedEventArgs e)
        {
            if ((Application.Current.RootVisual as PhoneApplicationFrame) != null)
            {
                (Application.Current.RootVisual as PhoneApplicationFrame).RemoveBackEntry();
            }
            string destination = "/GeneralResultPage.xaml";
            destination += string.Format("?keyword={0}&type={1}", keyword, "Disease");
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            if ((Application.Current.RootVisual as PhoneApplicationFrame) != null)
            {
                (Application.Current.RootVisual as PhoneApplicationFrame).RemoveBackEntry();
            }
            string destination = "/MainPage.xaml";
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }
        private async void BTNFilter_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[0]) || string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[1]))
            {
                return;
            }
            filterNum = 0;
            List<BaseMap> list = await mapser.ReadFilterMap(FilterHelper.GetFilterName(type)[0].Split('|')[0]);
            InitFilterControl(list);
        }
        private async void BTNFilter2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[0]) || string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[1]))
            {
                return;
            }
            filterNum = 1;
            List<BaseMap> list = await mapser.ReadFilterMap(FilterHelper.GetFilterName(type)[1].Split('|')[0]);
            InitFilterControl(list);
        }


        private void OItem_OnData2Changed(object sender, SelectionChangedEventArgs e)
        {
            string id = ((sender as ListBox).SelectedItem as BaseMap).id.ToString();
            string name = ((sender as ListBox).SelectedItem as BaseMap).name;
            HttpHelper ht = new HttpHelper();
            string url = StaticURLHelper.GetURL(type)[1];
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;
            this.LayoutRoot.Children.Remove(oItem);
            if (filterNum == 0)
            {
                InitFilterButton(name, "");
            }
            else if (filterNum == 1)
            {
                InitFilterButton("", name);
            }

        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            List<Model.KeyWordsMap> result = GetData(keyword, e.Node);


            this.Dispatcher.BeginInvoke(() =>
            {
                if (result.Count == 0)
                {
                    this.MsgBox.Visibility = Visibility.Visible;
                    this.MsgBox.TBMessage.Text = string.Format("找不到内容：{0}", keyword);
                }
                else
                {
                    this.MsgBox.Visibility = Visibility.Collapsed;
                }
                this.LLSResult.ItemsSource = result;
            });

        }

        private void OItem_OnData1Changed(object sender, SelectionChangedEventArgs e)
        {
            List<BaseMap> subList = ((sender as ListBox).SelectedItem as BaseMap).BaseMaps;

        }
        private void OItem_OnCancel(object sender, RoutedEventArgs e)
        {
            this.LayoutRoot.Children.Remove(oItem);

        }

        #endregion
        #region 方法
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
        private void InitBGStyle()
        {
            BitmapImage bi01 = new BitmapImage(new Uri("img/metro.png", UriKind.Relative));
            ImageBrush ib01 = new ImageBrush();
            ib01.ImageSource = bi01;
            ib01.Opacity = 10;
            this.LayoutRoot.Background = ib01;
        }
        private void InitFilterControl(List<BaseMap> list)
        {
            oItem = new MyUserControl.FilterSelectorControl(list);

            oItem.OnData1Changed += OItem_OnData1Changed;
            oItem.OnData2Changed += OItem_OnData2Changed;
            oItem.OnCancel += OItem_OnCancel;
            this.LayoutRoot.Children.Add(oItem);
            Grid.SetRow(oItem, 1);
            this.Dispatcher.BeginInvoke(() =>
            {
                oItem.LBSelector1.Items.Clear();
                oItem.LBSelector1.ItemsSource = list;
            });
        }

        private void InitFilterButton(string content1, string content2)
        {
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[0]))
            {
                this.BTNFilter.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.BTNFilter.Content = string.Format("{0}:{1}", FilterHelper.GetFilterName(type)[0].Split('|')[1], string.IsNullOrEmpty(content1) ? "全部" : content1);
            }
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[1]))
            {
                this.BTNFilter2.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.BTNFilter2.Content = string.Format("{0}:{1}", FilterHelper.GetFilterName(type)[1].Split('|')[1], string.IsNullOrEmpty(content2) ? "全部" : content2);
            }
        }

        private async Task<List<Model.KeyWordsMap>> GetData(string keyword)
        {
            List<Model.KeyWordsMap> list = await mapser.ReadKeywordsMap(type);
            if (string.IsNullOrEmpty(keyword))
            {
                return list;
            }
            else
            {
                return list.FindAll(c => c.keywords.Contains(keyword));
            }

        }
        private List<Model.KeyWordsMap> GetData(string keyword, string jsonStr)
        {
            List<KeyWordsMap> list = DeserializeHelper.GetMap(type, jsonStr);
            if (string.IsNullOrEmpty(keyword))
            {
                return list;
            }
            else
            {
                return list.FindAll(c => c.keywords.Contains(keyword));
            }
        }
        #endregion

    }
}