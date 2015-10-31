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
using Healthcare.Model;
using System.ComponentModel;

namespace Healthcare
{
    public partial class DrugResultPage : PhoneApplicationPage
    {
        private string type;
        private List<KeyWordsMap> result;

        public DrugResultPage()
        {
            InitializeComponent();
        }

        private void BTNBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void LLSResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idStr = ((sender as LongListSelector).SelectedItem as Model.KeyWordsMap).id.ToString();
            string destination = "/DrugDetailPage.xaml";
            destination += string.Format("?id={0}", idStr);
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));

        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Dictionary<string, string> dic;

            if (PhoneApplicationService.Current.State.ContainsKey("dic"))
            {
                dic = (Dictionary<string, string>)PhoneApplicationService.Current.State["dic"];
            }
            else return;
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            if (parameters.ContainsKey("type"))
            {
                type = (parameters["type"] as string);
            }
            string url = string.Empty;
            url = StaticURLHelper.GetURL(type).List;

            GetJSON(url, dic);

            base.OnNavigatedTo(e);
        }
        private void GetJSON(string url, Dictionary<string, string> dic)
        {
            HttpHelper ht = new HttpHelper();
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent; ;
        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            result = GetData(e.Node);
            Render();
        }

        private List<Model.KeyWordsMap> GetData(string jsonStr)
        {
            List<KeyWordsMap> list = DeserializeHelper.GetMap(type, jsonStr);
            return list;
        }

        private void Render()
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                InitMsg(result.Count == 0);
                this.LLSResult.ItemsSource = result;
                //SetFilterButton();

            });

        }
        private void InitMsg(bool isComeUp)
        {
            if (isComeUp)
            {
                this.MsgBox.Visibility = Visibility.Visible;
                this.MsgBox.TBMessage.Text = string.Format("找不到内容");
            }
            else
            {
                this.MsgBox.Visibility = Visibility.Collapsed;
            }
        }

    }
}