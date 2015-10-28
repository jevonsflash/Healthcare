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

namespace Healthcare
{
    public partial class GeneralDetailPage : PhoneApplicationPage
    {

        private string idStr;
        private string type;

        public GeneralDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;

            if (parameters.ContainsKey("id"))
            {
                idStr = (parameters["id"] as string);

            }
            if (parameters.ContainsKey("type"))
            {
                type = (parameters["type"] as string);

            }

            if (!string.IsNullOrEmpty(idStr))
            {
                string url = StaticURLHelper.GetURL(type).Show;
                GetData(url, idStr);
            }
        }

        private void GetData(string url, string id)
        {
            HttpHelper ht = new HttpHelper();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", id);
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += ht_FileWatchEvent;
        }

        void ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            Dictionary<string, string> DicItem = new Dictionary<string, string>();
            DicItem = ItemDetailHelper.GetContent(type, e.Node);
            if (DicItem.Count > 0)
            {

                foreach (var item in DicItem)
                {
                    this.Dispatcher.BeginInvoke(() =>
                    {
                        MyUserControl.ItemControl oItem = new MyUserControl.ItemControl();
                        string title = item.Key;
                        string content = string.Empty;
                        if (item.Value == null || item.Value == "")
                        {
                            content = "暂无信息";
                        }
                        else
                        {
                            content = item.Value.Replace("<p>", string.Empty).Replace("</p>", "\n");

                        }
                        oItem.Title.Text = title;
                        oItem.Content.Text = content;
                        if (content.Count() > 100)
                        {
                            oItem.BTNMore.Visibility = Visibility.Visible;
                        }
                        else
                        {
                            oItem.BTNMore.Visibility = Visibility.Collapsed;
                        }
                        this.SPContentArea.Children.Add(oItem);
                    });
                }
            }
        }

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }

}