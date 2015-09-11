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
    public partial class GeneralDetailPage : PhoneApplicationPage
    {

        private string idStr;

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
            if (!string.IsNullOrEmpty(idStr))
            {
                string url = Helper.StaticURLHelper.SymptomShow;
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
            DicItem = Factory.ItemDetailFactory.GetContent("symptom", e.Node);
            if (DicItem.Count > 0)
            {

                foreach (var item in DicItem)
                {
                    this.Dispatcher.BeginInvoke(() =>
                    {
                        MyUserControl.ItemControl oItem = new MyUserControl.ItemControl();
                        oItem.Title.Text = item.Key;
                        oItem.Content.Text = item.Value;
                        this.SPContentArea.Children.Add(oItem);
                    });
                }
            }
        }

    }

}