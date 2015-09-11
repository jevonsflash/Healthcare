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

namespace Healthcare
{
    public partial class GeneralResultPage : PhoneApplicationPage
    {
        private MapServer mapser = new MapServer();
        private string keyword;
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

        private void BTNSearch_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LLSResult_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string idStr = ((sender as LongListSelector).SelectedItem as Model.KeyWordsMap).id.ToString();
            string destination = "/GeneralDetailPage.xaml";
            destination += string.Format("?id={0}", idStr);
            NavigationService.Navigate(new Uri(destination, UriKind.Relative));
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {

            base.OnNavigatedTo(e);
            IDictionary<string, string> parameters = this.NavigationContext.QueryString;

            if (parameters.ContainsKey("keyword"))
            {
                keyword = (parameters["keyword"] as string);
                keyword = "出血";

            }
            if (!string.IsNullOrEmpty(keyword))
            {

                List<Model.KeyWordsMap> result = await GetData(keyword);
                this.Dispatcher.BeginInvoke(() =>
                {
                    this.LLSResult.ItemsSource = result;
                });
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
        private async Task<List<Model.KeyWordsMap>> GetData(string keyword)
        {
            List<Model.KeyWordsMap> list = await mapser.ReadMap("Symptom");
            List<Model.KeyWordsMap> result = list.FindAll(c => c.keywords.Contains(keyword));
            return result;
        }


        #endregion


    }
}