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
using Healthcare.Server;
using Healthcare.Model;
using System.Windows.Documents;
using System.Text.RegularExpressions;
using System.Windows.Markup;
using System.IO.IsolatedStorage;
using System.Text;

namespace Healthcare
{
    public partial class InfoDetailPage : PhoneApplicationPage
    {
        private InfoShowItem oInfo = new InfoShowItem();
        private static InfoServer infoser = new InfoServer();
        private string idStr = string.Empty;
        private string type = string.Empty;

        public InfoDetailPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;
            base.OnNavigatedTo(e);
            if (parameters.ContainsKey("id"))
            {
                idStr = (parameters["id"] as string);

            }
            if (parameters.ContainsKey("type"))
            {
                type = (parameters["type"] as string);

            }
            HttpHelper ht = new HttpHelper();
            string url = StaticURLHelper.GetURL(type)[0];
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("id", idStr);
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += Ht_FileWatchEvent;

        }

        private void Ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            oInfo = infoser.InfoObjectDeserializer(e.Node);
            this.Dispatcher.BeginInvoke(() =>
            {
                this.TBTitle.Text = oInfo.title;
                this.TBTime.Text = TimeHelper.TimeStamptoDateTime(oInfo.time.ToString()).ToString("MM月dd日");
                this.TBCount.Text = oInfo.count.ToString();
                this.TBRcount.Text = oInfo.rcount.ToString();
                StrToParagraph(oInfo.message);
            });
        }
        public void StrToParagraph(string input)
        {
            using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
            {
                if (!file.DirectoryExists("temp"))
                    file.CreateDirectory("temp");
                using (IsolatedStorageFileStream fs = new IsolatedStorageFileStream("temp\\review.html", System.IO.FileMode.Create, file))
                {
                    string html = "<!DOCTYPE html><html lang='zh-CN'><head><meta http-equiv='Content-Type' content='text/html; charset=utf-8'><meta name='viewport' content='width=device-width, initial-scale=1.0, user-scalable=no, minimum-scale=1.0, maximum-scale=1.0' /></head><body>";
                    html += input;
                    html += "</body></html>";
                    byte[] bytes = Encoding.UTF8.GetBytes(html);
                    fs.Write(bytes, 0, bytes.Length);
                }
            }
            this.wb.Navigate(new Uri("temp\\review.html", UriKind.Relative));
        }
    }

}