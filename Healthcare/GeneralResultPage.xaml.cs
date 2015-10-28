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
        private int filterNum;//0,1,2
        private string keyword = string.Empty;
        private string type = string.Empty;
        private string strId = string.Empty;
        private MyUserControl.FilterSelectorControl oItem;
        private List<Model.KeyWordsMap> result;
        public GeneralResultPage()
            : base()
        {
            InitializeComponent();
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

        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {
            keyword = this.TBMainSearch.Text;
            Render();
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
            if (parameters.ContainsKey("id"))
            {
                strId = (parameters["id"] as string);
            }
            this.TBMainSearch.Text = keyword;
            InitFilterButton("", "", "");
            result = await GetData(keyword);
            if (result != null)
            {
                Render();
            }
            else
            {
                string url = string.Empty;
                url = StaticURLHelper.GetURL(type).List;
                Dictionary<string, string> dic = new Dictionary<string, string>();
                if (!string.IsNullOrEmpty(strId))
                {
                    dic.Add("id", strId);
                }
                GetJSON(url, dic);
            }
            base.OnNavigatedTo(e);
        }

        private void Render()
        {
            List<Model.KeyWordsMap> renderResult = new List<KeyWordsMap>();

            if (!string.IsNullOrEmpty(keyword))
            {
                renderResult = result.FindAll(c => c.keywords.Contains(keyword));
            }
            else
            {
                renderResult = result;
            }
            this.Dispatcher.BeginInvoke(() =>
            {
                InitMsg(renderResult.Count == 0);
                this.LLSResult.ItemsSource = renderResult;
                //SetFilterButton();

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
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[0]))
            {
                return;
            }
            filterNum = 0;
            List<BaseMap> list = await mapser.ReadFilterMap(FilterHelper.GetFilterName(type)[0].Split('|')[0]);
            InitFilterControl(list);
        }
        private async void BTNFilter2_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[1]))
            {
                return;
            }
            filterNum = 1;
            List<BaseMap> list = await mapser.ReadFilterMap(FilterHelper.GetFilterName(type)[1].Split('|')[0]);
            InitFilterControl(list);
        }
        private async void BTNFilter3_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[2]))
            {
                return;
            }
            filterNum = 2;
            List<BaseMap> list = await mapser.ReadFilterMap(FilterHelper.GetFilterName(type)[2].Split('|')[0]);
            InitFilterControl(list);

        }


        private void OItem_OnData2Changed(object sender, SelectionChangedEventArgs e)
        {
            string id = ((sender as ListBox).SelectedItem as BaseMap).id.ToString();
            string name = ((sender as ListBox).SelectedItem as BaseMap).name;
            string url = string.Empty;
            switch (filterNum)
            {
                case '0': url = StaticURLHelper.GetURL(type).Filter1; break;
                case '1': url = StaticURLHelper.GetURL(type).Filter2; break;
                case '2': url = StaticURLHelper.GetURL(type).Filter3; break;
                default:
                    url = StaticURLHelper.GetURL(type).Filter1; break;

            }
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);

            GetJSON(url, dic);
            this.LayoutRoot.Children.Remove(oItem);
            SetFilterButton(name);
        }


        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            result = GetData(keyword, e.Node);
            Render();
        }

        private void OItem_OnData1Changed(object sender, SelectionChangedEventArgs e)
        {
            if (filterNum == 2)
            {
                string id = ((sender as ListBox).SelectedItem as BaseMap).id.ToString();
                string name = ((sender as ListBox).SelectedItem as BaseMap).name;
                string url = string.Empty;
                switch (filterNum)
                {
                    case '0': url = StaticURLHelper.GetURL(type).Filter1; break;
                    case '1': url = StaticURLHelper.GetURL(type).Filter2; break;
                    case '2': url = StaticURLHelper.GetURL(type).Filter3; break;
                    default:
                        url = StaticURLHelper.GetURL(type).Filter1; break;

                }
                Dictionary<string, string> dic = new Dictionary<string, string>();
                dic.Add("id", id);
                GetJSON(url, dic);
                this.LayoutRoot.Children.Remove(oItem);
                SetFilterButton(name);
            }
        }
        private void OItem_OnCancel(object sender, RoutedEventArgs e)
        {
            this.LayoutRoot.Children.Remove(oItem);

        }

        #endregion
        #region 方法  
        private void InitMsg(bool isComeUp)
        {
            if (isComeUp)
            {
                this.MsgBox.Visibility = Visibility.Visible;
                this.MsgBox.TBMessage.Text = string.Format("找不到内容：{0}", keyword);
            }
            else
            {
                this.MsgBox.Visibility = Visibility.Collapsed;
            }
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
        private void SetFilterButton(string name)
        {
            if (filterNum == 0)
            {
                InitFilterButton(name, "", "");
            }
            else if (filterNum == 1)
            {
                InitFilterButton("", name, "");
            }
            else if (filterNum == 2)
            {
                InitFilterButton("", "", name);
            }
        }

        private void InitFilterButton(string content1, string content2, string content3)
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
            if (string.IsNullOrEmpty(FilterHelper.GetFilterName(type)[2]))
            {
                this.BTNFilter3.Visibility = Visibility.Collapsed;
            }
            else
            {
                this.BTNFilter3.Content = string.Format("{0}:{1}", FilterHelper.GetFilterName(type)[2].Split('|')[1], string.IsNullOrEmpty(content3) ? "全部" : content3);
            }

        }
        private void GetJSON(string url, Dictionary<string, string> dic)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;
        }
        private async Task<List<Model.KeyWordsMap>> GetData(string keyword)
        {
            List<Model.KeyWordsMap> list = await mapser.ReadKeywordsMap(type);
            return list;

        }
        private List<Model.KeyWordsMap> GetData(string keyword, string jsonStr)
        {
            List<KeyWordsMap> list = DeserializeHelper.GetMap(type, jsonStr);
            return list;
        }
        #endregion

    }
}