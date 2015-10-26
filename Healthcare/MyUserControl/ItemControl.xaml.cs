using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Healthcare.MyUserControl
{
    public partial class ItemControl : UserControl
    {
        public ItemControl()
        {
            InitializeComponent();
        }

        private void BTNMore_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)this.BTNMore.IsChecked)
            {
                this.ItemBlock.MaxHeight = 4800;
            }
            else
            {
                this.ItemBlock.MaxHeight = 480;

            }

        }
    }
}
