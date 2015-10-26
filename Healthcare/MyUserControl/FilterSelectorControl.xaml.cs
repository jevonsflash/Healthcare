using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Healthcare.Model;
using System.Collections.ObjectModel;

namespace Healthcare.MyUserControl
{
    public partial class FilterSelectorControl : UserControl
    {
        public event SelectionChangedEventHandler OnData1Changed;
        public event SelectionChangedEventHandler OnData2Changed;
        public event RoutedEventHandler OnCancel;
        public BaseMap Result
        {
            get
            {
                return result;
            }
        }
        private BaseMap result;
        public List<BaseMap> Data { get; set; }
        public FilterSelectorControl(List<BaseMap> Data)
        {
            InitializeComponent();
            this.Data = Data;
        }

        private void LBSelector1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            OnData1Changed(sender, e);
            List<BaseMap> subList = (this.LBSelector1.SelectedItem as BaseMap).BaseMaps;
            ObservableCollection<BaseMap> subData = new ObservableCollection<BaseMap>(subList);
            this.Dispatcher.BeginInvoke(() =>
            {
                this.LBSelector2.ItemsSource = subData;
            });

        }

        private void LBSelector2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            result = this.LBSelector2.SelectedItem as BaseMap;
            OnData2Changed(sender, e);
        }

        private void BTNMore_Click(object sender, RoutedEventArgs e)
        {
            OnCancel(sender, e);
        }
    }
}
