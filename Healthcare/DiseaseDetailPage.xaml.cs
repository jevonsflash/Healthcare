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
    public partial class DiseaseDetailPage : PhoneApplicationPage
    {
        private Server.DiseaseServer diseaseser = new Server.DiseaseServer();
        private Model.DiseaseShowItem diseaseShow = new Model.DiseaseShowItem();

        private string idStr;

        public DiseaseDetailPage()
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
                string url = Helper.StaticURLHelper.DiseaseShow;
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

        }

    }

}