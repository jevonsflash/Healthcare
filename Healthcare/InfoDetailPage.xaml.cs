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
using HTMLConverter;

namespace Healthcare
{
    public partial class InfoDetailPage : PhoneApplicationPage
    {
        private InfoShowItem oInfo = new InfoShowItem();
        private static InfoServer infoser = new InfoServer();
        private string idStr = string.Empty;
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
            HttpHelper ht = new HttpHelper();
            string url = StaticURLHelper.InfoShow;
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
                this.RTBContent.Blocks.Add(StrToParagraph(oInfo.message));
            });
        }
        public Paragraph StrToParagraph(string input)
        {
            if (input == null)
            {
                return new Paragraph();
            }
            //string xaml = HtmlToXamlConverter.ConvertHtmlToXaml(input, false);
            string xaml = string.Empty;
            return (Paragraph)XamlReader.Load(xaml);
        }
    }

}