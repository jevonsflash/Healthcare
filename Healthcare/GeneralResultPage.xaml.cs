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

namespace Healthcare
{
    public partial class GeneralResultPage : PhoneApplicationPage
    {
        private Server.DiseaseServer diseaseser = new Server.DiseaseServer();
        private List<Model.GeneralSearchItem> SearchList = new List<Model.GeneralSearchItem>();
        private string keyword;
        public GeneralResultPage()
            : base()
        {
            InitializeComponent();
            InitBGStyle();

        }


        #region 事件


        void ht_FileWatchEvent(object sender, CompleteEventArgs e)
        {
            SearchList = diseaseser.DiseaseSearchDeserializer(e.Node).ToList();
            this.Dispatcher.BeginInvoke(() =>
            {
               
                this.LLSResult.ItemsSource = SearchList;
                
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

        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LLSResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idStr = ((sender as LongListSelector).SelectedItem as Model.GeneralSearchItem).id.ToString();
            string destination = "/GeneralDetailPage.xaml";
            destination += string.Format("?id={0}", idStr);
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;

            if (parameters.ContainsKey("keyword"))
            {
                keyword = (parameters["keyword"] as string);

            }
            if (!string.IsNullOrEmpty(keyword))
            {
                string url = Helper.StaticURLHelper.DiseaseSearch;

                GetData(url, keyword);
            }

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
        private void GetData(string url, string keyword)
        {
            HttpHelper ht = new HttpHelper();
            Dictionary<string, string> dic = new Dictionary<string, string>();
            dic.Add("keyword", keyword);
            ht.CreatePostHttpResponse(url, dic);
            ht.FileWatchEvent += ht_FileWatchEvent;
        }


        #endregion


    }
}